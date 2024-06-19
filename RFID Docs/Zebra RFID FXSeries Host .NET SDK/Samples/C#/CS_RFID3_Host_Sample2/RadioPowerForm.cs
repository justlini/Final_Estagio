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
    public partial class RadioPowerForm : Form
    {
        private AppForm m_AppForm;

        public RadioPowerForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        private void radioPowerApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
                {
                    m_AppForm.m_ReaderAPI.Config.RadioPowerState = (RADIO_POWER_STATE)(radioState_CB.SelectedIndex);
                    m_AppForm.functionCallStatusLabel.Text = "Set Radio Power Successfully";
                }
                else
                {
                    m_AppForm.functionCallStatusLabel.Text = "Radio Power Not Supported";
                    this.Close();
                }
            }
            catch (OperationFailureException ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Result.ToString();
            }
            this.Close();
        }

        private void RadioPower_Load(object sender, EventArgs e)
        {
            if (m_AppForm.m_IsConnected)
            {
                if (m_AppForm.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
                {
                    try
                    {
                        radioState_CB.SelectedIndex = (int)m_AppForm.m_ReaderAPI.Config.RadioPowerState;
                    }
                    catch (OperationFailureException ex)
                    {
                        m_AppForm.functionCallStatusLabel.Text = ex.Result.ToString();
                        this.Close();
                    }
                }
                else
                {
                    m_AppForm.functionCallStatusLabel.Text = "Radio Power Not Supported";
                    this.Close();
                }
            }
            else
            {
                m_AppForm.functionCallStatusLabel.Text = "Please connect to a reader";
                this.Close();
            }
        }
    }
}