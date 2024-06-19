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
using static Receber_tags_tabela_01.configJSON;
using System.Diagnostics.Eventing.Reader;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.NetworkInformation;
using static Receber_tags_tabela_01.Form1;

namespace Receber_tags_tabela_01
{
    public partial class Form1 : Form
    {
        private string jsonPath = @".\config_DB_JSON.json";
        private string iniPath = "config.ini";
        //private ReaderManagement _ReaderManagement;
        private bool _IsConnecting = false;
        private bool _ISConnected = false;
        public RFIDReader _RFIDReaderAPI;
        private bool _IsReading = false;

        //--Tag Count--//
        private int readCount = 0;
        private int tagCount = 0;

        private STATUS_EVENT_TYPE _RFIDEventStatus;
        //private Thread _ThreadDeviceStatusChecking;

        //--Event Status--//
        private delegate void _UpdateStatus(Events.StatusEventData e);
        private delegate void _UpdateReader(Events.ReadEventData e);
        private _UpdateReader _UpdateReaderHandler;
        private Hashtable _TagTable;

        private TriggerInfo _TriggerInfo;
        private TagStorageSettings _TagStorageSettings;
        //private bool _IsDetectedTag;
        //private bool _IsTrigger;

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

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LerConfiguracoes(jsonPath);
            read_button.Enabled = false;
            clearDB_button.Enabled = false;
            insertDB_button.Enabled = false;
            optionsEnabled();
        }

        //-------------------------------------------ficheiro INI-------------------------------------------//

        //confiSettings class para armazenar as configurações do ficheiro INI
        public class ConfigSettings
        {
            public string IP { get; set; }
            public int Port { get; set; }
            public string DataSource { get; set; }
            // public string DBName { get; set; }
            // public string UserID { get; set; }
            // public string Password { get; set; }
            public bool RSSIEnable { get; set; }
            // public string tabele1 { get; set; }
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

        //optionsEnabled() para ativar ou desativar as opções de conexão e desconexão
        private void optionsEnabled()
        {
            if (_ISConnected)
            {
                connectionToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
            else if (_ISConnected == false)
            {
                connectionToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
            }
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
                    clearDB_button.Enabled = true;
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

                        optionsEnabled();

                        return _RFIDReaderAPI.IsConnected;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CONNECTION ERROR: " + ex.Message);
                    read_button.Enabled = false;
                    clearDB_button.Enabled = false;
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
                clearDB_button.Enabled = true;
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
                optionsEnabled();
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
            // Executa a operação na thread UI
            BeginInvoke(new MethodInvoker(() =>
            {
                if (item.RSSIValue > configSettings.RSSIValueSet)
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
                    //SendToDB();
                    tagCount++;
                    updateTagCountLabel();
                }
                /*
                // Se o RSSI da tag for menor que o valor de RSSI definido, remove a linha correspondente na tabela
                else
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
                */
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

        //SendToDB() para enviar os dados da tag para a base de dados
        private void SendToDB()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in tagDataView.Rows)
                    {
                        string epcCode = Convert.ToString(row.Cells["Column1"].Value);
                        string antennaID = Convert.ToString(row.Cells["Column2"].Value);
                        string tidCode = Convert.ToString(row.Cells["Column3"].Value);
                        int rssiValue = Convert.ToInt32(row.Cells["Column4"].Value);
                        string dataLeitura = Convert.ToString(row.Cells["Column5"].Value);
                        string horaLeitura = Convert.ToString(row.Cells["Column6"].Value);

                        // Verificar se o EPC_Id já existe na base de dados
                        bool epcExists = false;
                        using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table1} WHERE EPC_Id = @EPC", conn))
                        {
                            checkCmd.Parameters.AddWithValue("@EPC", epcCode);
                            epcExists = (int)checkCmd.ExecuteScalar() > 0;
                        }

                        if (!epcExists)
                        {
                            // O EPC_Id não existe, então inserir novo registro
                            using (SqlCommand insertCmd = new SqlCommand($"INSERT INTO {dbconfig.tableNames.table1} (EPC_Id, Atenna_ID, T_ID, RSSI, Data_Leitura, Hora_Leitura) VALUES (@EPC, @Antenna, @TID, @RSSI, @dataLeitura, @horaLeitura)", conn))
                            {
                                insertCmd.Parameters.Add("@EPC", SqlDbType.VarChar).Value = epcCode;
                                insertCmd.Parameters.Add("@Antenna", SqlDbType.VarChar).Value = antennaID;
                                insertCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = tidCode;
                                insertCmd.Parameters.Add("@RSSI", SqlDbType.Int).Value = rssiValue;
                                insertCmd.Parameters.Add("@dataLeitura", SqlDbType.Date).Value = dataLeitura;
                                insertCmd.Parameters.Add("@horaLeitura", SqlDbType.Time).Value = horaLeitura;
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Registro com EPC_Id {epcCode} já existe na base de dados.");
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendToDB ERROR: " + ex.Message);
            }
        }


        //updateTagCountLabel() para atualizar o contador de tags
        private void updateTagCountLabel()
        {
            readCountLabel.Invoke((MethodInvoker)delegate
            {
                readCountLabel.Text = $"Nº of readings: {tagCount} ({readCount})";
            });
        }

        //limparDB() para limpar a base de dados
        private void limparDB()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM {dbconfig.tableNames.table1}", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /*
        private void UpdateDataGridView()
        {
            try
            {
                var dbconfig = LerConfiguracoes(jsonPath);
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table1}", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.Invoke((MethodInvoker)delegate 
                            {
                                dataGridView1.DataSource = dt;
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        */

        //---Eventos---//
        private void read_button_Click(object sender, EventArgs e)
        {
            if (read_button.Text == "Start Reading")
            {
                _UpdateReaderHandler = new _UpdateReader(ActionRead);
                _TagTable = new Hashtable();
                StartReadding();
                read_button.Text = "Stop Reading";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Green;
            }
            else if (read_button.Text == "Stop Reading")
            {
                StopReadding();
                read_button.Text = "Start Reading";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Red;
            }
            else if (!_RFIDReaderAPI.IsConnected)
            {
                Console.WriteLine("Please connect to the reader first!");
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Connect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            //limparDB();
            Form1.ActiveForm.Close();
        }

        private void clearDB_button_Click(object sender, EventArgs e)
        {
            tagDataView.Rows.Clear();
            limparDB();
            //UpdateDataGridView();
            readCount = 0;
            tagCount = 0;
            updateTagCountLabel();
       
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            //limparDB();
            tagDataView.Rows.Clear();
        }

        private void insertDB_button_Click(object sender, EventArgs e)
        {
            SendToDB();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.PrintConfig(iniPath);
        }
    }
}
