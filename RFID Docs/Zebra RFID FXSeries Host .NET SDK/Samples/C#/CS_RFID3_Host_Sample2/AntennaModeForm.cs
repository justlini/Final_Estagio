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
    public partial class AntennaModeForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsLoaded;

        public AntennaModeForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_IsLoaded = false;
        }

        private void antModeApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppForm.m_ReaderMgmt.AntennaMode = (ANTENNA_MODE)(antMode_CB.SelectedIndex);
                m_AppForm.functionCallStatusLabel.Text = "Set Antenna Mode Successfully";
            }
            catch (InvalidUsageException iue)
            {
                m_AppForm.functionCallStatusLabel.Text = iue.VendorMessage;
            }
            catch (OperationFailureException ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Result.ToString();
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void AntennaModeForm_Load(object sender, EventArgs e)
        {
            if (!m_IsLoaded)
            {
                try
                {
                    antMode_CB.SelectedIndex = (int)m_AppForm.m_ReaderMgmt.AntennaMode;
                    m_IsLoaded = true;
                }
                catch (OperationFailureException ex)
                {
                    m_AppForm.functionCallStatusLabel.Text = ex.Result.ToString();
                    this.Close();
                }
                catch (Exception ex)
                {
                    m_AppForm.functionCallStatusLabel.Text = ex.Message;
                    this.Close();
                }
            }
        }
    }
}