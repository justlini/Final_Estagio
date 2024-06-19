using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace CS_RFID3_Host_Sample2
{
    public partial class LockForm : Form
    {
        private const int NUM_MEMORY_BANKS = 5;
        private AppForm m_AppForm;
        private LOCK_DATA_FIELD m_LockDataField;
        private LOCK_PRIVILEGE m_LockPrivilege;
        internal TagAccess.LockAccessParams m_LockParams;

        public LockForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_LockParams = new TagAccess.LockAccessParams();
            m_LockParams.AccessPassword = 0;

            m_LockDataField = LOCK_DATA_FIELD.LOCK_EPC_MEMORY;
            m_LockPrivilege = LOCK_PRIVILEGE.LOCK_PRIVILEGE_READ_WRITE;
        }

        private void Lock_Load(object sender, EventArgs e)
        {
            if (m_AppForm.inventoryList.SelectedItems.Count > 0)
            {
                ListViewItem item = m_AppForm.inventoryList.SelectedItems[0];
                tagID_TB.Text = item.Text;
            }
            else
            {
                tagID_TB.Text = "";
            }
            this.memBank_CB.SelectedIndex = (int)m_LockDataField;
            this.lockPrivilege_CB.SelectedIndex = (int)m_LockPrivilege;
            this.Password_TB.Text = m_LockParams.AccessPassword.ToString("X");
        }

        private void accessFilterButton_Click(object sender, EventArgs e)
        {
            m_AppForm.m_AccessFilterForm.ShowDialog(this);
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            m_LockParams.LockPrivilege = new LOCK_PRIVILEGE[NUM_MEMORY_BANKS];
            try
            {
                if (tagID_TB.Text.Length == 0 && m_AppForm.m_AccessFilterForm.getFilter() == null)
                {
                    m_AppForm.functionCallStatusLabel.Text = "No TagID or Access Filter is defined";
                    return;
                }
                m_LockParams.AccessPassword = 0;
                if (Password_TB.Text.Length > 0)
                {
                    string password = Password_TB.Text;
                    if (password.StartsWith("0x"))
                    {
                        password = password.Substring(2, password.Length - 2);
                    }
                    m_LockParams.AccessPassword = uint.Parse(
                        password, System.Globalization.NumberStyles.HexNumber);   
                 
                }
                lockButton.Enabled = false;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message.ToString();
                lockButton.Enabled = true;
            }
            m_LockDataField = (LOCK_DATA_FIELD)memBank_CB.SelectedIndex;
            m_LockPrivilege = (LOCK_PRIVILEGE)lockPrivilege_CB.SelectedIndex;

            m_LockParams.LockPrivilege[memBank_CB.SelectedIndex]
                = (LOCK_PRIVILEGE)lockPrivilege_CB.SelectedIndex;
            m_AppForm.m_SelectedTagID = this.tagID_TB.Text;

            m_AppForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK);
            
        }

        private void taID_TB_TextChanged(object sender, EventArgs e)
        {
            if (tagID_TB.Text.Length == 0 && !accessFilterButton.Enabled)
            {
                accessFilterButton.Enabled = true;
            }
            else if (tagID_TB.Text.Length > 0 && accessFilterButton.Enabled)
            {
                accessFilterButton.Enabled = false;
            }
        }
    }
}