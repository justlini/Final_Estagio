using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace CS_RFID3_Host_Sample1
{
    public partial class ReadForm : Form
    {
        private AppForm m_AppForm;
        internal TagAccess.ReadAccessParams m_ReadParams = null;

        public ReadForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_ReadParams = new TagAccess.ReadAccessParams();
            m_ReadParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_USER;
            m_ReadParams.AccessPassword = 0;
            m_ReadParams.ByteOffset = 0;
            m_ReadParams.ByteCount= 0;
        }

        private void Read_Load(object sender, EventArgs e)
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
            this.ReadData_TB.Text = "";
            this.memBank_CB.SelectedIndex = (int)m_ReadParams.MemoryBank;
            this.Password_TB.Text = m_ReadParams.AccessPassword.ToString("X");
            this.offset_TB.Text = m_ReadParams.ByteOffset.ToString();
            this.length_TB.Text = m_ReadParams.ByteCount.ToString();
        }

        private void readButton_Click(object sender, EventArgs e)
        {            
            try
            {
                if (tagID_TB.Text.Length == 0)
                {
                    m_AppForm.functionCallStatusLabel.Text = "No TagID is defined";
                    return;
                }
                string accessPassword = this.Password_TB.Text;
                m_ReadParams.AccessPassword = 0;
                if (accessPassword.Length > 0)
                {
                    if (accessPassword.StartsWith("0x"))
                    {
                        accessPassword = accessPassword.Substring(2, accessPassword.Length - 2);
                    }
                    m_ReadParams.AccessPassword = uint.Parse(
                        accessPassword, System.Globalization.NumberStyles.HexNumber);                
                }
                
                m_ReadParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;
                m_ReadParams.ByteOffset = ushort.Parse(this.offset_TB.Text);
                m_ReadParams.ByteCount = ushort.Parse(this.length_TB.Text);

                ReadData_TB.Text = "";
                m_AppForm.m_SelectedTagID = this.tagID_TB.Text;
                m_AppForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ);
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            readButton.Enabled = false;
        }

        private void offset_TB_TextChanged(object sender, EventArgs e)
        {
            if (this.offset_TB.Text.Length > 0)
            {
                m_ReadParams.ByteOffset = ushort.Parse(this.offset_TB.Text);
            }
        }

        private void memBank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_ReadParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;
        }

        private void length_TB_TextChanged(object sender, EventArgs e)
        {
            if (this.length_TB.Text.Length > 0)
                m_ReadParams.ByteCount = ushort.Parse(this.length_TB.Text);
        }
    }
}