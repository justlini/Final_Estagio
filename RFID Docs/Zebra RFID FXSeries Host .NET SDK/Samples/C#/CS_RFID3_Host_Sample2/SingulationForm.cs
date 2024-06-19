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
    public partial class SingulationForm : Form
    {
        private AppForm m_AppForm;

        public SingulationForm(AppForm appForm)
        {
            m_AppForm = appForm;        
            InitializeComponent();
        }

        private void Singulation_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;

                    if (antID.Length > 0)
                    {
                        foreach (ushort id in antID)
                            antennaID_CB.Items.Add(id);
                        antennaID_CB.SelectedIndex = 0;
                    }
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
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    Antennas.SingulationControl singularControl =
                        m_AppForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].GetSingulationControl();

                    session_CB.SelectedIndex = (int)singularControl.Session;

                    tagPopulation_TB.Text = singularControl.TagPopulation.ToString();
                    tagTransit_TB.Text = singularControl.TagTransitTime.ToString();

                    if (singularControl.Action.PerformStateAwareSingulationAction)
                    {
                        Antennas.SingulationControl.SingulationAction action =
                            singularControl.Action;

                        inventoryState_CB.SelectedIndex = (int)action.InventoryState;
                        SLFlag_CB.SelectedIndex = (int)action.SLFlag;
                        stateAwareSingulation_CB.Checked = true;
                    }
                    else
                    {
                        inventoryState_CB.Enabled = false;
                        SLFlag_CB.Enabled = false;
                        stateAwareSingulation_CB.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void singulationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    Antennas.SingulationControl singularControl =
                        m_AppForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].GetSingulationControl();

                    singularControl.Session = (SESSION)session_CB.SelectedIndex;

                    singularControl.TagPopulation = ushort.Parse(tagPopulation_TB.Text);
                    singularControl.TagTransitTime = ushort.Parse(tagTransit_TB.Text);

                    if (stateAwareSingulation_CB.Checked == true)
                    {
                        singularControl.Action.PerformStateAwareSingulationAction = true;
                        singularControl.Action.InventoryState
                            = (INVENTORY_STATE)inventoryState_CB.SelectedIndex;

                        singularControl.Action.SLFlag
                            = (SL_FLAG)SLFlag_CB.SelectedIndex;
                    }
                    else
                        singularControl.Action.PerformStateAwareSingulationAction = false;
                    m_AppForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].SetSingulationControl(singularControl);
                    m_AppForm.functionCallStatusLabel.Text = "Set Singulation Successfully";
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
            this.Dispose();
        }

        private void stateAwareSingulation_CB_CheckedChanged(object sender, EventArgs e)
        {

            inventoryState_CB.Enabled = stateAwareSingulation_CB.Checked;
            SLFlag_CB.Enabled = stateAwareSingulation_CB.Checked;
        }
    }
}