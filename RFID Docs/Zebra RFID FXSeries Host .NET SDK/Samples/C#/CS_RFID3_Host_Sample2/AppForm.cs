using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Symbol.RFID3;
using System.Net;
using System.Net.Sockets;

namespace CS_RFID3_Host_Sample2
{
    public partial class AppForm : Form
    {
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsConnected;
        internal ReaderManagement m_ReaderMgmt;
        internal READER_TYPE m_ReaderType;

        internal AccessFilterForm m_AccessFilterForm;
        internal AntennaInfoForm m_AntennaInfoForm;
        internal ConnectionForm m_ConnectionForm;
        internal LoginForm m_LoginForm;
        internal AntennaModeForm m_AntennaModeForm;
        internal ReadPointForm m_ReadPointForm;
        internal FirmwareUpdateForm m_FirmwareUpdateForm;
        internal ReaderInfoForm m_ReaderInfoForm;

        internal PreFilterForm m_PreFilterForm;
        internal PostFilterForm m_PostFilterForm;
        internal ReadForm m_ReadForm;
        internal WriteForm m_WriteForm;
        internal LockForm m_LockForm;
        internal KillForm m_KillForm;
        internal WriteForm m_BlockWriteForm;
        internal BlockEraseForm m_BlockEraseForm;
        internal LocateForm m_LocateForm;
        internal AccessOperationResult m_AccessOpResult;
        internal TriggersForm m_TriggerForm;
        internal TagStorageSettingsForm m_TagStorageSettingsForm;
        internal Socket m_ListeningSocket = null, m_AcceptedSocket = null;

        internal ArrayList m_GPIStateList;
        internal string m_SelectedTagID = "";

        private delegate void UpdateStatus(Events.StatusEventData eventData);
        private UpdateStatus m_UpdateStatusHandler = null;
        private delegate void UpdateRead(Events.ReadEventData eventData);
        private UpdateRead m_UpdateReadHandler = null;
        private TagData m_ReadTag = null;
        private Hashtable m_TagTable;
        private int m_SortColumn = -1;
        private uint m_TagTotalCount;
        private Socket m_ReaderSocket;

        internal class AccessOperationResult
        {
            public RFIDResults m_Result;
            public String m_VendorMessage;
            public String m_StatusDescription;
            public ACCESS_OPERATION_CODE m_OpCode;

            public AccessOperationResult()
            {
                m_Result = RFIDResults.RFID_NO_ACCESS_IN_PROGRESS;
                m_OpCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ;
            }
        }

        internal class ListViewItemComparer : IComparer
        {
            private int m_Coloumn;
            private SortOrder m_Order;
            public ListViewItemComparer()
            {
                m_Coloumn = 0;
                m_Order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                m_Coloumn = column;
                m_Order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[m_Coloumn].Text,
                    ((ListViewItem)y).SubItems[m_Coloumn].Text);
                if (m_Order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }

        public AppForm()
        {
            InitializeComponent();
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ReadTag = new Symbol.RFID3.TagData();

            m_ConnectionForm = new ConnectionForm(this);
            m_ReadForm = new ReadForm(this);
            m_AntennaInfoForm = new AntennaInfoForm(this);
            m_PostFilterForm = new PostFilterForm(this);
            m_AccessFilterForm = new AccessFilterForm(this);
            m_TriggerForm = new TriggersForm(this);
            m_ReaderMgmt = new ReaderManagement();
            m_TagTable = new Hashtable();
            m_AccessOpResult = new AccessOperationResult();
            m_IsConnected = false;
            m_TagTotalCount = 0;
            configureMenuItemsUponConnectDisconnect();
        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Stop Reading";
                    memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Start Reading";
                    memBank_CB.Enabled = true;

                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Stop Reading";
                    memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Start Reading";
                    memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.TEMPERATURE_ALARM_EVENT:
                    functionCallStatusLabel.Text = "Temperature Alarm " + eventData.TemperatureAlarmEventData.SourceName.ToString() + " Temperature " + eventData.TemperatureAlarmEventData.CurrentTemperature.ToString() + " Level " + eventData.TemperatureAlarmEventData.AlarmLevel.ToString();
                    break;
                default:
                    break;
            }
        }

