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
    public partial class WriteForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsBlockWrite;
        internal TagAccess.WriteAccessParams m_WriteParams;

        public WriteForm(AppForm appForm, bool isBlockWrite)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_IsBlockWrite = isBlockWrite;
            if (m_IsBlockWrite)
                this.Text = "Block Write Tags";
            else
                this.Text = "Write Tags";
            m_WriteParams = new TagAccess.WriteAccessParams();
            m_WriteParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_USER;
            m_WriteParams.AccessPassword = 0;
            m_WriteParams.ByteOffset = 0;
            m_WriteParams.WriteDataLength = 0;
            writeButton.Enabled = true;
        }

        private void Write_Load(object sender, EventArgs e)
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
            this.memBank_CB.SelectedIndex = (int)m_WriteParams.MemoryBank;
            this.Password_TB.Text = m_WriteParams.AccessPassword.ToString("X");
            this.offset_TB.Text = m_WriteParams.ByteOffset.ToString();
            this.length_TB.Text = m_WriteParams.WriteDataLength.ToString();
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ushort length = ushort.Parse(this.length_TB.Text);
                
                if (tagID_TB.Text.Length == 0 && m_AppForm.m_AccessFilterForm.getFilter() == null)
                {
                    m_AppForm.functionCallStatusLabel.Text = "No TagID or Access Filter is defined";
                    return;
                }
                else if (length * 2 > data_TB.Text.Length)
                {
                    m_AppForm.functionCallStatusLabel.Text = "Data length has to be a word size (2X)";
                    return;
                }
                else if (length % 2 != 0)
                {
                    m_AppForm.functionCallStatusLabel.Text = "Data length has to be a even number";
                    return;
                }
                else
                {
                    m_AppForm.functionCallStatusLabel.Text = "";
                }

                string accessPassword = this.Password_TB.Text;
                m_WriteParams.AccessPassword = 0;
                if (accessPassword.Length > 0)
                {
                    if (accessPassword.StartsWith("0x"))
                    {
                        accessPassword = accessPassword.Substring(2, accessPassword.Length - 2);
                    }
                    m_WriteParams.AccessPassword = uint.Parse(
                        accessPassword, System.Globalization.NumberStyles.HexNumber);
                }

                m_WriteParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;
                m_WriteParams.ByteOffset = ushort.Parse(this.offset_TB.Text);
                m_WriteParams.WriteDataLength = length;

                byte[] writeData = new byte[m_WriteParams.WriteDataLength];
                for (int index = 0; index < m_WriteParams.WriteDataLength; index += 2)
                {
                    writeData[index] = byte.Parse(data_TB.Text.Substring(index * 2, 2),
                        System.Globalization.NumberStyles.HexNumber);
                    writeData[index + 1] = byte.Parse(data_TB.Text.Substring((index + 1) * 2, 2),
                        System.Globalization.NumberStyles.HexNumber);
                }
                m_WriteParams.WriteData = writeData;
                m_AppForm.m_SelectedTagID = this.tagID_TB.Text;

                if (m_IsBlockWrite)
                {
                    m_AppForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE);
                }
                else
                {
                    m_AppForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE);
                }
                writeButton.Enabled = false;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
                writeButton.Enabled = true;
            }
        }

        private void accessFilterButton_Click(object sender, EventArgs e)
        {
            m_AppForm.m_AccessFilterForm.ShowDialog(this);
        }

        private void tagID_TB_TextChanged(object sender, EventArgs e)
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

        private void memBank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_WriteParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;

            if (m_WriteParams.MemoryBank == MEMORY_BANK.MEMORY_BANK_EPC)
            {
                this.offset_TB.Text = "4";
                this.length_TB.Text = "12";
            }
            else
            {
                this.offset_TB.Text = "0";
                this.length_TB.Text = "0";
            }
        }
    }
}