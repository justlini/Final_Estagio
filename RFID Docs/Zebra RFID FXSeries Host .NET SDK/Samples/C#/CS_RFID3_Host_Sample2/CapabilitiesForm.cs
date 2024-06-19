using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;


namespace CS_RFID3_Host_Sample2
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
                if (m_AppForm.m_IsConnected)
                {
                    ReaderCapabilities cap = m_AppForm.m_ReaderAPI.ReaderCapabilities;

                    ListView capView = this.capabilitiesView;
                    ListViewItem item;

                    capView.BeginUpdate();
                    capView.Items.Clear();
                    item = new ListViewItem("ReaderID");
                    item.SubItems.Add(cap.ReaderID.ID.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("Firware Version");
                    item.SubItems.Add(cap.FirwareVersion);
                    capView.Items.Add(item);
                    item = new ListViewItem("Model Name");
                    item.SubItems.Add(cap.ModelName);
                    capView.Items.Add(item);
                    item = new ListViewItem("No. of Antennas");
                    item.SubItems.Add(cap.NumAntennaSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("No. of GPIPorts");
                    item.SubItems.Add(cap.NumGPIPorts.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("No. of GPOPorts");
                    item.SubItems.Add(cap.NumGPOPorts.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("Max Operations In AccessSequence");
                    item.SubItems.Add(cap.MaxNumOperationsInAccessSequence.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("Max No. of PreFilters");
                    item.SubItems.Add(cap.MaxNumPreFilters.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("CountryCode");
                    item.SubItems.Add(cap.CountryCode.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("CommunicationStandard");
                    item.SubItems.Add(cap.CommunicationStandard.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsUTCClockSupported");
                    item.SubItems.Add(cap.IsUTCClockSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsBlockEraseSupported");
                    item.SubItems.Add(cap.IsBlockEraseSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsBlockWriteSupported");
                    item.SubItems.Add(cap.IsBlockWriteSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsBlockPermalockSupported");
                    item.SubItems.Add(cap.IsBlockPermalockSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsBlockWriteSupported");
                    item.SubItems.Add(cap.IsBlockWriteSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsRecommissionSupported");
                    item.SubItems.Add(cap.IsRecommissionSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsWriteUMISupported");
                    item.SubItems.Add(cap.IsWriteUMISupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsTagInventoryStateAwareSingulationSupported");
                    item.SubItems.Add(cap.IsTagInventoryStateAwareSingulationSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsTagEventReportingSupported");
                    item.SubItems.Add(cap.IsTagEventReportingSupported.ToString());
                    capView.Items.Add(item);
                    item = new ListViewItem("IsRssiFilterSupported");
                    item.SubItems.Add(cap.IsRssiFilterSupported.ToString());
                    capView.Items.Add(item);
                    capView.EndUpdate();
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