        private void myUpdateRead(Events.ReadEventData eventData)
        {
            Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
            if (tagData != null)
            {
                for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                {
                    if (tagData[nIndex].ContainsLocationInfo)
                    {
                        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance; 
                    }

                    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                    {
                        Symbol.RFID3.TagData tag = tagData[nIndex];
                        string tagID = tag.TagID;
                        bool isFound = false;

                        lock (m_TagTable.SyncRoot)
                        {
                            isFound = m_TagTable.ContainsKey(tagID);
                            if (!isFound && this.memBank_CB.SelectedIndex >=1)
                            {
                                tagID = tag.TagID + tag.MemoryBank.ToString()
                                    + tag.MemoryBankDataOffset.ToString();
                                isFound = m_TagTable.ContainsKey(tagID);
                            }
                        }

                        if (isFound)
                        {
                            uint count = 0;
                            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                            try
                            {
                                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                            }
                            catch (FormatException fe)
                            {
                                functionCallStatusLabel.Text = fe.Message;
                                break;
                            }
                            item.SubItems[2].Text = tag.AntennaID.ToString();
                            item.SubItems[3].Text = count.ToString();
                            item.SubItems[4].Text = tag.PeakRSSI.ToString();
                            item.SubItems[5].Text = GetPhaseInDegree(tag.PhaseInfo);

                            string memoryBank = tag.MemoryBank.ToString();
                            int index = memoryBank.LastIndexOf('_');
                            if (index != -1)
                            {
                                memoryBank = memoryBank.Substring(index + 1);
                            }
                            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[6].Text))
                            {
                                item.SubItems[7].Text = tag.MemoryBankData;
                                item.SubItems[8].Text = memoryBank;
                                item.SubItems[9].Text = tag.MemoryBankDataOffset.ToString();

                                lock (m_TagTable.SyncRoot)
                                {
                                    m_TagTable.Remove(tagID);
                                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        + tag.MemoryBankDataOffset.ToString(), item);
                                }
                            }
                            item.SubItems[1].Text = getTagEvent(tag);

                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(tag.TagID);
                            // 1 - tag event
                            ListViewItem.ListViewSubItem subItem;
                            subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
                            item.SubItems.Add(subItem);
                            // 2 - antenna ID
                            subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                            item.SubItems.Add(subItem);
                            // 3 - tag seen count
                            subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                            m_TagTotalCount += tag.TagSeenCount;
                            item.SubItems.Add(subItem);
                            // 4 - RSSI
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                            item.SubItems.Add(subItem);
                            // 5 - phase
                            subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(tag.PhaseInfo));
                            item.SubItems.Add(subItem);
                            // 6 - PC bits
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                            item.SubItems.Add(subItem);
                            
                            if (memBank_CB.SelectedIndex >= 1)
                            {
                                // 7 - Memory bank data
                                subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                item.SubItems.Add(subItem);

                                string memoryBank = tag.MemoryBank.ToString();
                                int index = memoryBank.LastIndexOf('_');
                                if (index != -1)
                                {
                                    memoryBank = memoryBank.Substring(index + 1);
                                }

                                // 8 - Memory Bank
                                subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                item.SubItems.Add(subItem);

                                // 9 - memory bank offset
                                subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                item.SubItems.Add(subItem);
                            }
                            else
                            {
                                subItem = new ListViewItem.ListViewSubItem(item, "");
                                item.SubItems.Add(subItem);
                                subItem = new ListViewItem.ListViewSubItem(item, "");
                                item.SubItems.Add(subItem);
                                subItem = new ListViewItem.ListViewSubItem(item, "");
                                item.SubItems.Add(subItem);
                            }
                            // 10 - Brand ID check status
                            if (checkBoxEnableBrandIDCheck.Checked)
                            {
                                if (tag.BrandValid != 0)
                                {
                                    subItem = new ListViewItem.ListViewSubItem(item, "Passed");
                                }
                                else
                                {
                                    subItem = new ListViewItem.ListViewSubItem(item, "Failed");
                                }
                                item.SubItems.Add(subItem);
                            }
                            inventoryList.BeginUpdate();
                            inventoryList.Items.Add(item);
                            inventoryList.EndUpdate();

                            lock (m_TagTable.SyncRoot)
                            {
                                m_TagTable.Add(tagID, item);
                            }
                        }
                    }
                }
                totalTagValueLabel.Text = m_TagTable.Count + "(" + m_TagTotalCount + ")";
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler, new object[] { readEventArgs.ReadEventData.TagData});
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        private void accessBackgroundWorker_DoWork(object sender, DoWorkEventArgs accessEvent)
        {
            
            try
            {
                m_AccessOpResult.m_OpCode = (ACCESS_OPERATION_CODE)accessEvent.Argument;
                m_AccessOpResult.m_Result = RFIDResults.RFID_API_SUCCESS;
                
                if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReadTag = m_ReaderAPI.Actions.TagAccess.ReadWait(
                        m_SelectedTagID, m_ReadForm.m_ReadParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.ReadEvent(m_ReadForm.m_ReadParams,
                            m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.WriteWait(
                            m_SelectedTagID, m_WriteForm.m_WriteParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.WriteEvent(
                            m_WriteForm.m_WriteParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.LockWait(
                            m_SelectedTagID, m_LockForm.m_LockParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.LockEvent(
                            m_LockForm.m_LockParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.KillWait(
                            m_SelectedTagID, m_KillForm.m_KillParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.KillEvent(
                            m_KillForm.m_KillParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockWriteWait(
                            m_SelectedTagID, m_BlockWriteForm.m_WriteParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockWriteEvent(
                            m_BlockWriteForm.m_WriteParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockEraseWait(
                            m_SelectedTagID, m_BlockEraseForm.m_BlockEraseParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockEraseEvent(
                            m_BlockEraseForm.m_BlockEraseParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AccessOpResult.m_Result = ofe.Result;
                m_AccessOpResult.m_StatusDescription = ofe.StatusDescription;
                m_AccessOpResult.m_VendorMessage = ofe.VendorMessage;
            }
            catch (InvalidUsageException ex)
            {
                m_AccessOpResult.m_Result = RFIDResults.RFID_API_PARAM_ERROR;
                m_AccessOpResult.m_StatusDescription = ex.Info;
                m_AccessOpResult.m_VendorMessage = ex.VendorMessage;
            }

            accessEvent.Result = m_AccessOpResult;
        }

        private void accessBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs pce)
        {

        }

        private void accessBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs accessEvents)
        {
            if (accessEvents.Error != null)
            {
                functionCallStatusLabel.Text = accessEvents.Error.Message;
                //reset button state if an exception is captured (e.g InvalidUsageException)
                resetButtonState();
                memBank_CB.Enabled = true;
            }
            else
            {
                // Handle AccessWait Operations              
                AccessOperationResult accessOpResult = (AccessOperationResult)accessEvents.Result;
                if (accessOpResult.m_Result == RFIDResults.RFID_API_SUCCESS)
                {
                    if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                    {
                        if (m_SelectedTagID != String.Empty)
                        {
                            if (m_ReadTag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                m_ReadTag.OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS)
                            {
                                if (inventoryList.Items.Count > 0 && inventoryList.SelectedItems.Count > 0) // ensure that a tag item is currently selected in the TagListView
                                {
                                    ListViewItem item = inventoryList.SelectedItems[0];
                                    string tagID = m_ReadTag.TagID + m_ReadTag.MemoryBank.ToString()
                                        + m_ReadTag.MemoryBankDataOffset.ToString();

                                    if (item.SubItems[6].Text.Length > 0)
                                    {
                                        bool isFound = false;

                                        // Search or add new one
                                        lock (m_TagTable.SyncRoot)
                                        {
                                            isFound = m_TagTable.ContainsKey(tagID);
                                        }

                                        if (!isFound)
                                        {
                                            ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
                                            // 1 - tagEvent (New, Invisible, Back to Visible 
                                            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(newItem, getTagEvent(m_ReadTag));
                                            m_TagTotalCount += m_ReadTag.TagSeenCount;
                                            newItem.SubItems.Add(subItem);
                                            // 2 - Antenna ID
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.AntennaID.ToString());
                                            newItem.SubItems.Add(subItem);
                                            // 3 - tag Seent count 
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.TagSeenCount.ToString());
                                            newItem.SubItems.Add(subItem);
                                            // 4 - RSSI
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PeakRSSI.ToString());
                                            newItem.SubItems.Add(subItem);
                                            // 5 - Phase
                                            subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(m_ReadTag.PhaseInfo));
                                            newItem.SubItems.Add(subItem);
                                            // 6 - PC bits
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PC.ToString("X"));
                                            newItem.SubItems.Add(subItem);
                                            // 7 - Memory Bank Data
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankData);
                                            newItem.SubItems.Add(subItem);

                                            string memoryBank = m_ReadTag.MemoryBank.ToString();
                                            int index = memoryBank.LastIndexOf('_');
                                            if (index != -1)
                                            {
                                                memoryBank = memoryBank.Substring(index + 1);
                                            }
                                            // 8 - Memory Bank
                                            subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                            newItem.SubItems.Add(subItem);

                                            // 9 - Memory Bank Offset
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankDataOffset.ToString());
                                            newItem.SubItems.Add(subItem);

                                            // 10 - Brand ID check status
                                            if (checkBoxEnableBrandIDCheck.Checked)
                                            {
                                                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.BrandValid.ToString());
                                                newItem.SubItems.Add(subItem);
                                            }
                                            inventoryList.BeginUpdate();
                                            inventoryList.Items.Add(newItem);
                                            inventoryList.EndUpdate();

                                            lock (m_TagTable.SyncRoot)
                                            {
                                                m_TagTable.Add(tagID, newItem);
                                            }
                                        }
                                        else
                                        {
                                            item.SubItems[7].Text = m_ReadTag.MemoryBankData;
                                            item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();
                                        }
                                    }
                                    else
                                    {
                                        // Empty Memory Bank Slot
                                        item.SubItems[6].Text = m_ReadTag.MemoryBankData;

                                        string memoryBank = m_ReadForm.m_ReadParams.MemoryBank.ToString();
                                        int index = memoryBank.LastIndexOf('_');
                                        if (index != -1)
                                        {
                                            memoryBank = memoryBank.Substring(index + 1);
                                        }
                                        item.SubItems[8].Text = memoryBank;
                                        item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();

                                        lock (m_TagTable.SyncRoot)
                                        {
                                            m_TagTable.Remove(m_ReadTag.TagID);
                                            m_TagTable.Add(tagID, item);
                                        }
                                    }
                                }   
                             
                                this.m_ReadForm.ReadData_TB.Text = m_ReadTag.MemoryBankData;
                                functionCallStatusLabel.Text = "Read Succeed";
                                
                            }
                        }
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                    {
                        functionCallStatusLabel.Text = "Write Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                    {
                        functionCallStatusLabel.Text = "Lock Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                    {
                        functionCallStatusLabel.Text = "Kill Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                    {
                        functionCallStatusLabel.Text = "BlockWrite Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                    {
                        functionCallStatusLabel.Text = "BlockErase Succeed";
                    }
                }
                else
                {
                    functionCallStatusLabel.Text = accessOpResult.m_StatusDescription + " [" + accessOpResult.m_VendorMessage + "]";
                }
                resetButtonState();
                memBank_CB.Enabled = true;
            }
        }

        private void resetButtonState()
        {
            if (m_ReadForm != null)
                m_ReadForm.readButton.Enabled = true;
            if (m_WriteForm != null)
                m_WriteForm.writeButton.Enabled = true;
            if (m_LockForm != null)
                m_LockForm.lockButton.Enabled = true;
            if (m_KillForm != null)
                m_KillForm.killButton.Enabled = true;
            if (m_BlockWriteForm != null)
                m_BlockWriteForm.writeButton.Enabled = true;
            if (m_BlockEraseForm != null)
                m_BlockEraseForm.eraseButton.Enabled = true;
        }

        internal void configureMenuItemsUponConnectDisconnect()
        {
            this.autonomous_CB.Enabled = this.m_IsConnected;
            this.memBank_CB.Enabled = this.m_IsConnected;
            this.capabilitiesToolStripMenuItem.Enabled = this.m_IsConnected;
            this.antennaInfoToolStripMenuItem.Enabled = this.m_IsConnected;
            this.antennaToolStripMenuItem.Enabled = this.m_IsConnected;
            this.rFModesToolStripMenuItem.Enabled = this.m_IsConnected;
            this.singulationToolStripMenuItem.Enabled = this.m_IsConnected;
            this.gpioToolStripMenuItem.Enabled = this.m_IsConnected;
            this.resetToFactoryDefaultsToolStripMenuItem.Enabled = this.m_IsConnected;
            this.storageSettingsToolStripMenuItem.Enabled = this.m_IsConnected;
            this.filtersToolStripMenuItem.Enabled = this.m_IsConnected;
            this.accessToolStripMenuItem.Enabled = this.m_IsConnected;
            this.triggersToolStripMenuItem.Enabled = this.m_IsConnected;
            if (this.m_ReaderAPI != null && this.m_IsConnected && this.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                    "Power On Radio" : "Power Off Radio";
            }
            else
            {
                this.radioPowerGetSetToolStripMenuItem.Visible = false;
            }

        }
        internal void configureMenuItemsUponLoginLogout()
        {
           this.softwareFirmwareUpdateToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;

            if (this.m_ReaderType != READER_TYPE.MC)
            {
                this.antennaModeToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.readPointToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.rebootToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.softwareFirmwareUpdateToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.systemInfoToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
            }
            else
            {
                this.antennaModeToolStripMenuItem.Enabled = false;
                this.readPointToolStripMenuItem.Enabled = false;
                this.rebootToolStripMenuItem.Enabled = false;
                this.systemInfoToolStripMenuItem.Enabled = false;
            }
            //this.systemInfoToolStripMenuItem.Visible = false; // Dlg Not implemented now
        }
        internal void configureMenuItemsBasedOnCapabilities()
        {            
            this.autonomousMode_CB.Visible = this.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            m_TriggerForm.Reset();  
            this.radioPowerGetSetToolStripMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported;
            this.gpioToolStripMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.NumGPIPorts > 0 ? true : false |
            this.m_ReaderAPI.ReaderCapabilities.NumGPOPorts > 0 ? true : false; 
            this.blockEraseDataContextMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
            this.blockWriteDataContextMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;
          

            this.m_TriggerForm.newTag_CB.Enabled =
            this.m_TriggerForm.newTag_TB.Enabled =
            this.m_TriggerForm.backTag_CB.Enabled =
            this.m_TriggerForm.backTag_TB.Enabled =
            this.m_TriggerForm.invisibleTag_CB.Enabled =
            this.m_TriggerForm.invisibleTag_TB.Enabled = this.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;

        }
        
        private void connectBackgroundWorker_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            connectBackgroundWorker.ReportProgress(0, workEventArgs.Argument);

            if ((string)workEventArgs.Argument == "Connect")
            {
                m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);

                // Check for secure connection
                if(m_ConnectionForm.secureModeCheckBox.Checked)
                {
                    m_ReaderAPI.SecureConnectionInfo = new SecureConnectionInfo();
                    m_ReaderAPI.SecureConnectionInfo.SecureMode = true;
                    m_ReaderAPI.SecureConnectionInfo.ValidatePeerCert = m_ConnectionForm.validatePeerCertCheckBox.Checked;

                    if (File.Exists(m_ConnectionForm.CertFilePath))
                    {
                        m_ReaderAPI.SecureConnectionInfo.ClientCertBuff = System.IO.File.ReadAllText(m_ConnectionForm.CertFilePath);
                    }

                    if (File.Exists(m_ConnectionForm.PrivateKeyFilePath))
                    {
                        m_ReaderAPI.SecureConnectionInfo.ClientKeyBuff = System.IO.File.ReadAllText(m_ConnectionForm.PrivateKeyFilePath);
                    }
                    if (File.Exists(m_ConnectionForm.RootCertFilePath))
                    {
                        m_ReaderAPI.SecureConnectionInfo.RootCertBuff = System.IO.File.ReadAllText(m_ConnectionForm.RootCertFilePath);
                    }
                    
                    m_ReaderAPI.SecureConnectionInfo.PhraseBuff = m_ConnectionForm.KeyPassPhrase;                    
                 }

                try
                {
                    m_ReaderAPI.Connect();
                    m_IsConnected = true;
                    workEventArgs.Result = "Connect Succeed";
                }
                catch (OperationFailureException operationException)
                  {
                      workEventArgs.Result = operationException.StatusDescription;
                  }
                  
                catch (Exception ex)
                {
                    workEventArgs.Result = ex.Message;
                }
            }
            else if ((string)workEventArgs.Argument == "Disconnect")
            {
                try
                {
                    m_ReaderAPI.Disconnect();
                    m_IsConnected = false;
                    workEventArgs.Result = "Disconnect Succeed";
                    m_ReaderAPI = null;

                }
                catch (OperationFailureException ofe)
                {
                    workEventArgs.Result = ofe.Result;
                }
            }
        }

        private void connectBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs progressEventArgs)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs connectEventArgs)
        {
            if (m_ConnectionForm.connectionButton.Text == "Connect")
            {
                if (connectEventArgs.Result.ToString() == "Connect Succeed")
                {
                    /*
                     *  UI Updates
                     */
                    m_ConnectionForm.connectionButton.Text = "Disconnect";
                    m_ConnectionForm.hostname_TB.Enabled = false;
                    m_ConnectionForm.port_TB.Enabled = false;
                    m_ConnectionForm.Close();
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Start Reading";
                    blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                    blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                    // Disable all the controls for secure connection
                    m_ConnectionForm.secureModeCheckBox.Enabled = false;
                    m_ConnectionForm.validatePeerCertCheckBox.Enabled = false;
                    m_ConnectionForm.certFilePath_TB.Enabled = false;
                    m_ConnectionForm.certFilePathBrowseButton.Enabled = false;
                    m_ConnectionForm.privateKeyFilePath_TB.Enabled = false;
                    m_ConnectionForm.privateKeyFileBrowseButton.Enabled = false;
                    m_ConnectionForm.keyPassPhrase_TB.Enabled = false;
                    m_ConnectionForm.rootCertFilePath_TB.Enabled = false;
                    m_ConnectionForm.rootCertFilePathBrowseButton.Enabled = false;
                    
                    /*
                     *  Events Registration
                     */
                    m_ReaderAPI.Actions.PreFilters.DeleteAll();

                    m_ReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                    m_ReaderAPI.Events.AttachTagDataWithReadEvent = false;
                    m_ReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                    m_ReaderAPI.Events.NotifyGPIEvent = true;
                    m_ReaderAPI.Events.NotifyAntennaEvent = true;
                    m_ReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStartEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStopEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStartEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStopEvent = true;
                    m_ReaderAPI.Events.NotifyReaderExceptionEvent = true;
                    m_ReaderAPI.Events.NotifyTemperatureAlarmEvent = true;

                    this.Text = "Connected to " + m_ConnectionForm.IpText;
                    this.connectionStatus.BackgroundImage =
                        global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                    configureMenuItemsUponConnectDisconnect();
                    configureMenuItemsBasedOnCapabilities();
                }
            }
            else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
            {
                if (connectEventArgs.Result.ToString() == "Disconnect Succeed")
                {
                }
                this.Text = "CS_RFID3_Host_Sample2";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                m_ConnectionForm.connectionButton.Text = "Connect";
                m_ConnectionForm.hostname_TB.Enabled = true;
                m_ConnectionForm.port_TB.Enabled = true;
                this.readButton.Enabled = false;
                this.readButton.Text = "Start Reading";
                configureMenuItemsUponConnectDisconnect();
                m_IsConnected = false;

                // Enable all the controls for secure connection
                m_ConnectionForm.secureModeCheckBox.Enabled = true;
                if (m_ConnectionForm.secureModeCheckBox.Checked)
                {
                    m_ConnectionForm.validatePeerCertCheckBox.Enabled = true;
                    m_ConnectionForm.certFilePath_TB.Enabled = true;
                    m_ConnectionForm.certFilePathBrowseButton.Enabled = true;
                    m_ConnectionForm.privateKeyFilePath_TB.Enabled = true;
                    m_ConnectionForm.privateKeyFileBrowseButton.Enabled = true;
                    m_ConnectionForm.keyPassPhrase_TB.Enabled = true;
                    m_ConnectionForm.rootCertFilePath_TB.Enabled = true;
                    m_ConnectionForm.rootCertFilePathBrowseButton.Enabled = true;                    
                }

            }
            functionCallStatusLabel.Text = connectEventArgs.Result.ToString();
            m_ConnectionForm.connectionButton.Enabled = true;

            updateGPIState();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            // GPI States
            for (int index = 0; index < 8; index++)
            {
                int tabIndex = 1;
                Label gpiStateLabel = new System.Windows.Forms.Label();
                gpiStateLabel.AutoSize = true;
                gpiStateLabel.BackColor = System.Drawing.Color.Transparent;
                gpiStateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                gpiStateLabel.Location = new System.Drawing.Point(86 + (index * 33), 16);
                gpiStateLabel.Name = "GPI States " + index;
                gpiStateLabel.Size = new System.Drawing.Size(15, 15);
                gpiStateLabel.TabIndex = tabIndex++;
                gpiStateLabel.Text = "  ";
                autonomous_CB.Controls.Add(gpiStateLabel);
                m_GPIStateList.Add(gpiStateLabel);

                int name = index + 1;
                Label gpiStateNumLabel = new System.Windows.Forms.Label();
                gpiStateNumLabel.AutoSize = true;
                gpiStateNumLabel.Font = new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    8.25F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
                gpiStateNumLabel.Location = new System.Drawing.Point(86 + (index * 33), 38);
                gpiStateNumLabel.Name = "label" + index;
                gpiStateNumLabel.Size = new System.Drawing.Size(241, 13);
                gpiStateNumLabel.TabIndex = tabIndex++;
                gpiStateNumLabel.Text = name.ToString();
                autonomous_CB.Controls.Add(gpiStateNumLabel);
            }
            configureMenuItemsUponConnectDisconnect();
            //connectBackgroundWorker.RunWorkerAsync("Connect");        
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_IsConnected)
                {
                    connectBackgroundWorker.RunWorkerAsync("Disconnect");
                }
                m_ReaderMgmt.Dispose();
                this.Dispose();
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_ConnectionForm.ShowDialog(this);
        }

        private void capabilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapabilitiesForm capabilitiesForm = new CapabilitiesForm(this);
            capabilitiesForm.ShowDialog(this);
        }

        private void antennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AntennaConfigForm antennaConfigForm = new AntennaConfigForm(this);
            antennaConfigForm.ShowDialog(this);
        }

        private void rFModesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RFModeForm RFModeForm = new RFModeForm(this);
            RFModeForm.ShowDialog(this);
        }

        private void singulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingulationForm singulationForm = new SingulationForm(this);
            singulationForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ReaderAPI != null && m_IsConnected)
            {
				connectBackgroundWorker.RunWorkerAsync("Disconnect");
            }
            if (this.m_ReaderMgmt.IsLoggedIn)
            {
                m_ReaderMgmt.Logout();
            }
            this.Dispose();
        }

        private void storageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_TagStorageSettingsForm)
            {
                m_TagStorageSettingsForm = new TagStorageSettingsForm(this);
            }
            m_TagStorageSettingsForm.ShowDialog(this);
        }

        private void gpioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPIOForm gpio = new GPIOForm(this);
            gpio.ShowDialog(this);
        }

        private void preFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_PreFilterForm)
            {
                m_PreFilterForm = new PreFilterForm(this);
            }
            m_PreFilterForm.ShowDialog(this);
        }

        private void postfilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_PostFilterForm.ShowDialog(this);
        }

        private void accessfilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_AccessFilterForm.ShowDialog(this);
        }

        private void triggersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_TriggerForm)
            {
                m_TriggerForm = new TriggersForm(this);
            }
            m_TriggerForm.ShowDialog(this);
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReadForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = "Read Form:" + ex.Message;
            }
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new WriteForm(this, false);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_LockForm)
            {
                m_LockForm = new LockForm(this);
            }
            m_LockForm.ShowDialog(this);
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_KillForm)
            {
                m_KillForm = new KillForm(this);
            }
            m_KillForm.ShowDialog(this);
        }

        private void blockWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockWriteForm)
            {
                m_BlockWriteForm = new WriteForm(this, true);
            }
            m_BlockWriteForm.ShowDialog(this);
        }

        private void blockEraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockEraseForm)
            {
                m_BlockEraseForm = new BlockEraseForm(this);
            }
            m_BlockEraseForm.ShowDialog(this);
        }

        private void softwareFirmwareUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_FirmwareUpdateForm)
            {
                m_FirmwareUpdateForm = new FirmwareUpdateForm(this);
            }
            m_FirmwareUpdateForm.ShowDialog(this);
        }

        private void antennaModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_AntennaModeForm)
            {
                m_AntennaModeForm = new AntennaModeForm(this);
            }
            m_AntennaModeForm.ShowDialog(this);
        }

        private void readPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_ReadPointForm)
            {
                m_ReadPointForm = new ReadPointForm(this);
            }
            m_ReadPointForm.ShowDialog(this);
        }

        private void radioPowerGetSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioPowerGetSetToolStripMenuItem.Text == "Power On Radio")
                {
                    m_ReaderAPI.Config.RadioPowerState = RADIO_POWER_STATE.ON;
                }
                else
                {
                    m_ReaderAPI.Config.RadioPowerState = RADIO_POWER_STATE.OFF;
                }
                
                this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                    "Power On Radio" : "Power Off Radio";

  
            }
            catch (OperationFailureException ex)
            {
                functionCallStatusLabel.Text = ex.Result.ToString();
            }
        }

        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReaderMgmt.Restart();

                this.antennaModeToolStripMenuItem.Enabled = false;
                this.rebootToolStripMenuItem.Enabled = false;
                this.radioPowerGetSetToolStripMenuItem.Enabled = false;
                this.readPointToolStripMenuItem.Enabled = false;
                this.softwareFirmwareUpdateToolStripMenuItem.Enabled = false;
                this.m_IsConnected = false;

                m_LoginForm.loginButton.Text = "Login";
                functionCallStatusLabel.Text = "Reboot Successfully";
            }
            catch (OperationFailureException failureException)
            {
                functionCallStatusLabel.Text = failureException.Result.ToString();
            }           
        }

        private void loginLogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_LoginForm == null)
            {
                m_LoginForm = new LoginForm(this);
            }
            m_LoginForm.clearPassword();
            m_LoginForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpDialog = new HelpForm(this);
            if (helpDialog.ShowDialog(this) == DialogResult.Yes)
            {

            }
            helpDialog.Dispose();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_IsConnected)
                {
                    if (readButton.Text == "Start Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else if(checkBoxEnableBrandIDCheck.Checked)
                        {
                            ushort brandIDToCheck = Convert.ToUInt16(textBoxBrandID.Text, 16);
                            inventoryList.Items.Clear();
                            m_TagTable.Clear();
                            m_TagTotalCount = 0;

                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.BrandIdChk.Perform(
                                m_PostFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(),
                                m_AntennaInfoForm.getInfo(),
                                brandIDToCheck);
                        }
                        else
                        {
                            inventoryList.Items.Clear();
                            m_TagTable.Clear();
                            m_TagTotalCount = 0;

                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.Inventory.Perform(
                                m_PostFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(),
                                m_AntennaInfoForm.getInfo());
                        }

                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;

                    }
                    else if (readButton.Text == "Stop Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        else if (checkBoxEnableBrandIDCheck.Checked)
                        {
                            m_ReaderAPI.Actions.BrandIdChk.Stop();
                        }
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        readButton.Text = "Start Reading";
                        memBank_CB.Enabled = true;
                    }
                }
                else
                {
                    functionCallStatusLabel.Text = "Please connect to a reader first";
                }
            }
            catch (InvalidOperationException ioe)
            {
                functionCallStatusLabel.Text = ioe.Message;
            }
            catch (InvalidUsageException iue)
            {
                functionCallStatusLabel.Text = iue.Info;
            }
            catch (OperationFailureException ofe)
            {
                functionCallStatusLabel.Text = ofe.Result + ":" + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        void inventoryList_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataContextMenuStrip.Show(inventoryList, new Point(e.X, e.Y));
            }
        }

        void inventoryList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (e.Column != this.m_SortColumn)
            {
                m_SortColumn = e.Column;
                inventoryList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (inventoryList.Sorting == SortOrder.Ascending)
                    inventoryList.Sorting = SortOrder.Descending;
                else
                    inventoryList.Sorting = SortOrder.Ascending;
            }
            this.inventoryList.Sort();
            this.inventoryList.ListViewItemSorter = new ListViewItemComparer(e.Column, inventoryList.Sorting);
        }

        private void tagDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagDataForm tagDataForm = new TagDataForm(this);
            tagDataForm.ShowDialog(this);
        }

        private void readDataContextMenuItem_Click(object sender, EventArgs e)
        {
            m_ReadForm.ShowDialog(this);
        }

        private void writeDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new WriteForm(this, false);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void lockDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_LockForm)
            {
                m_LockForm = new LockForm(this);
            }
            m_LockForm.ShowDialog(this);
        }

        private void killDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_KillForm)
            {
                m_KillForm = new KillForm(this);
            }
            m_KillForm.ShowDialog(this);
        }

        private void blockWriteDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockWriteForm)
            {
                m_BlockWriteForm = new WriteForm(this, true);
            }
            m_BlockWriteForm.ShowDialog(this);
        }

        private void blockEraseDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockEraseForm)
            {
                m_BlockEraseForm = new BlockEraseForm(this);
            }
            m_BlockEraseForm.ShowDialog(this);
        }

        private void updateGPIState()
        {
            try
            {
                if (m_IsConnected)
                {
                    for (int index = 0; index < 8; index++)
                    {
                        if (index < m_ReaderAPI.ReaderCapabilities.NumGPIPorts)
                        {
                            Label gpiLabel = (Label)m_GPIStateList[index];
                            GPIs.GPI_PORT_STATE portState = m_ReaderAPI.Config.GPI[index + 1].PortState;

                            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.Red;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                            {

                            }
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < 8; index++)
                    {
                        ((Label)m_GPIStateList[index]).BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void resetToFactoryDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ReaderAPI.IsConnected)
                {
                    m_ReaderAPI.Config.ResetFactoryDefaults();
                    if(m_TagStorageSettingsForm != null)
                        m_TagStorageSettingsForm.Reset();
                    functionCallStatusLabel.Text = "Reset Factory Defaults Successfully";
                }
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void clearReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.inventoryList.Items.Clear();
            this.m_TagTable.Clear();
        }

        private void antennaInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_AntennaInfoForm.ShowDialog(this);
        }

        private void memBank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_ReaderAPI.Actions.TagAccess.OperationSequence.DeleteAll();
                if (memBank_CB.SelectedIndex >= 1)
                {
                    TagAccess.Sequence.Operation op = new TagAccess.Sequence.Operation();
                    op.AccessOperationCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ;
                    op.ReadAccessParams.MemoryBank = (MEMORY_BANK)memBank_CB.SelectedIndex - 1;
                    op.ReadAccessParams.ByteCount = 0;
                    op.ReadAccessParams.ByteOffset = m_ReadForm.m_ReadParams.ByteOffset;
                    op.ReadAccessParams.AccessPassword = m_ReadForm.m_ReadParams.AccessPassword;
                    m_ReaderAPI.Actions.TagAccess.OperationSequence.Add(op);
                }
            }
        }

        private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_ReaderInfoForm)
            {
                m_ReaderInfoForm = new ReaderInfoForm(this);
            }
            m_ReaderInfoForm.ShowDialog(this);
        }

        private void autonomousCB_CheckedChanged(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                autonomousMode_CB.Checked = autonomousMode_CB.Checked &&
                (m_IsConnected &&
                    m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported);
            }
        }

        private void clearReports_CB_CheckedChanged(object sender, EventArgs e)
        {
            this.totalTagValueLabel.Text = "0(0)";
            m_TagTotalCount = 0;
            this.inventoryList.Items.Clear();
            this.m_TagTable.Clear();          
            clearReports_CB.Checked = false;      
        }

        private void AppForm_ClientSizeChanged(object sender, EventArgs e)
        {
            functionCallStatusLabel.Width = this.Width - 77;
        }

        private string getTagEvent(TagData tag)
        {
            string eventString = "None";
            if (tag.TagEvent != TAG_EVENT.NONE)
            {
                switch (tag.TagEvent)
                {
                    case TAG_EVENT.NEW_TAG_VISIBLE:
                        eventString = "New";
                        break;
                    case TAG_EVENT.TAG_BACK_TO_VISIBILITY:
                        eventString = "Back";
                        break;
                    case TAG_EVENT.TAG_NOT_VISIBLE:
                        eventString = "Gone";
                        break;
                    case TAG_EVENT.TAG_MOVING:
                        eventString = "Moving";
                        break;
                    case TAG_EVENT.TAG_STATIONARY:
                        eventString = "Stationary";
                        break;
                    default:
                        eventString = "None";
                        break;

                }
                
            }
            return eventString;
        }

        private void locateTagDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_LocateForm)
            {
                m_LocateForm = new LocateForm(this);
            }
            m_LocateForm.ShowDialog(this);
        }

        private string GetPhaseInDegree(short phase)
        {
            double PhaseInfo = (180.0 / 32767) * phase;
            return PhaseInfo.ToString("#0.00#");
        }
		
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_ReaderAPI != null && this.m_IsConnected && this.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                    "Power On Radio" : "Power Off Radio";
            }
        }
    }
}