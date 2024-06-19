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
    public partial class PostFilterForm : Form
    {
        private AppForm m_AppForm = null;
        private bool m_IsLoaded;
        private Symbol.RFID3.PostFilter m_PostFilter = null;

        public PostFilterForm(AppForm appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        public Symbol.RFID3.PostFilter getFilter()
        {
            return m_PostFilter;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_AppForm.m_ReaderAPI.IsConnected && postFilter_CB1.Checked)
                {
                    if (null == m_PostFilter)
                    {
                        m_PostFilter = new Symbol.RFID3.PostFilter();
                    }
                    m_PostFilter.MatchPattern = (MATCH_PATTERN)matchPattern_CB.SelectedIndex;

                    /*
                     *  Tag Pattern A
                     */
                    m_PostFilter.TagPatternA.MemoryBank = (MEMORY_BANK)memBank_CB1.SelectedIndex;
                    m_PostFilter.TagPatternA.BitOffset = ushort.Parse(offset_TB1.Text);

                    string tagMaskA = tagMask_TB1.Text;
                    if (tagMaskA.StartsWith("0x"))
                    {
                        tagMaskA = tagMaskA.Substring(2);
                    }
                    ushort maskLengthA = (ushort)(tagMaskA.Length / 2);
                    byte[] filterMaskA = new byte[maskLengthA];
                    for (int index = 0; index < maskLengthA; index++)
                    {
                        filterMaskA[index] = byte.Parse(tagMaskA.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    m_PostFilter.TagPatternA.TagMask = filterMaskA;
                    m_PostFilter.TagPatternA.TagMaskBitCount = (uint)maskLengthA * 8;

                    string tagPatternA = MembankData_TB1.Text;
                    if (tagPatternA.StartsWith("0x"))
                    {
                        tagPatternA = tagPatternA.Substring(2);
                    }
                    int dataLengthA = (tagPatternA.Length / 2);
                    byte[] memoryBankDataA = new byte[dataLengthA];
                    for (int index = 0; index < dataLengthA; index++)
                    {
                        memoryBankDataA[index] = byte.Parse(tagPatternA.Substring(index * 2, 2),
                            System.Globalization.NumberStyles.HexNumber);
                    }
                    m_PostFilter.TagPatternA.TagPattern = memoryBankDataA;
                    m_PostFilter.TagPatternA.TagPatternBitCount = (uint)dataLengthA * 8;

                    /*
                     *  Tag Pattern B
                     */
                    if (m_PostFilter.MatchPattern != MATCH_PATTERN.A)
                    {
                        m_PostFilter.TagPatternB.MemoryBank = (MEMORY_BANK)memBank_CB2.SelectedIndex;
                        m_PostFilter.TagPatternB.BitOffset = ushort.Parse(offset_TB2.Text);

                        string tagMaskB = tagMask_TB2.Text;
                        if (tagMaskB.StartsWith("0x"))
                        {
                            tagMaskB = tagMaskB.Substring(2);
                        }
                        int maskLengthB = (tagMaskB.Length / 2);
                        byte[] filterMaskB = new byte[maskLengthB];
                        for (int index = 0; index < maskLengthB; index++)
                        {
                            filterMaskB[index] = byte.Parse(tagMaskB.Substring(index * 2, 2),
                                System.Globalization.NumberStyles.HexNumber);
                        }
                        m_PostFilter.TagPatternB.TagMask = filterMaskB;
                        m_PostFilter.TagPatternB.TagMaskBitCount = (uint)maskLengthB * 8;

                        string tagPatternB = MembankData_TB2.Text;
                        if (tagPatternB.StartsWith("0x"))
                        {
                            tagPatternB = tagPatternB.Substring(2);
                        }
                        int dataLengthB = (tagPatternB.Length / 2);
                        byte[] memoryBankDataB = new byte[dataLengthB];
                        for (int index = 0; index < dataLengthB; index++)
                        {
                            memoryBankDataB[index] = byte.Parse(tagPatternB.Substring(index * 2, 2),
                                System.Globalization.NumberStyles.HexNumber);
                        }
                        m_PostFilter.TagPatternB.TagPattern = memoryBankDataB;
                        m_PostFilter.TagPatternB.TagPatternBitCount = (uint)dataLengthB * 8;
                    }
                    m_IsLoaded = true;
                    m_AppForm.functionCallStatusLabel.Text = "";
                }
                else if (!postFilter_CB1.Checked)
                {
                    m_PostFilter = null;                    
                }
            }
            catch (Exception ex)
            {
                m_AppForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void PostFilter_Load(object sender, EventArgs e)
        {
            if (!m_IsLoaded)
            {
                matchPattern_CB.SelectedIndex = 0;
                memBank_CB1.SelectedIndex = 1;
                memBank_CB2.SelectedIndex = 1;
                m_IsLoaded = true;
            }
        }

        private void postFilter_CB1_CheckedChanged(object sender, EventArgs e)
        {
            matchPattern_CB.Enabled = tagPatternA_GB.Enabled = tagPatternB_GB.Enabled
                = postFilter_CB1.Checked;            
        }
    }
}