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
    public partial class KillForm : Form
    {
        private AppForm m_AppForm;
        internal TagAccess.KillAccessParams m_KillParams;


        public KillForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_KillParams = new TagAccess.KillAccessParams();
            m_KillParams.KillPassword = 0;
        }

        private void Kill_Load(object sender, EventArgs e)
        {
            if (m_AppForm.inventoryList.SelectedItems.Count > 0)
            {
                ListViewItem item = m_AppForm.inventoryList.SelectedItems[0];
                this.tagID_TB.Text = item.Text;
            }
            else
            {
                this.tagID_TB.Text = "";
            }
            this.killPwd_TB.Text = m_KillParams.KillPassword.ToString("X");
        }

        private void accessFilterButton_Click(object sender, EventArgs e)
        {
            m_AppForm.m_AccessFilterForm.ShowDialog(this);
        }

        private void killButton_Click(object sender, EventArgs e)
        {            
            try
            {
                if (tagID_TB.Text.Length == 0 && m_AppForm.m_AccessFilterForm.getFilter() == null)
                {
                    m_AppForm.functionCallStatusLabel.Text = "No TagID or Access Filter is defined";
                    return;
                }
                m_KillParams.KillPassword = 0;
                if (this.killPwd_TB.Text.Length > 0)
                {
                    string killPassword = this.killPwd_TB.Text;                
                    if (killPassword.StartsWith("0x"))
                    {
                        killPassword = killPassword.Substring(2);
                    }
                    m_KillParams.KillPassword = uint.Parse(killPassword, System.Globalization.NumberStyles.HexNumber);
                }
                m_AppForm.m_SelectedTagID = this.tagID_TB.Text;

                m_AppForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL);
                killButton.Enabled = false;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }           
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
    }
}