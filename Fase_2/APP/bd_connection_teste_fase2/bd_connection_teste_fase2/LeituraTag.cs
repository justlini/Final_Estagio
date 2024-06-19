using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using static bd_connection_teste_fase2.ConfigJSON;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Globalization;

namespace bd_connection_teste_fase2
{
    public partial class LeituraTag : Form
    {
        private string query;
        private string jsonPath = @".\config_DB_JSON.json";
        public LeituraTag()
        {
            InitializeComponent();

        }

        private void LeituraTag_Load(object sender, EventArgs e)
        {
            LerConfiguracoes(jsonPath);
            lerBaseDeDados();
            timer1.Start();
            
        }
        public Rootobject LerConfiguracoes(string filePath)
        {
            string fileName = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Rootobject>(fileName);
        }

        private void lerBaseDeDados()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                //cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table2}", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarEInserirDados()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    // Verificar se os campos estão preenchidos
                    if (CamposNaoPreenchidos())
                    {
                        MessageBox.Show("Por favor preencha todos os campos");
                    }
                    else
                    {
                        VerificarInsercaoTabela1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CamposNaoPreenchidos()
        {
            return textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "";
        }

        private void VerificarInsercaoTabela1()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource}; Initial Catalog={dbconfig.DBname}; User ID={dbconfig.userID}; Password={dbconfig.password}"))
            {
                conn.Open();
                using (SqlCommand selectCmd = new SqlCommand($"SELECT ID_Ordem_de_Producao FROM {dbconfig.tableNames.table1}", conn))
                {
                    HashSet<string> idOrdemProducaoTabela1 = new HashSet<string>();
                    using (SqlDataReader dr = selectCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            idOrdemProducaoTabela1.Add(dr["ID_Ordem_de_Producao"].ToString());
                        }
                    }

                    if (!idOrdemProducaoTabela1.Contains(textBox1.Text))
                    {
                        MessageBox.Show("Esse ID_Ordem_de_Producao não existe na tabela Producao (tabela 1). \nInsira primeiro na tabela Producao (tabela 1).");
                    }
                    else
                    {
                        VerificarInsercaoTabela2();
                    }
                }
            }
        }

        private void VerificarInsercaoTabela2()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            bool idOrdemExisteTabela2 = false;
            bool idTagExiste = false;
            using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource}; Initial Catalog={dbconfig.DBname}; User ID={dbconfig.userID}; Password={dbconfig.password}"))
            {
                conn.Open();
                using (SqlCommand selectCmd2 = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table2}", conn))
                using (SqlDataReader dr2 = selectCmd2.ExecuteReader())
                {
                    while (dr2.Read())
                    {
                        if (textBox1.Text == dr2["ID_Ordem_de_Producao"].ToString())
                        {
                            idOrdemExisteTabela2 = true;
                        }
                        if (textBox2.Text == dr2["ID_Tag"].ToString())
                        {
                            idTagExiste = true;
                        }
                    }
                }

                if (idOrdemExisteTabela2 && idTagExiste)
                {
                    MessageBox.Show("Esses ID_Ordem_de_Producao e ID_Tag já existem na base de dados");
                }
                else if (idTagExiste)
                {
                    MessageBox.Show("Esse ID_tag já existe na base de dados");
                }
                else if (idOrdemExisteTabela2)
                {
                    MessageBox.Show("Essa ID_Ordem_de_Producao já existe na base de dados");
                }
                else
                {
                    InserirDadosTabela2();
                }
            }
        }
        private void InserirDadosTabela2()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                // cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    using (SqlCommand insertCmd = new SqlCommand($"INSERT INTO {dbconfig.tableNames.table2} (ID_Ordem_de_Producao, ID_Tag, Posto, Hora_Leitura, Data_Leitura) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox5.Text}', '{textBox4.Text}', '{textBox3.Text}')", conn))
                    {
                        insertCmd.ExecuteNonQuery();
                    }

                    DataTable dt = new DataTable();
                    using (SqlCommand selectCmd2 = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table2}", conn))
                    using (SqlDataReader dr2 = selectCmd2.ExecuteReader())
                    {
                        dt.Load(dr2);
                    }
                    dataGridView1.DataSource = dt;
                    lerBaseDeDados();
                    query = "INSERT";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificarEInserirDados();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table2} WHERE ID_Ordem_de_Producao ={textBox6.Text}", conn))

                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                            query = "SELECT";
                            button3.Visible = true;
                            label7.Text = "Resultados da pesquisa na BD (tabela 2)";
                            textBox5.Text = "";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            lerBaseDeDados();
            button3.Visible = false;
            label7.Text = "SQL LeituraTags (Tabela 2)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Producao"] == null)
            {
                new Producao().Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToString("HH:mm:ss");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}