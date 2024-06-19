using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Symbol.RFID3;

namespace CS_RFID3_Host_Sample2
{

    public partial class LocateForm : Form
    {
        AppForm m_AppForm = null;
        internal MotoProgressBar Locate_PB = null;

        public LocateForm(AppForm appForm)
        {
            m_AppForm = appForm;
            InitializeComponent();
            this.DoubleBuffered = true;

            // this.Locate_PB = new VerticalProgressBar();
            Locate_PB = new MotoProgressBar();
            Locate_PB.Location = new System.Drawing.Point(110, 90);
            Locate_PB.Name = "Indicator_PB";

            Locate_PB.Size = new System.Drawing.Size(40, 147);
            Locate_PB.Maximum = 100;
            Locate_PB.Minimum = 0;
            Controls.Add(this.Locate_PB);


            // Set initial value to 0
            Locate_PB.Value = 0;


        }

        private void locateButton_Click(object sender, EventArgs e)
        {
            if (locateButton.Text == "Start")
            {
                try
                {
                    ushort[] antennaList = new ushort[1] { 1 };
                    OPERATION_QUALIFER[] opList = new OPERATION_QUALIFER[1] { OPERATION_QUALIFER.LOCATE_TAG };
                    AntennaInfo antennaInfo = new AntennaInfo(antennaList, opList);
                    m_AppForm.m_ReaderAPI.Actions.TagLocationing.Perform(tagID_TB.Text, antennaInfo);
                    locateButton.Text = "Stop";
                }
                catch (InvalidOperationException ioe)
                {
                    m_AppForm.functionCallStatusLabel.Text = ioe.Message;
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
            }
            else if (locateButton.Text == "Stop")
            {
                m_AppForm.m_ReaderAPI.Actions.TagLocationing.Stop();
                locateButton.Text = "Start";
                Locate_PB.Value = 0;
            }
        }

        private void LocateForm_Load(object sender, EventArgs e)
        {
            this.Locate_PB.Value = 0;
            int selectedIndex = m_AppForm.inventoryList.SelectedIndices[0];
            ListViewItem item = m_AppForm.inventoryList.Items[selectedIndex];
            this.tagID_TB.Text = item.Text;

        }

        private void LocateForm_Closing(object sender, CancelEventArgs e)
        {
        }


    }
}