using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;


namespace CS_RFID3_Host_Sample1
{
    public partial class CapabilitiesForm : Form
    {
        private AppForm m_AppForm;
        internal bool m_IsLoaded;

        public CapabilitiesForm(AppForm appForm)
        {
            m_AppForm = appForm;
            InitializeComponent();
        }

        private void Capabilities_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected && !m_IsLoaded)
                {
                    ReaderCapabilities cap = m_AppForm.m_ReaderAPI.ReaderCapabilities;

                    ListView capView = this.capabilitiesView;
                    capView.Items[0].SubItems.Add(cap.ReaderID.ID);
                    capView.Items[1].SubItems.Add(cap.FirwareVersion);
                    capView.Items[2].SubItems.Add(cap.ModelName);
                    capView.Items[3].SubItems.Add(cap.NumAntennaSupported.ToString());
                    capView.Items[4].SubItems.Add(cap.NumGPIPorts.ToString());
                    capView.Items[5].SubItems.Add(cap.NumGPOPorts.ToString());
                    capView.Items[6].SubItems.Add(cap.MaxNumOperationsInAccessSequence.ToString());
                    capView.Items[7].SubItems.Add(cap.MaxNumPreFilters.ToString());
                    capView.Items[8].SubItems.Add(cap.CountryCode.ToString());
                    capView.Items[9].SubItems.Add(cap.CommunicationStandard.ToString());
                    capView.Items[10].SubItems.Add(cap.IsUTCClockSupported.ToString());
                    capView.Items[11].SubItems.Add(cap.IsBlockEraseSupported.ToString());
                    capView.Items[12].SubItems.Add(cap.IsBlockWriteSupported.ToString());
                    capView.Items[13].SubItems.Add(cap.IsBlockPermalockSupported.ToString());
                    capView.Items[14].SubItems.Add(cap.IsRecommissionSupported.ToString());
                    capView.Items[15].SubItems.Add(cap.IsWriteUMISupported.ToString());
                    capView.Items[16].SubItems.Add(cap.IsTagInventoryStateAwareSingulationSupported.ToString());
                    capView.Items[17].SubItems.Add(cap.IsTagEventReportingSupported.ToString());
                    capView.Items[18].SubItems.Add(cap.IsRssiFilterSupported.ToString());
                    m_IsLoaded = true;
                }
                else
                {
                    m_AppForm.functionCallStatusLabel.Text = "Please connect to a reader";
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private string convertCountryCodeToName(int countryCode)
        {
            return countryCode.ToString();
        }
    }
}