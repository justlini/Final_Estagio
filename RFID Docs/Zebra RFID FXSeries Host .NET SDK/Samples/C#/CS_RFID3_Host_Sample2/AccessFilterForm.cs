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
    public partial class AccessFilterForm : Form
    {
        private AppForm m_AppForm;
        private bool m_IsLoaded;
        private Symbol.RFID3.AccessFilter m_AccessFilter = null;
        private bool m_IsAccessFilterToBeUsed;

        public AccessFilterForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        public Symbol.RFID3.AccessFilter getFilter()
        {
            return m_AccessFilter;
        }

        public bool IsAccessFilterToBeUsed
        {
            get
            {
                return m_IsAccessFilterToBeUsed;
            }
            set
            {
                m_IsAccessFilterToBeUsed = value;
            }
        }

        private void AccessFilter_Load(object sender, EventArgs e)
        {
            if (!m_IsLoaded)
            {
                matchPattern_CB.SelectedIndex = 4;
                memBank_CB1.SelectedIndex = 1;
                offset_TB1.Text = "0";
                memBank_CB2.SelectedIndex = 1;
                offset_TB2.Text = "0";
                m_IsLoaded = true;
                this.tagPatternA_GB.Enabled = this.tagPatternB_GB.Enabled =
                    this.matchPattern_CB.Enabled = this.accessFilter_CB1.Checked;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_IsConnected && accessFilter_CB1.Checked)
                {
                    if (null == m_AccessFilter)
                    {
                        m_AccessFilter = new Symbol.RFID3.AccessFilter();
                    }

                    m_AccessFilter.TagPatternA.MemoryBank = (MEMORY_BANK)memBank_CB1.SelectedIndex;
                    m_AccessFilter.TagPatternA.BitOffset = ushort.Parse(offset_TB1.Text);

                    string tagPatternTextA = memBankData_TB1.Text;
                    if (tagPatternTextA.StartsWith("0x"))
                    {
                        tagPatternTextA = tagPatternTextA.Substring(2);
                    }
                    int tagDataCountA = (tagPatternTextA.Length / 2);
                    byte[] tagPatternA = new byte[tagDataCountA];
                    for (int index = 0; index < tagDataCountA; index++)
                    {
                        tagPatternA[index] = byte.Parse(tagPatternTextA.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    m_AccessFilter.TagPatternA.TagPattern = tagPatternA;
                    m_AccessFilter.TagPatternA.TagPatternBitCount = (uint)tagDataCountA * 8;

                    string tagMaskTextA = tagMask_TB1.Text;
                    if (tagMaskTextA.StartsWith("0x"))
                    {
                        tagMaskTextA = tagMaskTextA.Substring(2);
                    }
                    int tagMaskLengthA = (tagMaskTextA.Length / 2);
                    byte[] tagMaskA = new byte[tagMaskLengthA];
                    for (int index = 0; index < tagMaskLengthA; index++)
                    {
                        tagMaskA[index] = byte.Parse(tagMaskTextA.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    m_AccessFilter.TagPatternA.TagMask = tagMaskA;
                    m_AccessFilter.TagPatternA.TagMaskBitCount = (uint)tagMaskLengthA * 8;

                    MATCH_PATTERN matchPattern = (MATCH_PATTERN)matchPattern_CB.SelectedIndex;
                    if (MATCH_PATTERN.A != matchPattern)
                    {
                        m_AccessFilter.TagPatternB.MemoryBank = (MEMORY_BANK)memBank_CB2.SelectedIndex;
                        m_AccessFilter.TagPatternB.BitOffset = ushort.Parse(offset_TB2.Text);

                        string tagPatternTextB = memBankData_TB2.Text;
                        if (tagPatternTextB.StartsWith("0x"))
                        {
                            tagPatternTextB = tagPatternTextB.Substring(2);
                        }
                        int tagDataCountB = (tagPatternTextB.Length / 2);
                        byte[] tagPatternB = new byte[tagDataCountB];
                        for (int index = 0; index < tagDataCountB; index++)
                        {
                            tagPatternB[index] = byte.Parse(tagPatternTextB.Substring(index * 2, 2),
                                System.Globalization.NumberStyles.HexNumber);
                        }
                        m_AccessFilter.TagPatternB.TagPattern = tagPatternB;
                        m_AccessFilter.TagPatternB.TagPatternBitCount = (uint)tagDataCountB * 8;

                        string tagMaskTextB = tagMask_TB2.Text;
                        if (tagMaskTextB.StartsWith("0x"))
                        {
                            tagMaskTextB = tagMaskTextB.Substring(2);
                        }
                        int tagMaskCountB = (tagMaskTextB.Length / 2);
                        byte[] tagMaskB = new byte[tagMaskCountB];
                        for (int index = 0; index < tagMaskCountB; index++)
                        {
                            tagMaskB[index] = byte.Parse(tagMaskTextB.Substring(index * 2, 2),
                                System.Globalization.NumberStyles.HexNumber);
                        }
                        m_AccessFilter.TagPatternB.TagMask = tagMaskB;
                        m_AccessFilter.TagPatternB.TagMaskBitCount = (uint)tagMaskCountB * 8;
                    }
                    m_AccessFilter.MatchPattern = matchPattern;

                    m_AppForm.functionCallStatusLabel.Text = "Set Access Filter Successfully";
                }
                else if (!accessFilter_CB1.Checked)
                {
                    m_AccessFilter = null;
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void accessFilter_CB1_CheckedChanged(object sender, EventArgs e)
        {
            this.tagPatternA_GB.Enabled = this.tagPatternB_GB.Enabled =
                this.matchPattern_CB.Enabled = this.accessFilter_CB1.Checked;
        }
    }
}