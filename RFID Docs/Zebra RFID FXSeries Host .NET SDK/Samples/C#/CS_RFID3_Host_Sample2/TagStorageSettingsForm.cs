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
    public partial class TagStorageSettingsForm : Form
    {
        private AppForm m_AppForm;
        private TagStorageSettings m_Settings;

        public TagStorageSettingsForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            Reset();
        }

        public void Reset()
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    m_Settings = m_AppForm.m_ReaderAPI.Config.GetTagStorageSettings(); 
                    maxCount_TB.Text = m_Settings.MaxTagCount.ToString();
                    idLength_TB.Text = m_Settings.MaxTagIDLength.ToString();
                    memoryBankSize_TB.Text = m_Settings.MaxSizeMemoryBank.ToString();
           
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void TagStorageSettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                maxCount_TB.Text = m_Settings.MaxTagCount.ToString();
                idLength_TB.Text = m_Settings.MaxTagIDLength.ToString();
                memoryBankSize_TB.Text = m_Settings.MaxSizeMemoryBank.ToString();
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void storageApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    m_Settings.MaxSizeMemoryBank = uint.Parse(memoryBankSize_TB.Text);
                    m_Settings.MaxTagCount = uint.Parse(maxCount_TB.Text);
                    m_Settings.MaxTagIDLength = uint.Parse(idLength_TB.Text);
                    if (checkBoxPhaseInfo.Checked)
                        m_Settings.TagFields |= TAG_FIELD.PHASE_INFO;
                    else
                        m_Settings.TagFields &= ~TAG_FIELD.PHASE_INFO;
                    m_AppForm.m_ReaderAPI.Config.SetTagStorageSettings(m_Settings);
                    m_AppForm.functionCallStatusLabel.Text = "Set Tag Storage Settings Successfully";
                    this.Close();
                }
            }
            catch (InvalidUsageException iue)
            {
                m_AppForm.functionCallStatusLabel.Text = iue.VendorMessage;
            }
            catch (OperationFailureException ofe)
            {
                m_AppForm.functionCallStatusLabel.Text = ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }
    }
}