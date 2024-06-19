namespace CS_RFID3_Host_Sample2
{
    partial class AntennaConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.antennaIDLlabel = new System.Windows.Forms.Label();
            this.antennaID_CB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.transmitPower_CB = new System.Windows.Forms.ComboBox();
            this.transmitPowerLabel = new System.Windows.Forms.Label();
            this.receiveSensitivity_CB = new System.Windows.Forms.ComboBox();
            this.receiveSenLabel = new System.Windows.Forms.Label();
            this.hopTable_GB = new System.Windows.Forms.GroupBox();
            this.hopFrequencies_TB = new System.Windows.Forms.TextBox();
            this.hopTableIndex_CB = new System.Windows.Forms.ComboBox();
            this.hopTableIndexLabel = new System.Windows.Forms.Label();
            this.FrequencyHeader = new System.Windows.Forms.ColumnHeader();
            this.antennaConfigButton = new System.Windows.Forms.Button();
            this.transmitFreq_GB = new System.Windows.Forms.GroupBox();
            this.transmitFreq_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.hopTable_GB.SuspendLayout();
            this.transmitFreq_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // antennaIDLlabel
            // 
            this.antennaIDLlabel.AutoSize = true;
            this.antennaIDLlabel.Location = new System.Drawing.Point(23, 21);
            this.antennaIDLlabel.Name = "antennaIDLlabel";
            this.antennaIDLlabel.Size = new System.Drawing.Size(61, 13);
            this.antennaIDLlabel.TabIndex = 0;
            this.antennaIDLlabel.Text = "Antenna ID";
            // 
            // antennaID_CB
            // 
            this.antennaID_CB.FormattingEnabled = true;
            this.antennaID_CB.Location = new System.Drawing.Point(115, 18);
            this.antennaID_CB.Name = "antennaID_CB";
            this.antennaID_CB.Size = new System.Drawing.Size(121, 21);
            this.antennaID_CB.TabIndex = 1;
            this.antennaID_CB.SelectedIndexChanged += new System.EventHandler(this.antennaID_CB_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transmitPower_CB);
            this.groupBox1.Controls.Add(this.transmitPowerLabel);
            this.groupBox1.Controls.Add(this.receiveSensitivity_CB);
            this.groupBox1.Controls.Add(this.receiveSenLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // transmitPower_CB
            // 
            this.transmitPower_CB.FormattingEnabled = true;
            this.transmitPower_CB.Location = new System.Drawing.Point(103, 56);
            this.transmitPower_CB.Name = "transmitPower_CB";
            this.transmitPower_CB.Size = new System.Drawing.Size(121, 21);
            this.transmitPower_CB.TabIndex = 3;
            // 
            // transmitPowerLabel
            // 
            this.transmitPowerLabel.Location = new System.Drawing.Point(6, 47);
            this.transmitPowerLabel.Name = "transmitPowerLabel";
            this.transmitPowerLabel.Size = new System.Drawing.Size(91, 30);
            this.transmitPowerLabel.TabIndex = 4;
            this.transmitPowerLabel.Text = "Transmit Power(100*dBm)";
            // 
            // receiveSensitivity_CB
            // 
            this.receiveSensitivity_CB.FormattingEnabled = true;
            this.receiveSensitivity_CB.Location = new System.Drawing.Point(103, 19);
            this.receiveSensitivity_CB.Name = "receiveSensitivity_CB";
            this.receiveSensitivity_CB.Size = new System.Drawing.Size(121, 21);
            this.receiveSensitivity_CB.TabIndex = 2;
            // 
            // receiveSenLabel
            // 
            this.receiveSenLabel.Location = new System.Drawing.Point(6, 11);
            this.receiveSenLabel.Name = "receiveSenLabel";
            this.receiveSenLabel.Size = new System.Drawing.Size(82, 29);
            this.receiveSenLabel.TabIndex = 2;
            this.receiveSenLabel.Text = "Receive Sensitivity (dB)";
            // 
            // hopTable_GB
            // 
            this.hopTable_GB.Controls.Add(this.hopFrequencies_TB);
            this.hopTable_GB.Controls.Add(this.hopTableIndex_CB);
            this.hopTable_GB.Controls.Add(this.hopTableIndexLabel);
            this.hopTable_GB.Location = new System.Drawing.Point(12, 137);
            this.hopTable_GB.Name = "hopTable_GB";
            this.hopTable_GB.Size = new System.Drawing.Size(245, 173);
            this.hopTable_GB.TabIndex = 4;
            this.hopTable_GB.TabStop = false;
            // 
            // hopFrequencies_TB
            // 
            this.hopFrequencies_TB.Location = new System.Drawing.Point(10, 48);
            this.hopFrequencies_TB.MaxLength = 90000;
            this.hopFrequencies_TB.Multiline = true;
            this.hopFrequencies_TB.Name = "hopFrequencies_TB";
            this.hopFrequencies_TB.ReadOnly = true;
            this.hopFrequencies_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hopFrequencies_TB.Size = new System.Drawing.Size(230, 111);
            this.hopFrequencies_TB.TabIndex = 7;
            // 
            // hopTableIndex_CB
            // 
            this.hopTableIndex_CB.FormattingEnabled = true;
            this.hopTableIndex_CB.Location = new System.Drawing.Point(103, 19);
            this.hopTableIndex_CB.Name = "hopTableIndex_CB";
            this.hopTableIndex_CB.Size = new System.Drawing.Size(121, 21);
            this.hopTableIndex_CB.TabIndex = 3;
            this.hopTableIndex_CB.SelectedIndexChanged += new System.EventHandler(this.hopTableIndex_CB_SelectedIndexChanged);
            // 
            // hopTableIndexLabel
            // 
            this.hopTableIndexLabel.Location = new System.Drawing.Point(11, 22);
            this.hopTableIndexLabel.Name = "hopTableIndexLabel";
            this.hopTableIndexLabel.Size = new System.Drawing.Size(94, 23);
            this.hopTableIndexLabel.TabIndex = 2;
            this.hopTableIndexLabel.Text = "Hop Table Index";
            // 
            // FrequencyHeader
            // 
            this.FrequencyHeader.Text = "Frequencies";
            this.FrequencyHeader.Width = 97;
            // 
            // antennaConfigButton
            // 
            this.antennaConfigButton.Location = new System.Drawing.Point(182, 316);
            this.antennaConfigButton.Name = "antennaConfigButton";
            this.antennaConfigButton.Size = new System.Drawing.Size(75, 23);
            this.antennaConfigButton.TabIndex = 5;
            this.antennaConfigButton.Text = "Apply";
            this.antennaConfigButton.UseVisualStyleBackColor = true;
            this.antennaConfigButton.Click += new System.EventHandler(this.antennaConfigButton_Click);
            // 
            // transmitFreq_GB
            // 
            this.transmitFreq_GB.Controls.Add(this.transmitFreq_CB);
            this.transmitFreq_GB.Controls.Add(this.label1);
            this.transmitFreq_GB.Location = new System.Drawing.Point(12, 137);
            this.transmitFreq_GB.Name = "transmitFreq_GB";
            this.transmitFreq_GB.Size = new System.Drawing.Size(244, 86);
            this.transmitFreq_GB.TabIndex = 6;
            this.transmitFreq_GB.TabStop = false;
            // 
            // transmitFreq_CB
            // 
            this.transmitFreq_CB.FormattingEnabled = true;
            this.transmitFreq_CB.Location = new System.Drawing.Point(103, 36);
            this.transmitFreq_CB.Name = "transmitFreq_CB";
            this.transmitFreq_CB.Size = new System.Drawing.Size(121, 21);
            this.transmitFreq_CB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transmit Frequency";
            // 
            // AntennaConfigForm
            // 
            this.AcceptButton = this.antennaConfigButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 348);
            this.Controls.Add(this.antennaConfigButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.antennaID_CB);
            this.Controls.Add(this.antennaIDLlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AntennaConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AntennaConfig";
            this.Load += new System.EventHandler(this.AntennaConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.hopTable_GB.ResumeLayout(false);
            this.hopTable_GB.PerformLayout();
            this.transmitFreq_GB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label antennaIDLlabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label transmitPowerLabel;
        private System.Windows.Forms.Label receiveSenLabel;
        private System.Windows.Forms.GroupBox hopTable_GB;
        private System.Windows.Forms.Label hopTableIndexLabel;
        private System.Windows.Forms.Button antennaConfigButton;
        private System.Windows.Forms.ColumnHeader FrequencyHeader;
        internal System.Windows.Forms.ComboBox antennaID_CB;
        internal System.Windows.Forms.ComboBox transmitPower_CB;
        internal System.Windows.Forms.ComboBox receiveSensitivity_CB;
        internal System.Windows.Forms.ComboBox hopTableIndex_CB;
        private System.Windows.Forms.GroupBox transmitFreq_GB;
        internal System.Windows.Forms.ComboBox transmitFreq_CB;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox hopFrequencies_TB;
    }
}