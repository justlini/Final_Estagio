using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static Fase4.jsonConfig;


namespace Fase4
{
    internal class dbHelper
    {
        private string jsonPath = @".\config_DB_JSON.json";


        public Rootobject readConfig(string filePath)
        {
            string fileName = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Rootobject>(fileName);
        }

        public string[] getJsonTableNames()
        {
            string jsonText = File.ReadAllText(jsonPath);

            dynamic config = JsonConvert.DeserializeObject(jsonText);

            List<string> tableNamesList = new List<string>();

            foreach (var tableName in config.tableNames)
            {
                tableNamesList.Add(tableName.Value.ToString());
            }

            return tableNamesList.ToArray();
        }


        //Conexão à base de dados
        private SqlConnection ConnectBd()
        {
            //SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=dbFase2;User Id=sa;Password=sa");   
            var dbconfig = readConfig(jsonPath);

            string sqlCommandStr = $"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}";

            SqlConnection conn = new SqlConnection(sqlCommandStr);

            try
            {
                conn.Open();
                return conn;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //!!!!!!!!!! TODAS AS TABELAS !!!!!!!!!!!!!!!!!
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-

        public DataTable allTablesShowAllBd(string tableName)
        {
            DataTable dt = new DataTable();

            var dbconfig = readConfig(jsonPath);

            using (SqlConnection conn = ConnectBd())
            {
                string sqlCommandStr = $"SELECT * FROM {tableName}";
                SqlCommand cmd = new SqlCommand(sqlCommandStr, conn);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tableReadlInfo", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-


        //!!!!!!!!!! TABELA RFID !!!!!!!!!!!!!!!!!
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-

        public bool rfidCanInsert(int db_antenaId, string db_tagId)
        {
            var dbconfig = readConfig(jsonPath);

            int antenaId = db_antenaId;
            string tagId = db_tagId;

            bool tagExists = false;

            using (SqlConnection conn = ConnectBd())
            {
                // Verificar se existe uma tag com o mesmo id de antena
                using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table1} WHERE Antenna_id = @antenaId AND Tag_id = @tagId", conn))
                {
                    checkCmd.Parameters.AddWithValue("@antenaId", antenaId);
                    checkCmd.Parameters.AddWithValue("@tagId", tagId);
                    tagExists = (int)checkCmd.ExecuteScalar() > 0;
                }
            }

            // Retornar verdadeiro se a tag não existir, falso se existir
            return !tagExists;
        }

        public void rfidAddToBd(int db_antenaId, string db_tagId, string db_epcId, int db_rssiValueH, string db_dataLeitura, string db_horaLeitura)
        {
            var dbconfig = readConfig(jsonPath);


            int antenaId = db_antenaId;
            string tagId = db_tagId;
            string epcId = db_epcId;
            int rssi = db_rssiValueH;

            string date = db_dataLeitura;
            string hour = db_horaLeitura;

            DateTime Tdate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            DateTime Thours = DateTime.ParseExact(hour, "HH:mm:ss", null);


            using (SqlConnection conn = ConnectBd())
            {
                if (rfidCanInsert(db_antenaId, db_tagId))
                {
                    string sqlCommandStr = $"INSERT INTO {dbconfig.tableNames.table1} (Antenna_id, Tag_id, EPC_id, RSSI, Data_Leitura, Hora_Leitura)" +
                    $" VALUES (@antenaId, @tagId, @epcId, @rssi, @date, @hour)";
                    SqlCommand cmd = new SqlCommand(sqlCommandStr, conn);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tableReadlInfo (idProdOrder, tagId, readDate, readHour, post) VALUES (@id, @atagId, @aDate, @aHour, @aPost)", conn);
                    cmd.Parameters.AddWithValue("@antenaId", antenaId);
                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    cmd.Parameters.AddWithValue("@epcId", epcId);
                    cmd.Parameters.AddWithValue("@rssi", rssi);
                    cmd.Parameters.AddWithValue("@date", Tdate);
                    cmd.Parameters.AddWithValue("@hour", Thours);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.Message);

                    }
                }
                else
                {
                    //MessageBox.Show($"Registro com EPC_Id {epcId} e antena {tagId} já existe na base de dados.");
                }

            }
        }

        public int rfidGetAntenaId(string tagId)
        {
            var dbconfig = readConfig(jsonPath);

            string tag = tagId;

            int antenaId;

            using (SqlConnection conn = ConnectBd())
            {
                using (SqlCommand checkCmd = new SqlCommand($"SELECT Antenna_id FROM {dbconfig.tableNames.table1} WHERE Tag_id = @tagId", conn))
                {
                    checkCmd.Parameters.AddWithValue("@tagId", tag);
                    antenaId = (int)checkCmd.ExecuteScalar();
                }
            }

            return antenaId;
        }

        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-



        //!!!!!!!!!! TABELA MODEL !!!!!!!!!!!!!!!!!
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-


        public bool modelCanInsert(string db_idProdOrder)
        {
            var dbconfig = readConfig(jsonPath);

            string idProdOrder = db_idProdOrder;

            bool idExists = false;

            using (SqlConnection conn = ConnectBd())
            {
                using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table2} WHERE idProdOrder = @idProdOrder", conn))
                {
                    checkCmd.Parameters.AddWithValue("@idProdOrder", idProdOrder);
                    idExists = (int)checkCmd.ExecuteScalar() > 0;
                }
            }

            return !idExists;
        }


