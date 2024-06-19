using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;
using System.Threading;

namespace CS_RFID3_Host_Sample2
{
    public partial class FirmwareUpdateForm : Form
    {
        private AppForm m_AppForm;
        private int m_percentage;
        private string m_updateDesc;

        public FirmwareUpdateForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            Reset();
        }

        internal void Reset()
        {
            update_CB.Items.Clear();
            if (m_AppForm.m_ReaderType == READER_TYPE.MC)
            {
                update_CB.Items.Add("Radio Firmware Update");
                update_CB.Items.Add("Radio Config Update");
                update_CB.SelectedIndex = 0;
                ftp_GB.Enabled = false;
                username_TB.Enabled = false;
                password_TB.Enabled = false;
                this.Text = "Radio Firmware/Config Update";
            }
            else
            {
                update_CB.Visible = false;
                ftp_GB.Enabled = true;
                username_TB.Enabled = true;
                password_TB.Enabled = true;
                this.Text = "Software Update";
            }
        }
        private void firmwareApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                updateBackgroundWorker.RunWorkerAsync("StartUpdate");
            }
            catch (OperationFailureException ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message.ToString();
            }
        }

        private void updateWorker(DoWorkEventArgs workEventArgs)
        {
            try
            {
                Symbol.RFID3.UpdateStatus updateStatus;

                if (m_AppForm.m_ReaderType == READER_TYPE.MC)
                {
                    if (update_CB.SelectedIndex == 0)
                    {
                        // Do Radio Firmware Update
                        m_AppForm.m_ReaderMgmt.RadioFirmwareUpdate.Update(location_TB.Text);
                    }
                    else
                    {
                        // Do Radio Config Update
                        m_AppForm.m_ReaderMgmt.RadioConfigUpdate.Update(location_TB.Text);
                    }
                }
                else
                {
                    SoftwareUpdateInfo info = new SoftwareUpdateInfo(
                        location_TB.Text, username_TB.Text, password_TB.Text);
                    m_AppForm.m_ReaderMgmt.SoftwareUpdate.Update(info);
                }

                uint updatePercent = 0;
                while (updatePercent < 100)
                {
                    try
                    {
                        if (this.m_AppForm.m_ReaderType == READER_TYPE.MC)
                        {
                            if (this.update_CB.SelectedIndex == 1)
                                updateStatus = m_AppForm.m_ReaderMgmt.RadioFirmwareUpdate.UpdateStatus;
                            else
                                updateStatus = m_AppForm.m_ReaderMgmt.RadioConfigUpdate.UpdateStatus;
                        }
                        else
                        {
                            updateStatus = m_AppForm.m_ReaderMgmt.SoftwareUpdate.UpdateStatus;
                        }
                        updatePercent = updateStatus.Percentage;
                        m_percentage = (int)updatePercent;
                        m_updateDesc = updateStatus.UpdateInfo;
                        DisplayUpdateStatus();
                        Thread.Sleep(1000);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        workEventArgs.Result = "UpdateStatus failed " + ioe.ToString();
                        break;
                    }
                    catch (InvalidUsageException iue)
                    {
                        workEventArgs.Result = "UpdateStatus failed " + iue.ToString();
                        break;
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.StatusDescription;
                        break;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message.ToString();
                        break;
                    }
                }
                if (updatePercent == 100)
                {
                    workEventArgs.Result = "Update Completed";
                }
            }
            catch (OperationFailureException ex)
            {
                workEventArgs.Result = ex.VendorMessage;
            }

        }
        private void DisplayUpdateStatus()
        {
            if (!InvokeRequired)
            {

                update_PB.Value = m_percentage;
                updateDesc_TB.Text = m_updateDesc;
            }
            else
            {
                Invoke(new ThreadStart(DisplayUpdateStatus));
            }
        }

        private void updateBackgroundWorker_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            updateBackgroundWorker.ReportProgress(0, workEventArgs.Argument);

            if ((string)workEventArgs.Argument == "StartUpdate")
            {
                updateWorker(workEventArgs);
            }
        }

        private void updateBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs eventArgs)
        {
            updateDesc_TB.Text =  m_AppForm.functionCallStatusLabel.Text = eventArgs.Result.ToString();
            firmwareApplyButton.Enabled = true;
            location_TB.Enabled = true;
            username_TB.Enabled = true;
            password_TB.Enabled = true;
        }


        private void updateBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs progressEventArgs)
        {
            m_AppForm.functionCallStatusLabel.Text = "Starting update";
            firmwareApplyButton.Enabled = false;
            location_TB.Enabled = false;
            username_TB.Enabled = false;
            password_TB.Enabled = false;
        }

        private void FirmwareUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}