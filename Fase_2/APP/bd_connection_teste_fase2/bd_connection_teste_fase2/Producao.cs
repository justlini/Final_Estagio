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

namespace bd_connection_teste_fase2
{
    public partial class Producao : Form


    {
        private string query;
        private string jsonPath = @".\config_DB_JSON.json";
        public Producao()
        {
            InitializeComponent();

        }

        private void Producao_Load(object sender, EventArgs e)
        {
            LerConfiguracoes(jsonPath);
            lerBaseDeDados();
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
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table1}", conn))
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
        private bool CamposNaoPreenchidos()
        {
            return textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "";
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

        private void VerificarInsercaoTabela1()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            bool idOrdemExisteTabela1 = false;
            using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource}; Initial Catalog={dbconfig.DBname}; User ID={dbconfig.userID}; Password={dbconfig.password}"))
            {
                conn.Open();
                using (SqlCommand selectCmd2 = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table1}", conn))
                using (SqlDataReader dr2 = selectCmd2.ExecuteReader())
                {
                    while (dr2.Read())
                    {
                        if (textBox1.Text == dr2["ID_Ordem_de_Producao"].ToString())
                        {
                            idOrdemExisteTabela1 = true;
                        }

                    }
                }

                if (idOrdemExisteTabela1)
                {
                    MessageBox.Show("Essa ID_Ordem_de_Producao já existe na base de dados");
                }
                else
                {
                    InserirDadosTabela1();
                }
            }
        }

        private void InserirDadosTabela1()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                //cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    using (SqlCommand insertCmd = new SqlCommand($"INSERT INTO {dbconfig.tableNames.table1} (ID_Ordem_de_Producao, Numero, Artigo, Quantidade) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')", conn))
                    {
                        insertCmd.ExecuteNonQuery();
                    }

                    DataTable dt = new DataTable();
                    using (SqlCommand selectCmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table1}", conn))
                    using (SqlDataReader dr = selectCmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                    dataGridView1.DataSource = dt;
                    lerBaseDeDados();
                    query = "INSERT";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
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

                    using (SqlCommand cmd = new SqlCommand($"SELECT ID_Ordem_de_Producao, Numero, Artigo, Quantidade FROM {dbconfig.tableNames.table1} WHERE ID_Ordem_de_Producao = {textBox5.Text}", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                            query = "SELECT";
                            button3.Visible = true;
                            label6.Text = "Resultados da pesquisa na BD (tabela 1)";
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
            label6.Text = "SQL Producao (Tabela 1)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LeituraTag"] == null)
            {
                new LeituraTag().Show();
            }
        }
    }
}