        public void modelAddToBd(string db_idProdOrder, string db_serieId, string db_article, int db_quantity, int db_capacDia)
        {
            var dbconfig = readConfig(jsonPath);


            string idProdOrder = db_idProdOrder;
            string serieId = db_serieId;
            string article = db_article;
            int quantity = db_quantity;
            int capacidadeDia = db_capacDia;


            using (SqlConnection conn = ConnectBd())
            {
                if (modelCanInsert(db_idProdOrder))
                {
                    string sqlCommandStr = $"INSERT INTO {dbconfig.tableNames.table3} (idProdOrder, serie_ID, article, quantity, capacDia)" +
                    $" VALUES (@idProdOrder, @serieId, @article, @quantity, @capacidadeDia)";
                    SqlCommand cmd = new SqlCommand(sqlCommandStr, conn);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tableReadlInfo (idProdOrder, tagId, readDate, readHour, post) VALUES (@id, @atagId, @aDate, @aHour, @aPost)", conn);
                    cmd.Parameters.AddWithValue("@idProdOrder", idProdOrder);
                    cmd.Parameters.AddWithValue("@serieId", serieId);
                    cmd.Parameters.AddWithValue("@article", article);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@capacidadeDia", capacidadeDia);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public bool modelCanInsertV2(string db_idProdOrder, string db_serieId)
        {
            var dbconfig = readConfig(jsonPath);

            string idProdOrder = db_idProdOrder;
            string serieId = db_serieId;

            bool idExists = false;

            using (SqlConnection conn = ConnectBd())
            {
                using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table3} WHERE idProdOrder = @idProdOrder AND serie_ID = @serieId", conn))
                {
                    checkCmd.Parameters.AddWithValue("@idProdOrder", idProdOrder);
                    checkCmd.Parameters.AddWithValue("@serieId", serieId);
                    idExists = (int)checkCmd.ExecuteScalar() > 0;
                }
            }
            return !idExists;
        }

        public void modelDelete(string db_idProdOrder, string db_serieId)
        {
            var dbconfig = readConfig(jsonPath);

            string idProdOrder = db_idProdOrder;
            string serieId = db_serieId;

            using (SqlConnection conn = ConnectBd())
            {
                string sqlCommandStr = $"DELETE FROM {dbconfig.tableNames.table3} WHERE idProdOrder = @idProdOrder AND serie_ID = @serieId";
                SqlCommand cmd = new SqlCommand(sqlCommandStr, conn);
                cmd.Parameters.AddWithValue("@idProdOrder", idProdOrder);
                cmd.Parameters.AddWithValue("@serieId", serieId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //!!!!!!!!!! TABELA READ !!!!!!!!!!!!!!!!!
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-

        public bool readCanInsert(int antenaId, string tagId)
        {
            var dbconfig = readConfig(jsonPath);

            string tag = tagId;
            int antena = antenaId;

            bool tagExists = false;

            using (SqlConnection conn = ConnectBd())
            {
                using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table2} WHERE tagId = @tagId AND idAntena = @antenaId", conn))
                {
                    checkCmd.Parameters.AddWithValue("@tagId", tag);
                    checkCmd.Parameters.AddWithValue("@antenaId", antena);
                    tagExists = (int)checkCmd.ExecuteScalar() > 0;
                }
            }

            return !tagExists;
        }

        public void readAddToBd(string db_serie_ID, string db_tagId, string db_postInf, string db_idProdOrder, int db_idAntena, int db_quantity, string db_readDate, string db_readHour)
        {
            var dbconfig = readConfig(jsonPath);

            string serieId = db_serie_ID;
            string tagId = db_tagId;
            string postInfo = db_postInf;
            string idProdOrder = db_idProdOrder;
            int idAntena = db_idAntena;
            int quantity = db_quantity;
            string readDate = db_readDate;
            string readHour = db_readHour;

            DateTime Tdate = DateTime.ParseExact(readDate, "dd/MM/yyyy", null);
            DateTime Thours = DateTime.ParseExact(readHour, "HH:mm:ss", null);

            using (SqlConnection conn = ConnectBd())
            {
                string sqlCommandStr = $"INSERT INTO {dbconfig.tableNames.table2} (serie_ID, tagId, postInf, idProdOrder, idAntena, quantity, readDate, readHour)" +
                $" VALUES (@serieId, @tagId, @postInfo, @idProdOrder, @idAntena, @quantity, @readDate, @readHour)";
                SqlCommand cmd = new SqlCommand(sqlCommandStr, conn);
                cmd.Parameters.AddWithValue("@serieId", serieId);
                cmd.Parameters.AddWithValue("@tagId", tagId);
                cmd.Parameters.AddWithValue("@postInfo", postInfo);
                cmd.Parameters.AddWithValue("@idProdOrder", idProdOrder);
                cmd.Parameters.AddWithValue("@idAntena", idAntena);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@readDate", Tdate);
                cmd.Parameters.AddWithValue("@readHour", Thours);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //MessageBox.Show(e.Message);
                    //MessageBox.Show("Erro aqui!!");
                }
            }
        }



        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-
        //PROCURAR
        public DataTable ModelSearch(string tableName, string columnName1, string columnValue1)
        {
            return ModelSearchInternal(tableName, columnName1, columnValue1);
        }

        public DataTable ModelSearch(string tableName, string columnName1, string columnValue1, string columnName2, string columnValue2)
        {
            return ModelSearchInternal(tableName, columnName1, columnValue1, columnName2, columnValue2);
        }

        public DataTable ModelSearch(string tableName, string columnName1, string columnValue1, string columnName2, string columnValue2, string columnName3, string columnValue3)
        {
            return ModelSearchInternal(tableName, columnName1, columnValue1, columnName2, columnValue2, columnName3, columnValue3);
        }

        private DataTable ModelSearchInternal(string tableName, params object[] parameters)
        {
            DataTable dt = new DataTable();
            var dbconfig = readConfig(jsonPath);

            using (SqlConnection conn = ConnectBd())
            {
                string query = $"SELECT * FROM {tableName} WHERE ";

                for (int i = 0; i < parameters.Length; i += 2)
                {
                    query += $"{parameters[i]} = @{parameters[i]}";

                    if (i + 2 < parameters.Length)
                    {
                        query += " AND ";
                    }
                }

                using (SqlCommand checkCmd = new SqlCommand(query, conn))
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        checkCmd.Parameters.AddWithValue($"@{parameters[i]}", parameters[i + 1]);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-
        //ELIMINAR

        public DataTable ModelDelete(string tableName, string columnName1, string columnValue1)
        {
            return ModelDeleteInternal(tableName, columnName1, columnValue1);
        }

        public DataTable ModelDelete(string tableName, string columnName1, string columnValue1, string columnName2, string columnValue2)
        {
            return ModelDeleteInternal(tableName, columnName1, columnValue1, columnName2, columnValue2);
        }

        public DataTable ModelDelete(string tableName, string columnName1, string columnValue1, string columnName2, string columnValue2, string columnName3, string columnValue3)
        {
            return ModelDeleteInternal(tableName, columnName1, columnValue1, columnName2, columnValue2, columnName3, columnValue3);
        }

        private DataTable ModelDeleteInternal(string tableName, params object[] parameters)
        {
            DataTable dt = new DataTable();
            var dbconfig = readConfig(jsonPath);

            using (SqlConnection conn = ConnectBd())
            {
                string query = $"DELETE FROM {tableName} WHERE ";

                for (int i = 0; i < parameters.Length; i += 2)
                {
                    query += $"{parameters[i]} = @{parameters[i]}";

                    if (i + 2 < parameters.Length)
                    {
                        query += " AND ";
                    }
                }

                using (SqlCommand checkCmd = new SqlCommand(query, conn))
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        checkCmd.Parameters.AddWithValue($"@{parameters[i]}", parameters[i + 1]);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-


    }
}