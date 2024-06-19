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
    public partial class TriggersForm : Form
    {
        private AppForm m_AppForm = null;
        private bool m_IsLoaded;
        private Symbol.RFID3.TriggerInfo m_TriggerInfo = null;

        public TriggersForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        public Symbol.RFID3.TriggerInfo getTriggerInfo()
        {
            if (null == m_TriggerInfo)
            {
                m_TriggerInfo = new TriggerInfo();
                Reset();
                fetchTriggerParams();
            }
            else
            {
            }
            m_TriggerInfo.EnableTagEventReport = m_AppForm.autonomousMode_CB.Checked;
            return m_TriggerInfo;
        }


        public void Reset()
        {
            newTag_CB.SelectedIndex = backTag_CB.SelectedIndex = invisibleTag_CB.SelectedIndex = 2;
            newTag_CB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            backTag_CB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            invisibleTag_CB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            newTag_TB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            backTag_TB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            invisibleTag_TB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            movingTag_TB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagMovingStationarySupported;
            movingTag_CB.Enabled = m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagMovingStationarySupported;
            movingTag_CB.SelectedIndex = 0;
        }
        private void ClearStartGroupBox()
        {
            this.startGroupBox.Controls.Remove(this.gpiParamsGroupBox);
            this.startGroupBox.Controls.Remove(this.periodicGroupBox);
            this.startGroupBox.Controls.Remove(this.startHandHeldTriggerGroupBox);
            
        }

        private void startTriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearStartGroupBox();
            if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
            {

            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
            {
                this.startGroupBox.Controls.Add(this.periodicGroupBox);
            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI)
            {
                this.startGroupBox.Controls.Add(this.gpiParamsGroupBox);

                try
                {
                    if (m_AppForm.m_ReaderAPI.IsConnected)
                    {
                        int numGPIPorts = m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPIPorts;
                        startPort_CB.Items.Clear();
                        for (int port = 1; port <= numGPIPorts; port++)
                            startPort_CB.Items.Add(port);
                        if (numGPIPorts > 0)
                            startPort_CB.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    m_AppForm.functionCallStatusLabel.Text = ex.Message;
                }
            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
            {
                this.startGroupBox.Controls.Add(this.startHandHeldTriggerGroupBox);
            }

        }

        private void ClearStopGroupBox()
        {
            this.stopGroupBox.Controls.Remove(this.durationGB);
            this.stopGroupBox.Controls.Remove(this.GPITimeoutGB);
            this.stopGroupBox.Controls.Remove(this.tagObservationGB);
            this.stopGroupBox.Controls.Remove(this.nAttemptsGB);
            this.stopGroupBox.Controls.Remove(this.stopHandHeldTriggerGroupBox);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearStopGroupBox();
            if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
            {

            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
            {
                this.stopGroupBox.Controls.Add(this.durationGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT)
            {
                try
                {
                    if (m_AppForm.m_ReaderAPI.IsConnected)
                    {
                        int numGPIPorts = m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPIPorts;
                        stopGPIPort_CB.Items.Clear();
                        for (int port = 1; port <= numGPIPorts; port++)
                            stopGPIPort_CB.Items.Add(port);
                        if (numGPIPorts > 0)                            
                            stopGPIPort_CB.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    m_AppForm.functionCallStatusLabel.Text = ex.Message;
                }

                this.stopGroupBox.Controls.Add(this.GPITimeoutGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.tagObservationGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.nAttemptsGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.stopHandHeldTriggerGroupBox);
            }


        }
        private void fetchTriggerParams()
        {
            if (null == m_TriggerInfo)
            {
                m_TriggerInfo = new TriggerInfo();
            }

            if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
            {
                m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
            {
                m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC;

                m_TriggerInfo.StartTrigger.Periodic.StartTime = startDate_PK.Value.ToUniversalTime();
                m_TriggerInfo.StartTrigger.Periodic.Period = uint.Parse(startPeriod_TB.Text);
            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI)
            {
                m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
                m_TriggerInfo.StartTrigger.GPI.PortNumber = startPort_CB.SelectedIndex + 1;
                if (lowToHigh_CB.Checked)
                    m_TriggerInfo.StartTrigger.GPI.GPIEvent = false;
                else
                    m_TriggerInfo.StartTrigger.GPI.GPIEvent = true;

                if (highToLow_CB.Checked)
                    m_TriggerInfo.StartTrigger.GPI.GPIEvent = false;
                else
                    m_TriggerInfo.StartTrigger.GPI.GPIEvent = true;

            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
            {
                m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD;
                
                if (startTriggerPressed_CB.Checked)
                    m_TriggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                else
                    m_TriggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
            }

            if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                m_TriggerInfo.StopTrigger.Duration = uint.Parse(this.stopDuration_TB.Text);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT;
                m_TriggerInfo.StopTrigger.GPI.PortNumber = stopGPIPort_CB.SelectedIndex + 1;
                m_TriggerInfo.StopTrigger.GPI.Timeout = uint.Parse(stopTimeout_TB.Text);

                if (stopEventLH_CB.Checked)
                    m_TriggerInfo.StopTrigger.GPI.GPIEvent = false;
                else
                    m_TriggerInfo.StopTrigger.GPI.GPIEvent = true;
                if (stopEventHL_CB.Checked)
                    m_TriggerInfo.StopTrigger.GPI.GPIEvent = false;
                else
                    m_TriggerInfo.StopTrigger.GPI.GPIEvent = true;

            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT;
                m_TriggerInfo.StopTrigger.TagObservation.N = ushort.Parse(stopTagObservation_TB.Text);
                m_TriggerInfo.StopTrigger.TagObservation.Timeout = uint.Parse(stopTriggerTagOb_TB.Text);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT;
                m_TriggerInfo.StopTrigger.NumAttempts.N = ushort.Parse(stopNumAttempt_TB.Text);
                m_TriggerInfo.StopTrigger.NumAttempts.Timeout = uint.Parse(stopTriggerNAttTimeOut_TB.Text);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
            {
                m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT;
                m_TriggerInfo.StopTrigger.Handheld.Timeout = uint.Parse(handHeldTriggerTimeout_TB.Text);

                if (stopTriggerPressed_CB.Checked)
                    m_TriggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                else
                    m_TriggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
            }

            if (m_AppForm.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported)
            {
                m_TriggerInfo.TagEventReportInfo.ReportNewTagEvent = (TAG_EVENT_REPORT_TRIGGER)newTag_CB.SelectedIndex;
                m_TriggerInfo.TagEventReportInfo.ReportTagBackToVisibilityEvent = (TAG_EVENT_REPORT_TRIGGER)backTag_CB.SelectedIndex;
                m_TriggerInfo.TagEventReportInfo.ReportTagInvisibleEvent = (TAG_EVENT_REPORT_TRIGGER)invisibleTag_CB.SelectedIndex;
                m_TriggerInfo.TagEventReportInfo.ReportTagMovingEvent = (TAG_MOVING_EVENT_REPORT)movingTag_CB.SelectedIndex;
                m_TriggerInfo.TagEventReportInfo.NewTagEventModeratedTimeoutMilliseconds = ushort.Parse(newTag_TB.Text);
                m_TriggerInfo.TagEventReportInfo.TagBackToVisibilityModeratedTimeoutMilliseconds = ushort.Parse(backTag_TB.Text);
                m_TriggerInfo.TagEventReportInfo.TagInvisibleEventModeratedTimeoutMilliseconds = ushort.Parse(invisibleTag_TB.Text);
                m_TriggerInfo.TagEventReportInfo.TagStationaryModeratedTimeoutMilliseconds = ushort.Parse(movingTag_TB.Text);
            }
            m_TriggerInfo.TagReportTrigger = uint.Parse(tagReportTriggerTB.Text);
            m_TriggerInfo.ReportTriggers.Period = uint.Parse(PerodicReportTriggerTB.Text);
        }

        private void antInfoApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    fetchTriggerParams();
                    m_AppForm.functionCallStatusLabel.Text = "Set Triggers Successfully";
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void Triggers_Load(object sender, EventArgs e)
        {
            if (!m_IsLoaded)
            {
                startPeriod_TB.Text = "1";
                tagReportTriggerTB.Text = "1";
                handHeldTriggerTimeout_TB.Text = "0";

                m_IsLoaded = true;
            }
        }

        private void newTag_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newTag_CB.SelectedIndex != (int)TAG_EVENT_REPORT_TRIGGER.MODERATED)
                newTag_TB.Enabled = false;
            else
                newTag_TB.Enabled = true;
        }

        private void invisibleTag_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invisibleTag_CB.SelectedIndex != (int)TAG_EVENT_REPORT_TRIGGER.MODERATED)
                invisibleTag_TB.Enabled = false;
            else
                invisibleTag_TB.Enabled = true;
        }

        private void backTag_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (backTag_CB.SelectedIndex != (int)TAG_EVENT_REPORT_TRIGGER.MODERATED)
                backTag_TB.Enabled = false;
            else
                backTag_TB.Enabled = true;
        }

        private void stopGroupBox_Enter(object sender, EventArgs e)
        {

        }

        void stopTriggerReleased_CB_Click(object sender, System.EventArgs e)
        {
            this.stopTriggerPressed_CB.Checked = false;
        }

        void stopTriggerPressed_CB_Click(object sender, System.EventArgs e)
        {
            this.stopTriggerReleased_CB.Checked = false;
        }

        void startTriggerPressed_CB_Click(object sender, System.EventArgs e)
        {
            this.startTriggerReleased_CB.Checked = false;
        }

        void startTriggerReleased_CB_Click(object sender, System.EventArgs e)
        {
            this.startTriggerPressed_CB.Checked = false;
        }
    }

}