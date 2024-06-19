using System;
using System.Collections;
using System.Data;
using System.Threading;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;
using System.IO;
using Symbol.RFID3;
using static Symbol.RFID3.Events;
using Newtonsoft.Json;
using System.Data.SqlClient;
using static Fase4.jsonConfig;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;
using Fase4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fase4
{
    public partial class rfidReader : Form
    {

        dbHelper db = new dbHelper();

        private string jsonPath = @".\config_DB_JSON.json";
        private string iniPath = "config.ini";
        private bool _IsConnecting = false;
        public bool _ISConnected = false;
        public RFIDReader _RFIDReaderAPI;
        private bool _IsReading = false;

        //--Tag Count--//
        private int readCount = 0;
        private int tagCount = 0;

        private STATUS_EVENT_TYPE _RFIDEventStatus;

        //--Event Status--//
        private delegate void _UpdateStatus(Events.StatusEventData e);
        private delegate void _UpdateReader(Events.ReadEventData e);
        private _UpdateReader _UpdateReaderHandler;
        private Hashtable _TagTable;

        private TriggerInfo _TriggerInfo;
        private TagStorageSettings _TagStorageSettings;
        private bool rfidIsReading = true;
        private bool firstClick = false;


        private string postoAntena;

        public bool isOpen;

        private bool canInsertRead =  false;

        public bool IsReading { get; private set; }
        public int RSSIValueSet { get; set; }
        public bool RSSIEnable { get; set; }

        internal class TagModel
        {
            public string EPCCode { get; set; }
            public string AntennaID { get; set; }
            public string TIDCode { get; set; }
            public sbyte RSSIValue { get; set; }
            public DateTime FirstSeenTimeStamp { get; set; }
        }

        public rfidReader()
        {
            InitializeComponent();
            tagDataView.RowTemplate.Height = 26;
            // Adicionando colunas
            tagDataView.Columns.Add("Column1", "EPC IP");
            tagDataView.Columns.Add("Column2", "Antenna ID");
            tagDataView.Columns.Add("Column3", "Tag ID");
            tagDataView.Columns.Add("Column4", "RSSI");
            tagDataView.Columns.Add("Column5", "Data Leitura");
            tagDataView.Columns.Add("Column6", "Hora Leitura");
        }

        private void rfidReader_Load(object sender, EventArgs e)
        {
            LerConfiguracoes(jsonPath);
            Connect();

            getVarsModelo();

            timer1.Start();
            //-+-+-++-+--+-+-+
            _UpdateReaderHandler = new _UpdateReader(ActionRead);
            _TagTable = new Hashtable();
            StartReadding();
            //---color---//
            pictureBox1.BackColor = System.Drawing.Color.Green;
            //+-+-++-+--+-+-+
        }
        private void rfidReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hours_label.Text = DateTime.Now.ToString("HH:mm:ss");
            date_label.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        //-------------------------------------------ficheiro INI-------------------------------------------//

        //confiSettings class para armazenar as configurações do ficheiro INI
        public class ConfigSettings
        {
            public string IP { get; set; }
            public int Port { get; set; }
            public string DataSource { get; set; }
            public bool RSSIEnable { get; set; }
            public int RSSIValueSet { get; set; }
        }

        //ConfigManager class para carregar e imprimir as configurações do ficheiro INI
        public class ConfigManager
        {
            public ConfigSettings LoadConfig(string filePath)
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(filePath);

                return new ConfigSettings
                {
                    IP = data["Connection"]["IP"],
                    Port = int.Parse(data["Connection"]["Port"]),
                    DataSource = data["Database"]["DataSource"],
                    RSSIEnable = bool.Parse(data["ReadSettings"]["RSSIEnable"]),
                    RSSIValueSet = int.Parse(data["ReadSettings"]["RSSIValueSet"])
                };
            }

            //Método para imprimir as configurações do ficheiro INI
            public void PrintConfig(string filePath)
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(filePath);

                string configText = $"[Connection]\nIP: {data["Connection"]["IP"]}\nPort: {data["Connection"]["Port"]}\n\n" +
                                    $"[ReadSettings]\nRSSIEnable: {data["ReadSettings"]["RSSIEnable"]}\nRSSIValueSet: {data["ReadSettings"]["RSSIValueSet"]}";

                MessageBox.Show(configText, "Configurações do Sistema");
            }
        }

        //------------------------------------------- fim ficheiro INI-------------------------------------------//


        //-------------------------------------------ficheiro JSON-------------------------------------------//
        
        public Rootobject LerConfiguracoes(string filePath)
        {
            string fileName = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Rootobject>(fileName);
        }

        //connect() para conectar ao leitor RFID
        public bool Connect()
        {
            if (!_IsConnecting)
            {
                try
                {
                    _IsConnecting = true;
                    read_button.Enabled = true;
                    //clearDB_button.Enabled = true;
                    insertDB_button.Enabled = true;
                    ConfigManager configManager = new ConfigManager();
                    ConfigSettings configSettings = configManager.LoadConfig(iniPath);
                    _RFIDReaderAPI = new RFIDReader(configSettings.IP, (uint)configSettings.Port, 0);

                    if (_RFIDReaderAPI != null)
                    {
                        _RFIDReaderAPI.Connect();
                        if (!_RFIDReaderAPI.IsConnected)
                        {
                            IsReading = false;
                            return false;
                        }

                        //Set the settings for the RFID Reader
                        _RFIDReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                        _RFIDReaderAPI.Events.AttachTagDataWithReadEvent = false;
                        _RFIDReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                        _RFIDReaderAPI.Events.ReadNotify += Events_ReadNotify;
                        _RFIDReaderAPI.Events.AttachTagDataWithReadEvent = false;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyGPIEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderExceptionEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStopEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStopEvent = true;
                        _RFIDReaderAPI.Events.NotifyAntennaEvent = true;

                        _ISConnected = true;

                        return _RFIDReaderAPI.IsConnected;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CONNECTION ERROR: " + ex.Message);
                    read_button.Enabled = false;
                    //clearDB_button.Enabled = false;
                    insertDB_button.Enabled = false;
                    return false;
                }
                finally
                {
                    _IsConnecting = false;
                }
            }
            return false;
        }

        //disconnect() para desconectar do leitor RFID
        public bool Disconnect()
        {
            if (_RFIDReaderAPI == null) return true;
            try
            {
                if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                }
                else
                {
                    _RFIDReaderAPI.Actions.Inventory.Stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
            }
            try
            {
                _RFIDReaderAPI.Disconnect();
                bool temp = _RFIDReaderAPI.IsConnected;
                _RFIDReaderAPI = null;
                read_button.Enabled = false;
                read_button.Text = "Start Reading";
                //clearDB_button.Enabled = true;
                insertDB_button.Enabled = false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
                return false;
            }
            finally
            {
                _ISConnected = false;
            }
        }

        //ReadNotify() para receber os dados da tag
        private void Events_ReadNotify(object sender, Events.ReadEventArgs e)
        {
            _UpdateReaderHandler.Invoke(e.ReadEventData);
        }

        //StatusNotify() para receber os eventos do leitor RFID
        public void Events_StatusNotify(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                _RFIDEventStatus = statusEventArgs.StatusEventData.StatusEventType;
                switch (_RFIDEventStatus)
                {
                    case STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                        UpdateRichTextBox("Inventory Start Event");
                        break;
                    case STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                        UpdateRichTextBox("Inventory Stop Event");
                        break;
                    case STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                        UpdateRichTextBox("Access Start Event");
                        break;
                    case STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                        UpdateRichTextBox("Access Stop Event");
                        break;
                    case STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                        UpdateRichTextBox("Buffer Full Warning Event");
                        break;
                    case STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                        UpdateRichTextBox("Buffer Full Event");
                        break;
                    case STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                        UpdateRichTextBox("Disconnection Event");
                        break;
                    case STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                        UpdateRichTextBox("Reader Exception Event");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("STATUS NOTIFY ERRORS: " + ex.Message);
            }

        }

        //UpdateRichTextBox() para atualizar o texto na caixa de texto
        private void UpdateRichTextBox(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() => { textBox1.Text = message; }));
            }
            else
            {
                textBox1.Text = message;
            }
        }

        //StartReadding() para iniciar a leitura das tags
        public bool StartReadding()
        {
            _IsReading = false;
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    //Setting Memorybank
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length <= 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.DeleteAll();
                        var operation = new TagAccess.Sequence.Operation
                        {
                            AccessOperationCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ
                        };
                        operation.ReadAccessParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_TID;
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.Add(operation);
                    }
                    //
                    //Start operation
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.PurgeTags();
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(new AccessFilter(), _TriggerInfo, new AntennaInfo());
                        IsReading = true;
                        //_IsTrigger = false;//MinhChau.Nguyen: Reset trigger params
                        Console.WriteLine("Start Read: " + IsReading);

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start Readding Fail: " + ex.Message);
                return false;
            }
        }

        //ActionRead() para receber os dados da tag
        private void ActionRead(Events.ReadEventData e)
        {
            //_IsDetectedTag = true;
            var tagData = _RFIDReaderAPI.Actions.GetReadTags(500);
            if (tagData != null)
            {
                foreach (var tag in tagData)
                {
                    if (tag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                       (tag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        tag.OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                    {
                        var tagID = tag.TagID;
                        var keyTag = tagID;
                        var isFound = false;

                        Console.WriteLine("===> " + tag.MemoryBankData.ToString() + "+_TagTable: " + _TagTable.Count);
                        lock (_TagTable.SyncRoot) // lock sync access to hashtable
                        {
                            keyTag = tag.TagID + tag.MemoryBankData.ToString();
                            isFound = _TagTable.ContainsKey(keyTag);
                        }

                        if (isFound)
                        {
                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                                FirstSeenTimeStamp = DateTime.Now,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                                AddItemToDataGridView(item);
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                                AddItemToDataGridView(item);
                            }
                        }
                        else
                        {
                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                                FirstSeenTimeStamp = DateTime.Now,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                AddItemToDataGridView(item);
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                AddItemToDataGridView(item);
                            }
                        }
                    }
                }
            }
        }

        //AddItemToDataGridView() para adicionar os dados da tag na tabela
        private void AddItemToDataGridView(TagModel item)
        {
            ConfigManager configManager = new ConfigManager();
            ConfigSettings configSettings = configManager.LoadConfig(iniPath);
            BeginInvoke(new MethodInvoker(() =>
            { // Se o RSSI da tag for menor que o valor de RSSI definido, remove a linha correspondente na tabela
                if (clear_checkBox.Checked && item.RSSIValue < configSettings.RSSIValueSet)
                {
                    // Encontra e remove a linha correspondente na tabela
                    foreach (DataGridViewRow row in tagDataView.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == item.EPCCode)
                        {
                            tagDataView.Rows.Remove(row);
                            return;
                        }
                    }
                }
               else if (item.RSSIValue > configSettings.RSSIValueSet)
                {
                    //se a tag já existe na tabela, apenas atualiza o RSSI a antennaID e o tempo de leitura data e hora
                    foreach (DataGridViewRow row in tagDataView.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == item.EPCCode)
                        {
                            row.Cells[1].Value = item.AntennaID;
                            row.Cells[3].Value = item.RSSIValue;
                            row.Cells[4].Value = item.FirstSeenTimeStamp.ToString("yyyy-MM-dd");
                            row.Cells[5].Value = item.FirstSeenTimeStamp.ToString("HH:mm:ss");
                            readCount++;
                            updateTagCountLabel();
                            return;
                        }
                    }
                    // Adiciona uma nova linha à DataGridView
                    int rowIndex = tagDataView.Rows.Add();

                    // Define os valores nas células correspondentes
                    tagDataView.Rows[rowIndex].Cells["Column1"].Value = item.EPCCode;
                    tagDataView.Rows[rowIndex].Cells["Column2"].Value = item.AntennaID;
                    tagDataView.Rows[rowIndex].Cells["Column3"].Value = item.TIDCode;
                    tagDataView.Rows[rowIndex].Cells["Column4"].Value = item.RSSIValue;
                    tagDataView.Rows[rowIndex].Cells["Column5"].Value = item.FirstSeenTimeStamp.ToString("yyyy-MM-dd");
                    tagDataView.Rows[rowIndex].Cells["Column6"].Value = item.FirstSeenTimeStamp.ToString("HH:mm:ss");
                    
                    //variaveis para enviar para a base de dados
                    int antenaId = Convert.ToInt32(item.AntennaID);
                    string epcCode = item.EPCCode;
                    string tidCode = item.TIDCode;
                    int rssiValue = item.RSSIValue;
                    string dataLeitura = item.FirstSeenTimeStamp.ToString("dd/MM/yyyy");
                    string horaLeitura = item.FirstSeenTimeStamp.ToString("HH:mm:ss");
                    
                    string idSerie = textIdSerie.Text;
                    string idProdOrd = textIdOrdProd.Text;
                    int quantity = int.Parse(textQuantidade.Text);

                    if (idProdOrd != "" && db.rfidCanInsert(antenaId, tidCode))
                    {
                        db.rfidAddToBd(antenaId, tidCode, epcCode, rssiValue, dataLeitura, horaLeitura);
                        //db.readAddToBd(idSerie, tidCode, postoAntena, idProdOrd, antenaId, quantity, dataLeitura, horaLeitura);
                        if (db.readCanInsert(antenaId, tidCode))
                        {
                            string postoAntena = postByAntenna(tidCode);
                            db.readAddToBd(idSerie, tidCode, postoAntena, idProdOrd, antenaId, quantity, dataLeitura, horaLeitura);
                        }
                    }
                    
                    tagCount++;

                   

                    updateTagCountLabel();
                    compareQuantWithTagRead();
                }
            }));
        }

        //StopReadding() para parar a leitura das tags
        public bool StopReadding()
        {
            _IsReading = true;
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();

                        Console.WriteLine("Stop Read: " + !IsReading);

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Stop Readding Fail: " + ex.Message);

                return false;
            }
        }

        //updateTagCountLabel() para atualizar o contador de tags
        private void updateTagCountLabel()
        {
            readCountLabel.Invoke((MethodInvoker)delegate
            {
                //readCountLabel.Text = $"Nº of readings: {tagCount} ({readCount})";
                readCountLabel.Text = $"Nº de Leituras: {tagCount}";
            });
        }
        
        //---Eventos---//
        private void read_button_Click(object sender, EventArgs e)
        {
            

            if (!firstClick)
            {
                firstClick = true;

                rfidIsReading = false;
                _UpdateReaderHandler = new _UpdateReader(ActionRead);
                _TagTable = new Hashtable();
                StartReadding();
                read_button.Text = "Parar leitura";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Green;
            }

            if (rfidIsReading)
            {
                rfidIsReading = false;
                _UpdateReaderHandler = new _UpdateReader(ActionRead);
                _TagTable = new Hashtable();
                StartReadding();
                read_button.Text = "Parar leitura";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Green;
            }
            else if (!rfidIsReading)
            {
                rfidIsReading = true;
                StopReadding();
                read_button.Text = "Retomar leitura";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Red;
            }
            else if (!_RFIDReaderAPI.IsConnected)
            {
                Console.WriteLine("Please connect to the reader first!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            //limparDB();
            rfidReader.ActiveForm.Close();
        }

        private void insertDB_button_Click(object sender, EventArgs e)
        {
            bool isBdFormOpen = Application.OpenForms["editorDeTabela"] as Form != null;

            if (!isBdFormOpen)
            {
                editorDeTabela allDb = new editorDeTabela();
                allDb.Show();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.PrintConfig(iniPath);
        }

        private void clear_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clear_checkBox.Checked)
            {
                tagDataView.Rows.Clear();
                updateTagCountLabel();
            }
        }

        private void viewBd_btn_Click(object sender, EventArgs e)
        {
            bool isBdFormOpen = Application.OpenForms["editorDeTabela"] as Form != null;

            if (!isBdFormOpen)
            {
                allDataBaseAcess allDb = new allDataBaseAcess();
                allDb.Show();
            }
        }

        private void getVarsModelo()
        {
            textIdOrdProd.Text = initialPage.instance.idProdOrdem;
            textArtigo.Text = initialPage.instance.artigo;
            textQuantidade.Text = Convert.ToString(initialPage.instance.quantidade);
            textQuantMin.Text = Convert.ToString(initialPage.instance.quantidadeMin);
            textIdSerie.Text = initialPage.instance.idSerie;
        }

        private void compareQuantWithTagRead()
        {
            int quant = Convert.ToInt32(textQuantidade.Text);
            if (tagCount >= quant && quant != 0)
            {   
                Disconnect();
                MessageBox.Show("A quantidade pretendida para este produto foi completa. A retornar para selecionar novos dados");    
                this.Close();
            }
        }

        //INFORMAÇÕES SOBRE O POSTO

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
