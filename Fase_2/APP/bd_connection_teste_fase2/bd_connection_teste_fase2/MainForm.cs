using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace bd_connection_teste_fase2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Producao"] == null)
            {
                new Producao().Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LeituraTag"] == null)
            {
                new LeituraTag().Show();
            }
        }
    }
}
