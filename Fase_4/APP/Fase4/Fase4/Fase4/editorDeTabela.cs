using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fase4
{
    public partial class editorDeTabela : Form
    {
        dbHelper db = new dbHelper();
        private string atualTableName;
        private string searchVar1;
        private string searchVar2;
        private string searchVar3;
        private string addVar1;
        private string addVar2;
        private string addVar3;
        private string deleteVar1;
        private string deleteVar2;
        private string deleteVar3;
        private string infoIdOrdProd;
        private int infoQuantidade;
        private string infoIdSerie;
        private int rssi = 0;
        private int antenaId;
        private string tagId;
        private string epcId;
        private string data;
        private string hora;


        public editorDeTabela()
        {
            InitializeComponent();
        }

        private void editorDeTabela_Load(object sender, EventArgs e)
        {
            chooseBd_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            putTableNames();
            timer1.Start();
            if (chooseBd_comboBox.SelectedItem == null)
            {
                chooseBd_comboBox.SelectedIndex = 0;
                chooseBd_comboBox.Enabled = false;
            }
        }
        private void getVarsModelo()
        {
            infoIdOrdProd = initialPage.instance.idProdOrdem;
            infoQuantidade = initialPage.instance.quantidade;
            infoIdSerie = initialPage.instance.idSerie;
        }

        private void putTableNames()
        {
            string[] tableNames = db.getJsonTableNames();

            foreach (string tableName in tableNames)
            {
                chooseBd_comboBox.Items.Add(tableName);
            }
        }

        private void chooseBd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseBd_comboBox.SelectedItem != null)
            {
                atualTableName = chooseBd_comboBox.SelectedItem.ToString();

                tabelaAtual_label.Text = "Tabela: " + atualTableName;

                UpdateDataGrid();

                string searchOption = chooseBd_comboBox.SelectedItem.ToString();

                if (searchOption == "dbo.LeituraTag_FX96000")
                {
                    labelSearch1.Text = "ID da Tag:";
                    labelSearch1.Location = new Point(18, labelSearch1.Location.Y);
                    labelSearch2.Text = "EPC da Tag:";
                    labelSearch2.Location = new Point(8, labelSearch2.Location.Y);
                    labelSearch3.Text = "Antena:";
                    labelSearch3.Location = new Point(32, labelSearch3.Location.Y);
                }
            }
        }


        private void UpdateDataGrid()
        {
            DataTable dadosDaTabela = db.allTablesShowAllBd(atualTableName);
            dataGrid_DB.DataSource = dadosDaTabela;
        }

        private void GetVarsSearch()
        {
            searchVar1 = search_TextBox1.Text;
            searchVar2 = search_TextBox2.Text;
            searchVar3 = search_TextBox3.Text;

        }
        private void GetVarsAdd()
        {
            addVar1 = add_textBox1.Text;
            addVar2 = add_textBox2.Text;
            addVar3 = add_textBox3.Text;
        }

        private void GetVarsDelete()
        {
            deleteVar1 = delete_textBox1.Text;
            deleteVar2 = delete_textBox2.Text;
            deleteVar3 = delete_textBox3.Text;
        }

        private DataTable DeleteInDb(string tableName, string columnName1, string columnName2, string columnName3)
        {
            DataTable result = null;

            if (!string.IsNullOrEmpty(deleteVar1) && !string.IsNullOrEmpty(deleteVar2) && !string.IsNullOrEmpty(deleteVar3))
            {
                result = db.ModelDelete(tableName, columnName1, deleteVar1, columnName2, deleteVar2, columnName3, deleteVar3);
            }
            else if (!string.IsNullOrEmpty(deleteVar1) && !string.IsNullOrEmpty(deleteVar2))
            {
                result = db.ModelDelete(tableName, columnName1, deleteVar1, columnName2, deleteVar2);
            }
            else if (!string.IsNullOrEmpty(deleteVar1) && !string.IsNullOrEmpty(deleteVar3))
            {
                result = db.ModelDelete(tableName, columnName1, deleteVar1, columnName3, deleteVar3);
            }
            else if (!string.IsNullOrEmpty(deleteVar2) && !string.IsNullOrEmpty(deleteVar3))
            {
                result = db.ModelDelete(tableName, columnName2, deleteVar2, columnName3, deleteVar3);
            }
            else if (!string.IsNullOrEmpty(deleteVar1))
            {
                result = db.ModelDelete(tableName, columnName1, deleteVar1);
            }
            else if (!string.IsNullOrEmpty(deleteVar2))
            {
                result = db.ModelDelete(tableName, columnName2, deleteVar2);
            }
            else if (!string.IsNullOrEmpty(deleteVar3))
            {
                result = db.ModelDelete(tableName, columnName3, deleteVar3);
            }

            return result;
        }

        private DataTable SearchInDatabase(string tableName, string columnName1, string columnName2, string columnName3)
        {
            DataTable result = null;

            if (!string.IsNullOrEmpty(searchVar1) && !string.IsNullOrEmpty(searchVar2) && !string.IsNullOrEmpty(searchVar3))
            {
                result = db.ModelSearch(tableName, columnName1, searchVar1, columnName2, searchVar2, columnName3, searchVar3);
            }
            else if (!string.IsNullOrEmpty(searchVar1) && !string.IsNullOrEmpty(searchVar2))
            {
                result = db.ModelSearch(tableName, columnName1, searchVar1, columnName2, searchVar2);
            }
            else if (!string.IsNullOrEmpty(searchVar1) && !string.IsNullOrEmpty(searchVar3))
            {
                result = db.ModelSearch(tableName, columnName1, searchVar1, columnName3, searchVar3);
            }
            else if (!string.IsNullOrEmpty(searchVar2) && !string.IsNullOrEmpty(searchVar3))
            {
                result = db.ModelSearch(tableName, columnName2, searchVar2, columnName3, searchVar3);
            }
            else if (!string.IsNullOrEmpty(searchVar1))
            {
                result = db.ModelSearch(tableName, columnName1, searchVar1);
            }
            else if (!string.IsNullOrEmpty(searchVar2))
            {
                result = db.ModelSearch(tableName, columnName2, searchVar2);
            }
            else if (!string.IsNullOrEmpty(searchVar3))
            {
                result = db.ModelSearch(tableName, columnName3, searchVar3);
            }

            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Data_textBox.Enabled = false;
            Hora_textBox.Enabled = false;
            Data_textBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Hora_textBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                UpdateDataGrid();
                checkBox1.Checked = false;
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            GetVarsSearch();

            string searchOption = chooseBd_comboBox.SelectedItem.ToString();

            DataTable tableData = null;

            if (chooseBd_comboBox.SelectedItem != null)
            {
                if (searchOption == "dbo.LeituraTag_FX96000")
                {
                    tableData = SearchInDatabase(searchOption, "Tag_id", "EPC_id", "Antenna_id");
                }
                else
                {
                    MessageBox.Show("Tabela não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma tabela.");
            }

            if (tableData != null && tableData.Rows.Count > 0)
            {
                dataGrid_DB.DataSource = tableData;
            }
            else
            {
                MessageBox.Show("Nenhum resultado encontrado.");
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            getVarsModelo();
            GetVarsAdd();
            getTagVars();
            //se os campos não estiverem todos preenchidos manda uma mensagem de erro
            if (string.IsNullOrEmpty(addVar1) || string.IsNullOrEmpty(addVar2) || string.IsNullOrEmpty(addVar3))
            {
                MessageBox.Show("Preencha todos os campos primeiro");
                return;
            }
            else
            {
                addDbRfid();
                addDbRead();
                UpdateDataGrid();       
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            GetVarsDelete();

            string searchOption = chooseBd_comboBox.SelectedItem.ToString();

            DataTable tableData = null;

            if (chooseBd_comboBox.SelectedItem != null)
            {
                if (searchOption == "dbo.LeituraTag_FX96000")
                {
                    tableData = DeleteInDb(searchOption, "Tag_id", "EPC_id", "Antenna_id");
                    MessageBox.Show("Deletado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Tabela não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma tabela.");
            }

            if (tableData != null && tableData.Rows.Count > 0)
            {
                dataGrid_DB.DataSource = tableData;
            }

            UpdateDataGrid();
        }

        private void getTagVars()
        {
            tagId = addVar1;
            epcId = addVar2;
            antenaId = Convert.ToInt32(addVar3);
        }

        private void addDbRfid()
        {
            data = DateTime.Now.ToString("dd/MM/yyyy");
            hora = DateTime.Now.ToString("HH:mm:ss");
            db.rfidAddToBd(antenaId, tagId, epcId, rssi, data, hora);
        }


        private void addDbRead()
        {
            string postoString = postByAntenna(tagId);
            db.readAddToBd(infoIdSerie, tagId, postoString, infoIdOrdProd, antenaId, infoQuantidade, data, hora);
        }

        private string postByAntenna(string tag)
        {
            string posto = "";

            int antena = db.rfidGetAntenaId(tag);

            switch (antena)
            {
                case 1:
                    posto = "LINHA 1 EXPEDIÇÃO";
                    break;
                case 2:
                    posto = "LINHA 2 EXPEDIÇÃO";
                    break;
                case 3:
                    posto = "LINHA 3 EXPEDIÇÃO";
                    break;
                case 4:
                    posto = "LINHA 4 EXPEDIÇÃO";
                    break;
                default:
                    break;
            }

            return posto;
        }
    }
}
