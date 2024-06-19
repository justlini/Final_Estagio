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
    public partial class GPIOForm : Form
    {
        private AppForm m_AppForm;
        private ArrayList gpiCheckboxList;
        private ArrayList gpoLabelList;

        public GPIOForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
            gpiCheckboxList = new ArrayList();
            gpoLabelList = new ArrayList();
        }

        private void GPIO_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {
                    int tabIndex = 0;

                    for (int index = 0; index < m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPIPorts; index++)
                    {
                        int name = index + 1;

                        CheckBox gpiCheckbox = new System.Windows.Forms.CheckBox();
                        gpiCheckbox.AutoSize = true;
                        gpiCheckbox.Location = new System.Drawing.Point(8 + (32 * index), 31);
                        gpiCheckbox.Name = "gpiCheckbox" + name;
                        gpiCheckbox.Size = new System.Drawing.Size(32, 17);
                        gpiCheckbox.TabIndex = tabIndex++;
                        gpiCheckbox.Text = name.ToString();
                        gpiCheckbox.UseVisualStyleBackColor = true;

                        gpiCheckbox.Checked = m_AppForm.m_ReaderAPI.Config.GPI[index + 1].IsEnabled;

                        gpiCheckboxList.Add(gpiCheckbox);
                        gpiGroupBox.Controls.Add(gpiCheckbox);
                    }

                    for (int index = 0; index < m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPOPorts; index++)
                    {
                        int name = index + 1;

                        Label gpoLabel = new System.Windows.Forms.Label();
                        gpoLabel.AutoSize = true;
                        gpoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        gpoLabel.Location = new System.Drawing.Point(9 + (32 * index), 29);
                        gpoLabel.Name = "gpoLabel" + name;
                        gpoLabel.Size = new System.Drawing.Size(15, 15);
                        gpoLabel.TabIndex = tabIndex++;
                        gpoLabel.Text = "  ";
                        gpoLabel.MouseClick += new MouseEventHandler(gpoLabel_Click);

                        if (m_AppForm.m_ReaderAPI.Config.GPO[index + 1].PortState == GPOs.GPO_PORT_STATE.TRUE)
                        {
                            gpoLabel.BackColor = System.Drawing.Color.GreenYellow;
                        }
                        else
                        {
                            gpoLabel.BackColor = System.Drawing.Color.Red;
                        }
                        gpoLabelList.Add(gpoLabel);
                        gpoGroupBox.Controls.Add(gpoLabel);

                        Label gpoNamelabel = new System.Windows.Forms.Label();
                        gpoNamelabel.AutoSize = true;
                        gpoNamelabel.Font = new System.Drawing.Font(
                            "Microsoft Sans Serif", 8.25F,
                            System.Drawing.FontStyle.Regular,
                            System.Drawing.GraphicsUnit.Point,
                            ((byte)(0)));
                        gpoNamelabel.Location = new System.Drawing.Point(9 + (32 * index), 53);
                        gpoNamelabel.Name = "label" + name;
                        gpoNamelabel.Size = new System.Drawing.Size(241, 13);
                        gpoNamelabel.TabIndex = tabIndex++;
                        gpoNamelabel.Text = name.ToString();
                        gpoGroupBox.Controls.Add(gpoNamelabel);
                    }
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void gpiButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected)
                {
                    for (int index = 0; index < m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPIPorts; index++)
                    {
                        CheckBox gpiCheckbox = (CheckBox)gpiCheckboxList[index];
                        m_AppForm.m_ReaderAPI.Config.GPI[index + 1].Enable = gpiCheckbox.Checked;
                    }
                    m_AppForm.functionCallStatusLabel.Text = "Set GPI Successfully";
                }
                this.Dispose();
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

        private void gpoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected)
                {                    
                    for (int index = 0; index < m_AppForm.m_ReaderAPI.ReaderCapabilities.NumGPOPorts; index++)
                    {
                        Label gpoLabel = (Label)gpoLabelList[index];
                        if (gpoLabel.BackColor == System.Drawing.Color.GreenYellow)
                        {
                            m_AppForm.m_ReaderAPI.Config.GPO[index+1].PortState = GPOs.GPO_PORT_STATE.TRUE;
                        }
                        else
                        {
                            m_AppForm.m_ReaderAPI.Config.GPO[index+1].PortState = GPOs.GPO_PORT_STATE.FALSE;
                        }
                    }                     
                    m_AppForm.functionCallStatusLabel.Text = "Set GPO Successfully";
                    this.Dispose();
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

        private void gpoLabel_Click(Object sender, MouseEventArgs mea)
        {
            if (((Label)sender).BackColor == System.Drawing.Color.GreenYellow)
            {
                ((Label)sender).BackColor = System.Drawing.Color.Red;
            }
            else
            {
                ((Label)sender).BackColor = System.Drawing.Color.GreenYellow;
            }
        }
    }
}