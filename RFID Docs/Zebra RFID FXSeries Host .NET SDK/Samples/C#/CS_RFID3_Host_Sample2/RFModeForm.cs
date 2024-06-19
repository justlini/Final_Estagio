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
    public partial class RFModeForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsLoaded;

        public RFModeForm(AppForm appForm)
        {
            m_AppForm = appForm;

            InitializeComponent();
        }

        private void RFMode_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI != null && m_AppForm.m_ReaderAPI.IsConnected
                    && !m_IsLoaded)
                {
                    ushort[] antID = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;

                    if (antID.Length > 0)
                    {
                        foreach (ushort id in antID)
                            antenna_CB.Items.Add(id);
                        antenna_CB.SelectedIndex = 0;
                        Antennas.RFMode antRFMode = null;

                        try
                        {
                            antRFMode = m_AppForm.m_ReaderAPI.Config.Antennas[antID[antenna_CB.SelectedIndex]].GetRFMode();
                        }
                        catch (OperationFailureException ex)
                        {
                            this.m_AppForm.functionCallStatusLabel.Text = ex.VendorMessage;
                        }

                        int numberRFModes = m_AppForm.m_ReaderAPI.ReaderCapabilities.RFModes[0].Length;

                        for (int j = 0; j < numberRFModes; j++)
                            {
                            rfModeTable_CB.Items.Add(j);

                        }
                        if (antRFMode != null)
                            rfModeTable_CB.SelectedIndex = (int)antRFMode.TableIndex;
                                                                  
                    }

                    m_IsLoaded = true;
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AppForm.functionCallStatusLabel.Text = ofe.Message.ToString();
            }
        }

        private void rfModeApplybutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    int index = int.Parse(antenna_CB.SelectedItem.ToString());
                    Antennas.RFMode antRFMode = m_AppForm.m_ReaderAPI.Config.Antennas[index].GetRFMode();

                    antRFMode.Tari = uint.Parse(tari_TB.Text);
                    antRFMode.TableIndex = (uint)(rfModeTable_CB.SelectedIndex);

                    m_AppForm.m_ReaderAPI.Config.Antennas[index].SetRFMode(antRFMode);
                    m_AppForm.functionCallStatusLabel.Text = "Set RFMode succededed";
                }
                this.Dispose();
            }
            catch (InvalidUsageException ex)
            {
                this.m_AppForm.functionCallStatusLabel.Text = ex.Info;
            }
            catch (OperationFailureException ofe)
            {
                this.m_AppForm.functionCallStatusLabel.Text = ofe.VendorMessage;
            }
            catch (Exception ex)
            {
                this.m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void antenna_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(antenna_CB.SelectedItem.ToString());
            Antennas.RFMode antRFMode = null;
            try
            {
                antRFMode = m_AppForm.m_ReaderAPI.Config.Antennas[index].GetRFMode();
                if (rfModeTable_CB.Items.Count > antRFMode.TableIndex)
                {
                    rfModeTable_CB.SelectedIndex = (int)antRFMode.TableIndex;
                }
            }
            catch (OperationFailureException ofe)
            {
                this.m_AppForm.functionCallStatusLabel.Text = ofe.VendorMessage;
            }
            if (antRFMode != null)
            {
                tari_TB.Text = antRFMode.Tari.ToString();
            }
        }

        private void rfModeTable_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rfModeTable_CB.SelectedItem != null)
            {
                int index = rfModeTable_CB.SelectedIndex;
                if (index >= 0)
                {
                    RFModeTableEntry rfTableEntry = m_AppForm.m_ReaderAPI.ReaderCapabilities.RFModes[0][index];
                            for (int k = 0; k < rfModelistView.Items.Count; k++)
                            {
                                if (rfModelistView.Items[k].SubItems.Count > 1)
                                    rfModelistView.Items[k].SubItems.RemoveAt(1);
                            }
                    rfModelistView.Items[0].SubItems.Add(rfTableEntry.ModeIdentifier.ToString());
                    rfModelistView.Items[1].SubItems.Add(rfTableEntry.DivideRatio.ToString());
                    rfModelistView.Items[2].SubItems.Add(rfTableEntry.BdrValue.ToString());
                    rfModelistView.Items[3].SubItems.Add(rfTableEntry.Modulation.ToString());
                    rfModelistView.Items[4].SubItems.Add(rfTableEntry.ForwardLinkModulationType.ToString());
                    rfModelistView.Items[5].SubItems.Add(rfTableEntry.PieValue.ToString());
                    rfModelistView.Items[6].SubItems.Add(rfTableEntry.MinTariValue.ToString());
                    rfModelistView.Items[7].SubItems.Add(rfTableEntry.MaxTariValue.ToString());
                    rfModelistView.Items[8].SubItems.Add(rfTableEntry.StepTariValue.ToString());
                    rfModelistView.Items[9].SubItems.Add(rfTableEntry.SpectralMaskIndicator.ToString());
                    rfModelistView.Items[10].SubItems.Add(rfTableEntry.EPCHAGTCConformance.ToString());

                }
            }
        }
    }
}