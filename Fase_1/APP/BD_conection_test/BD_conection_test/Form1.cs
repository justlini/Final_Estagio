using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace BD_conection_test
{
    public partial class Form1 : Form
    {
        private string text1;
        private string text2;
        private string numeric1;
        private string numeric2;
        private string query; // UPDATE, DELETE, INSERT para colocar no ficheiro log

        // cria a pasta logs_testes_APP na pasta onde está o executável onde sera lido e criado o ficheiro de logs 
        private string logsFileDirectory = @".\logs_testes_APP";

        string fileName = "logs" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //jsonConfig();        // não está a funcionar ainda!!!
            lerBaseDeDados();
            CreatNewFileEveryDay();
            lerFicheiroDeLogs();
        }

        private void lerBaseDeDados()
        {
            try
            {
                //cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Fase1BD;User Id=sa;Password=sa"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table_1", conn))
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

        // Cria um novo ficheiro de logs todos os dias
        private void CreatNewFileEveryDay()
        {
            string path = Path.Combine(logsFileDirectory, fileName);
            if (!File.Exists(path))
            {
                // Se o arquivo para o dia atual não existir, crie um novo arquivo
                using (StreamWriter sw = File.CreateText(path))
                {
                    string header = "Log for " + DateTime.Now.ToString("dd-MM-yyyy") + Environment.NewLine;
                    sw.Write(header);
                }
            }
        }

        // Lê o ficheiro de logs
        private void lerFicheiroDeLogs()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(logsFileDirectory, fileName)))
            {
                string line;
                StringBuilder sb = new StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                    sb.Append("\n");
                }
                richTextBox1.Text = sb.ToString();
            }
        }

        // Botões para fazer a operação de UPDATE
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Fase1BD;User Id=sa;Password=sa"))
                {
                    text1 = textBox1.Text;
                    numeric1 = numericUpDown1.Text;
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("update Table_1 set name = '" + text1 + "' where id = " + numeric1 + "", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                        lerBaseDeDados();
                        query = "UPDATE";
                        writeLog();
                        lerFicheiroDeLogs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Botões para fazer a operação de INSERT
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Fase1BD;User Id=sa;Password=sa"))
                {
                    text2 = textBox2.Text;
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(" insert into Table_1 (name) values ('" + textBox2.Text + "')", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                        lerBaseDeDados();
                        query = "INSERT";
                        writeLog();
                        lerFicheiroDeLogs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Botões para fazer a operação de DELETE
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria a conexão com a base de dados
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Fase1BD;User Id=sa;Password=sa"))
                {
                    numeric2 = numericUpDown2.Text;
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE id = " + numeric2, conn))
                    {
                        cmd.ExecuteNonQuery();
                        dataGridView1.DataSource = null;
                        lerBaseDeDados();
                        query = "DELETE";
                        writeLog();
                        lerFicheiroDeLogs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Escreve no ficheiro de logs
        private void writeLog()
        {
            string path = Path.Combine(logsFileDirectory, fileName);
            string text = "";

            if (query == "UPDATE")// se a query for um update
            {
                text = "Log: (" + DateTime.Now.ToString() + ") id=" + numeric1 + " UPDATE name to " + text1 + "" + Environment.NewLine;
            }
            else if (query == "DELETE")// se a query for um delete
            {
                text = "Log: (" + DateTime.Now.ToString() + ") id=" + numeric2 + " got  DELETED " + Environment.NewLine;
            }
            else if (query == "INSERT")// se a query for um insert
            {
                text = "Log: (" + DateTime.Now.ToString() + ") INSERT the name " + text2 + " in the DB " + "" + Environment.NewLine;
            }
            File.AppendAllText(path, text);
        }
    }
}

