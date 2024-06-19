using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fase4.dbHelper;
using static Fase4.jsonConfig;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fase4
{
    public partial class allDataBaseAcess : Form
    {
        dbHelper db = new dbHelper();

        private string atualTableName;

        private string searchVar1;
        private string searchVar2;
        private string searchVar3;
        public string columnName;


        public allDataBaseAcess()
        {
            InitializeComponent();
        }

        private void allDataBaseAcess_Load(object sender, EventArgs e)
        {
            putTableNames();
            chooseBd_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //updateDataGrid();
            if (chooseBd_comboBox.SelectedItem == null)
            {
                chooseBd_comboBox.SelectedIndex = 0;
            }
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
                search_TextBox1.Text = "";
                search_TextBox2.Text = "";
                search_TextBox3.Text = "";
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
                else if (searchOption == "dbo.tableReadInfo")
                {
                    labelSearch1.Text = "Serie ID:";
                    labelSearch1.Location = new Point(28, labelSearch1.Location.Y);
                    labelSearch2.Text = "ID da Tag:";
                    labelSearch2.Location = new Point(18, labelSearch2.Location.Y);
                    labelSearch3.Text = "Antena:";
                    labelSearch3.Location = new Point(32, labelSearch3.Location.Y);

                }
                else if (searchOption == "dbo.tableModelInfo")
                {
                    labelSearch1.Text = "Serie ID:";
                    labelSearch1.Location = new Point(28, labelSearch1.Location.Y);
                    labelSearch2.Text = "ID Orde Prod:";
                    labelSearch2.Location = new Point(4, labelSearch2.Location.Y);
                    labelSearch3.Text = "Artigo:";
                    labelSearch3.Location = new Point(39, labelSearch3.Location.Y);
                }
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
                else if (searchOption == "dbo.tableReadInfo")
                {
                    tableData = SearchInDatabase(searchOption, "serie_ID", "tagId", "idAntena");
                }
                else if (searchOption == "dbo.tableModelInfo")
                {
                    tableData = SearchInDatabase(searchOption, "serie_ID", "idProdOrder", "article");
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

        private void GetVarsSearch()
        {
            searchVar1 = search_TextBox1.Text;
            searchVar2 = search_TextBox2.Text;
            searchVar3 = search_TextBox3.Text;

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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                UpdateDataGrid();
                checkBox1.Checked = false;
            }
        }

        private void UpdateDataGrid()
        {
            DataTable dadosDaTabela = db.allTablesShowAllBd(atualTableName);
            dataGrid_DB.DataSource = dadosDaTabela;
        }


    }
}
