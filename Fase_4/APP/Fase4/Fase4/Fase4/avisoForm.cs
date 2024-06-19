using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase4
{
    public partial class avisoForm : Form
    {
        dbHelper db = new dbHelper();

        public string idProdOrdem;
        public string artigo;
        public int quantidade;
        public int quantidadeMin;
        public string idSerie;
        private bool canDel = false;

        public avisoForm()
        {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            db.modelDelete(idProdOrdem, idSerie);
            

            if (initialPage.instance == null)
            {
                initialPage form = new initialPage();
                form.Show();
            }
            else
            {
                initialPage.instance.Show();
            }

            this.Close();
        }
        
        private void getVars()
        {
            idProdOrdem = initialPage.instance.idProdOrdem;
            artigo = initialPage.instance.artigo;
            quantidade = initialPage.instance.quantidade;
            quantidadeMin = initialPage.instance.quantidadeMin;
            idSerie = initialPage.instance.idSerie;
        }

        private void rfid_button_Click(object sender, EventArgs e)
        {
            showRfidForm();
            this.Close();
        }

        private void avisoForm_Load(object sender, EventArgs e)
        {
            getVars();
            message();
        }

        private void showRfidForm()
        {
            rfidReader reader = new rfidReader();
            reader.Show();
        }

        private void message()
        {
            aviso.Text = "Os valores são:" +
                "\n\nID ordem produção: " + idProdOrdem +
                "\nID serie: " + idSerie +
                "\nArtigo: " +  artigo + 
                "\nQuantidade: " + quantidade +
                "\nQuantidade Min: " + quantidadeMin +
                "\n\nAo confirmar os valores serão inalteraveis";
        }

        private void avisoForm_FormClosed(object sender, FormClosingEventArgs e)
        {
            //db.modelDelete(idProdOrdem, idSerie);

            if (initialPage.instance == null)
            {
                initialPage form = new initialPage();
                form.Show();
            }
            else
            {
                initialPage.instance.Show();
            }
        }
    }
}
