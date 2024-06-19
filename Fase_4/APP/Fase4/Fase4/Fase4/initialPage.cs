using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fase4.rfidReader;

namespace Fase4
{

    public partial class initialPage : Form
    {
        dbHelper db = new dbHelper();
        rfidReader rfid = new rfidReader();
        private string iniPath = "config.ini";

        public static initialPage instance;

        public string idProdOrdem;
        public string artigo;
        public int quantidade;
        public int quantidadeMin;
        public string idSerie;

        public bool canOpenRfid = true;
        public bool canOpenDb = true;



        public initialPage()
        {
            InitializeComponent();
            instance = this;
        }

        private void submitModelBTN_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário rfidReader está aberto
            bool isAvisoFormOpen = Application.OpenForms["avisoForm"] as Form != null;

            // Obtém os valores dos campos
            getVars();

           // canGoBd();

            // Verifica se o formulário rfidReader não está aberto e se todos os campos obrigatórios estão preenchidos
            if (!isAvisoFormOpen && canGoBd())
            {
                showAviso();
            }
        }


        private void getVars()
        {
            idProdOrdem = idOrdProdText.Text;
            artigo = artigoText.Text;
            quantidade = Convert.ToInt32(quantidadeText.Value);
            quantidadeMin = Convert.ToInt32(quantMinDiaText.Value);
            idSerie = idSerieText.Text;
        }

        private void varsClear()
        {
            idProdOrdem = "";
            artigo = "";
            quantidade = 0;
            quantidadeMin = 0;
            idSerie = "";

            idOrdProdText.Text = "";
            artigoText.Text = "";
            quantidadeText.Value = 0;
            quantMinDiaText.Value = 0;
            idSerieText.Text = "";
        }

        private bool canGoBd()
        {
            //rfid.startInitialPage();
            
            //if (rfid._ISConnected)
            {
                if (string.IsNullOrEmpty(idProdOrdem) || string.IsNullOrEmpty(artigo) || quantidade == 0)
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                    return false;
                }
                else if (!db.modelCanInsertV2(idProdOrdem, idSerie))
                {
                    MessageBox.Show("ID ordem produção ou ID serie já usados");
                    return false;
                }
                else if (!rfidConnected())
                {
                    MessageBox.Show("Leitor RFID não esta ligado!");
                    return false;
                }
                else
                {
                    // Adiciona ao banco de dados se todos os campos estiverem preenchidos
                    db.modelAddToBd(idProdOrdem, idSerie, artigo, quantidade, quantidadeMin);
                    return true;
                }
            }
        }

        private bool rfidConnected()
        {
            rfid.Connect();
            if (rfid._ISConnected)
            {
                rfid.Disconnect();
                return true;
            }
            else
            {
                return false;
            }
        }


        private void showAviso()
        {
            avisoForm aviso = new avisoForm();
            aviso.Show();
        }


        private void clearVars_Click(object sender, EventArgs e)
        {
            varsClear();
        }

        private void showDbButton_Click(object sender, EventArgs e)
        {
            bool isBdFormOpen = Application.OpenForms["allDataBaseAcess"] as Form != null;

            if (!isBdFormOpen)
            {
                allDataBaseAcess db = new allDataBaseAcess();
                db.Show();
            }
            //RETIRAR O ELSE
            else
            {
                MessageBox.Show("Já existe uma janela de acesso à base de dados aberta.");
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfidReader.ActiveForm.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.PrintConfig(iniPath);
        }

        private void initialPage_Load(object sender, EventArgs e)
        {
            
        }
    }
}