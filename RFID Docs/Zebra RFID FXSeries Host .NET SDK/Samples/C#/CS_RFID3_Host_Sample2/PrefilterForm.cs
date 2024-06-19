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
    public partial class PreFilterForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsLoaded;

        public PreFilterForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        private void PreFilter_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected && !m_IsLoaded)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    antennaID_CB1.Items.Add("0");
                    antennaID_CB2.Items.Add("0");
                    foreach (ushort id in antID)
                    {
                        antennaID_CB1.Items.Add(id);
                        antennaID_CB2.Items.Add(id);
                    }
                    antennaID_CB1.SelectedIndex = 0;
                    antennaID_CB2.SelectedIndex = 0;

                    memBank_CB1.SelectedIndex = 0;
                    memBank_CB2.SelectedIndex = 0;

                    offset_TB1.Text = "32";
                    offset_TB2.Text = "32";

                    filterAction_CB1.SelectedIndex = 0;
                    filterAction_CB2.SelectedIndex = 0;

                    m_AppForm.functionCallStatusLabel.Text = "";
                    m_IsLoaded = true;
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected)
                {
                    m_AppForm.m_ReaderAPI.Actions.PreFilters.DeleteAll();
                    m_AppForm.functionCallStatusLabel.Text = "Deleteall...";
                }

                PreFilters.PreFilter filter1 = null;
                PreFilters.PreFilter filter2 = null;

                if (filter_CB1.Checked)
                {
                    filter1 = new PreFilters.PreFilter();
                    filter1.AntennaID = (ushort)antennaID_CB1.SelectedIndex;
                    filter1.MemoryBank = (MEMORY_BANK)memBank_CB1.SelectedIndex + 1;

                    int filterMaskLength = (tagMask_TB1.Text.Length / 2);
                    byte[] filterMask = new byte[filterMaskLength];
                    for (int index = 0; index < filterMaskLength; index++)
                    {
                        filterMask[index] = byte.Parse(tagMask_TB1.Text.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    filter1.TagPattern = filterMask;
                    filter1.TagPatternBitCount = (uint)filterMaskLength * 8;

                    filter1.BitOffset = uint.Parse(offset_TB1.Text);
                    filter1.FilterAction = (FILTER_ACTION)filterAction_CB1.SelectedIndex;
                    if (filter1.FilterAction == FILTER_ACTION.FILTER_ACTION_STATE_AWARE)
                    {
                        // Selected index divide by two for duplicate STATE_AWARE_ACTION index
                        filter1.StateAwareAction.Action = (STATE_AWARE_ACTION)(action_CB1.SelectedIndex / 2);
                        filter1.StateAwareAction.Target = (TARGET)target_CB1.SelectedIndex;
                    }
                    else if (filter1.FilterAction == FILTER_ACTION.FILTER_ACTION_STATE_UNAWARE)
                    {
                        filter1.StateUnawareAction.Action = (STATE_UNAWARE_ACTION)action_CB1.SelectedIndex;
                    }
                }

                if (filter_CB2.Checked)
                {
                    filter2 = new PreFilters.PreFilter();
                    filter2.AntennaID = (ushort)antennaID_CB2.SelectedIndex;
                    filter2.MemoryBank = (MEMORY_BANK)memBank_CB2.SelectedIndex + 1;

                    int filterMaskLength = tagMask_TB2.Text.Length / 2;
                    byte[] filterMask = new byte[filterMaskLength];
                    for (int index = 0; index < filterMaskLength; index++)
                    {
                        filterMask[index] = byte.Parse(tagMask_TB2.Text.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    filter2.TagPattern = filterMask;
                    filter2.TagPatternBitCount = (uint)filterMaskLength * 8;

                    filter2.BitOffset = uint.Parse(offset_TB2.Text);
                    filter2.FilterAction = (FILTER_ACTION)filterAction_CB2.SelectedIndex;

                    if (filter2.FilterAction == FILTER_ACTION.FILTER_ACTION_STATE_AWARE)
                    {
                        // Selected index divide by two for duplicate STATE_AWARE_ACTION index
                        filter2.StateAwareAction.Action = (STATE_AWARE_ACTION)(action_CB2.SelectedIndex / 2);
                        filter2.StateAwareAction.Target = (TARGET)target_CB2.SelectedIndex;
                    }
                    else if (filter2.FilterAction == FILTER_ACTION.FILTER_ACTION_STATE_UNAWARE)
                    {
                        filter2.StateUnawareAction.Action = (STATE_UNAWARE_ACTION)action_CB2.SelectedIndex;
                    }
                }

                if (filter1 != null)
                {
                    m_AppForm.m_ReaderAPI.Actions.PreFilters.Add(filter1);
                    m_AppForm.functionCallStatusLabel.Text = "Set "
                         + m_AppForm.m_ReaderAPI.Actions.PreFilters.Length +
                         " Prefilter Successfully";
                }
                if (filter2 != null)
                {
                    m_AppForm.m_ReaderAPI.Actions.PreFilters.Add(filter2);
                    m_AppForm.functionCallStatusLabel.Text = "Set "
                         + m_AppForm.m_ReaderAPI.Actions.PreFilters.Length +
                         " Prefilter Successfully";
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AppForm.functionCallStatusLabel.Text = ofe.StatusDescription;
            }
            catch (InvalidUsageException iue)
            {
                m_AppForm.functionCallStatusLabel.Text = iue.Info;
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void filterAction_CB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilterAction1();
        }

        private void filterAction_CB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilterAction2();
        }

        private void filter_CB1_CheckedChanged(object sender, EventArgs e)
        {
            antennaID_CB1.Enabled = filter_CB1.Checked;
            memBank_CB1.Enabled = filter_CB1.Checked;
            tagMask_TB1.Enabled = filter_CB1.Checked;
            offset_TB1.Enabled = filter_CB1.Checked;
            filterAction_CB1.Enabled = filter_CB1.Checked;
            if (filter_CB1.Checked)
            {
                updateFilterAction1();
            }
            else
            {
                action_CB1.Enabled = false;
                target_CB1.Enabled = false;
            }
        }

        private void filter_CB2_CheckedChanged(object sender, EventArgs e)
        {
            antennaID_CB2.Enabled = filter_CB2.Checked;
            memBank_CB2.Enabled = filter_CB2.Checked;
            tagMask_TB2.Enabled = filter_CB2.Checked;
            offset_TB2.Enabled = filter_CB2.Checked;
            filterAction_CB2.Enabled = filter_CB2.Checked;
            if (filter_CB2.Checked)
            {
                updateFilterAction2();
            }
            else
            {
                action_CB2.Enabled = false;
                target_CB2.Enabled = false;
            }
        }

        private void updateFilterAction1()
        {
            int index = filterAction_CB1.SelectedIndex;
            if (index == (int)FILTER_ACTION.FILTER_ACTION_DEFAULT)
            {
                action_CB1.Enabled = false;
                target_CB1.Enabled = false;

                action_CB1.Items.Clear();
                target_CB1.Items.Clear();
            }
            if (index == (int)FILTER_ACTION.FILTER_ACTION_STATE_AWARE)
            {
                action_CB1.Items.Clear();
                action_CB1.Items.Add("INV A NOT INV B");
                action_CB1.Items.Add("ASRT_SL_NOT_DSRT_SL");
                action_CB1.Items.Add("INV A");
                action_CB1.Items.Add("ASRT SL");
                action_CB1.Items.Add("NOT INV B");
                action_CB1.Items.Add("NOT DSRT SL");
                action_CB1.Items.Add("INV A2BB2A NOT INV A");
                action_CB1.Items.Add("NEG SL NOT ASRT SL");
                action_CB1.Items.Add("INV B NOT INV A");
                action_CB1.Items.Add("DSRT SL NOT ASRT SL");
                action_CB1.Items.Add("INV B");
                action_CB1.Items.Add("DSRT SL");
                action_CB1.Items.Add("NOT INV A");
                action_CB1.Items.Add("NOT ASRT SL");
                action_CB1.Items.Add("NOT INV A2BB2A");
                action_CB1.Items.Add("NOT NEG SL");
                action_CB1.SelectedIndex = 0;

                target_CB1.Items.Clear();
                target_CB1.Items.Add("SL");
                target_CB1.Items.Add("S0");
                target_CB1.Items.Add("S1");
                target_CB1.Items.Add("S2");
                target_CB1.Items.Add("S3");
                target_CB1.SelectedIndex = 0;

                action_CB1.Enabled = true;
                target_CB1.Enabled = true;
            }
            else if (index == (int)FILTER_ACTION.FILTER_ACTION_STATE_UNAWARE)
            {
                action_CB1.Items.Clear();
                action_CB1.Items.Add("SELECT NOT UNSELECT");
                action_CB1.Items.Add("SELECT");
                action_CB1.Items.Add("NOT UNSELECT");
                action_CB1.Items.Add("UNSELECT");
                action_CB1.Items.Add("UNSELECT NOT SELECT");
                action_CB1.Items.Add("NOT SELECT");
                action_CB1.SelectedIndex = 0;

                target_CB1.Items.Clear();

                target_CB1.Enabled = false;
                action_CB1.Enabled = true;
            }
        }

        private void updateFilterAction2()
        {
            int index2 = filterAction_CB2.SelectedIndex;
            if (index2 == (int)FILTER_ACTION.FILTER_ACTION_DEFAULT)
            {
                target_CB2.Enabled = false;
                action_CB2.Enabled = false;

                action_CB2.Items.Clear();
                target_CB2.Items.Clear();
            }
            if (index2 == (int)FILTER_ACTION.FILTER_ACTION_STATE_AWARE)
            {
                action_CB2.Items.Clear();
                action_CB2.Items.Add("INV A NOT INV B");
                action_CB2.Items.Add("ASRT_SL_NOT_DSRT_SL");
                action_CB2.Items.Add("INV A");
                action_CB2.Items.Add("ASRT SL");
                action_CB2.Items.Add("NOT INV B");
                action_CB2.Items.Add("NOT DSRT SL");
                action_CB2.Items.Add("INV A2BB2A NOT INV A");
                action_CB2.Items.Add("NEG SL NOT ASRT SL");
                action_CB2.Items.Add("INV B NOT INV A");
                action_CB2.Items.Add("DSRT SL NOT ASRT SL");
                action_CB2.Items.Add("INV B");
                action_CB2.Items.Add("DSRT SL");
                action_CB2.Items.Add("NOT INV A");
                action_CB2.Items.Add("NOT ASRT SL");
                action_CB2.Items.Add("NOT INV A2BB2A");
                action_CB2.Items.Add("NOT NEG SL");
                action_CB2.SelectedIndex = 0;

                target_CB2.Items.Clear();
                target_CB2.Items.Add("SL");
                target_CB2.Items.Add("S0");
                target_CB2.Items.Add("S1");
                target_CB2.Items.Add("S2");
                target_CB2.Items.Add("S3");
                target_CB2.SelectedIndex = 0;

                target_CB2.Enabled = true;
                action_CB2.Enabled = true;
            }
            else if (index2 == (int)FILTER_ACTION.FILTER_ACTION_STATE_UNAWARE)
            {
                action_CB2.Items.Clear();
                action_CB2.Items.Add("SELECT NOT UNSELECT");
                action_CB2.Items.Add("SELECT");
                action_CB2.Items.Add("NOT UNSELECT");
                action_CB2.Items.Add("UNSELECT");
                action_CB2.Items.Add("UNSELECT NOT SELECT");
                action_CB2.Items.Add("NOT SELECT");
                action_CB2.SelectedIndex = 0;

                target_CB2.Items.Clear();

                target_CB2.Enabled = false;
                action_CB2.Enabled = true;
            }
        }
    }
}