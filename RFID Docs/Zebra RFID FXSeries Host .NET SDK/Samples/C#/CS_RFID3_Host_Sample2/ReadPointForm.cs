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
    public partial class ReadPointForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsLoaded;

        public ReadPointForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_IsLoaded = false;
        }

        private void ReadPointForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected && !m_IsLoaded)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    
                    if (antID.Length > 0)
                    {
                        foreach (ushort id in antID)
                            antennaID_CB.Items.Add(id);
                        antennaID_CB.SelectedIndex = 0;
                    }
                    m_IsLoaded = true;
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void antennaID_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    readPoint_CB.SelectedIndex =
                        (int)m_AppForm.m_ReaderMgmt.ReadPoint.GetReadPointStatus(antID[antennaID_CB.SelectedIndex]);
                    m_AppForm.functionCallStatusLabel.Text = "Get Read Point Successfully";
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void readPointButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppForm.m_ReaderMgmt.ReadPoint.SetReadPointStatus(
                  (ushort)Int16.Parse(antennaID_CB.Text),
                    (READPOINT_STATUS)readPoint_CB.SelectedIndex);
                m_AppForm.functionCallStatusLabel.Text = "Set Read Point Successfully";
                this.Close();
            }
            catch (InvalidUsageException iue)
            {
                m_AppForm.functionCallStatusLabel.Text = iue.VendorMessage;
            }
            catch (OperationFailureException fe)
            {
                m_AppForm.functionCallStatusLabel.Text = fe.Result.ToString();
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }
    }
}