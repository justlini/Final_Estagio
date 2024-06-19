using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace CS_RFID3_Host_Sample2
{
    public partial class AntennaInfoForm : Form
    {
        private ArrayList m_CheckBox = null;
        private AppForm m_AppForm = null;
        private bool m_IsLoaded = false;
        private Symbol.RFID3.AntennaInfo m_AntennaList = null;

        public AntennaInfoForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            m_CheckBox = new ArrayList();
        }

        public Symbol.RFID3.AntennaInfo getInfo()
        {
            return m_AntennaList;
        }

        private void AntennaInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected && !m_IsLoaded)
                {
                    int xIndex = 0;
                    int yIndex = 32;
                    int numAtenna = m_AppForm.m_ReaderAPI.Config.Antennas.AvailableAntennas.Length;

                    for (int index = 0; index < numAtenna; index++)
                    {
                        int name = index + 1;
                        if (index > 0 && (index % 4) == 0)
                        {
                            xIndex = 0;
                            yIndex += 32;
                        }

                        CheckBox cb = new CheckBox();
                        cb.AutoSize = true;
                        cb.Location = new System.Drawing.Point((16 + (xIndex++) * 70), yIndex);
                        cb.Name = "checkBox " + name;
                        cb.Size = new System.Drawing.Size(70, 20);
                        cb.TabIndex = name;
                        cb.Text = name.ToString();
                        cb.UseVisualStyleBackColor = true;
                        cb.Checked = true;
                        cb.CheckedChanged += new System.EventHandler(this.filter_CheckedChanged);

                        m_CheckBox.Add(cb);
                        Antenna_GB.Controls.Add(cb);
                    }
                    selectAll_CB.Checked = true;
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
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    ArrayList checkList = new ArrayList();
                    foreach (CheckBox cb in m_CheckBox)
                    {
                        if (cb.Checked)
                        {
                            checkList.Add(cb.Text);
                        }
                    }
                    if (checkList.Count == 0)
                    {
                        foreach (CheckBox cb in m_CheckBox)
                        {
                            cb.Checked = true;
                            selectAll_CB.Checked = true;
                            checkList.Add(cb.Text);
                        }
                    }
                    if (checkList.Count > 0)
                    {
                        ushort[] antList = new ushort[checkList.Count];
                        for (int index = 0; index < checkList.Count; index++)
                        {
                            antList[index] = ushort.Parse(checkList[index].ToString());
                        }

                        if (null == m_AntennaList)
                        {
                            m_AntennaList = new Symbol.RFID3.AntennaInfo(antList);
                        }
                        else
                        {
                            m_AntennaList.AntennaID = antList;
                        }
                    }
                    m_AppForm.functionCallStatusLabel.Text = "Set Antenna Successfully";
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
            this.Close();
        }

        private void filter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selectAll_CB_CheckedChanged(object sender, EventArgs e)
        {

            foreach (CheckBox cb in m_CheckBox)
            {
                cb.Checked = selectAll_CB.Checked;
            }
        }
    }
}