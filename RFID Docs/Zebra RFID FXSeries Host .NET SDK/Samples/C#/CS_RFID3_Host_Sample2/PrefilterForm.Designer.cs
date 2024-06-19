namespace CS_RFID3_Host_Sample2
{
    partial class PreFilterForm
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
            this.filterGroupBox1 = new System.Windows.Forms.GroupBox();
            this.antennaID_CB1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.target_CB1 = new System.Windows.Forms.ComboBox();
            this.targetLabel1 = new System.Windows.Forms.Label();
            this.action_CB1 = new System.Windows.Forms.ComboBox();
            this.actionLabel1 = new System.Windows.Forms.Label();
            this.filterAction_CB1 = new System.Windows.Forms.ComboBox();
            this.filterActionLabel1 = new System.Windows.Forms.Label();
            this.tagMask_TB1 = new System.Windows.Forms.TextBox();
            this.tagMaskLabel1 = new System.Windows.Forms.Label();
            this.offset_TB1 = new System.Windows.Forms.TextBox();
            this.offsetLabel1 = new System.Windows.Forms.Label();
            this.memBank_CB1 = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.filter_CB1 = new System.Windows.Forms.CheckBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.filterGroupBox2 = new System.Windows.Forms.GroupBox();
            this.antennaID_CB2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.target_CB2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.action_CB2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filterAction_CB2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tagMask_TB2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.offset_TB2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.memBank_CB2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.filter_CB2 = new System.Windows.Forms.CheckBox();
            this.filterGroupBox1.SuspendLayout();
            this.filterGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterGroupBox1
            // 
            this.filterGroupBox1.Controls.Add(this.antennaID_CB1);
            this.filterGroupBox1.Controls.Add(this.label1);
            this.filterGroupBox1.Controls.Add(this.target_CB1);
            this.filterGroupBox1.Controls.Add(this.targetLabel1);
            this.filterGroupBox1.Controls.Add(this.action_CB1);
            this.filterGroupBox1.Controls.Add(this.actionLabel1);
            this.filterGroupBox1.Controls.Add(this.filterAction_CB1);
            this.filterGroupBox1.Controls.Add(this.filterActionLabel1);
            this.filterGroupBox1.Controls.Add(this.tagMask_TB1);
            this.filterGroupBox1.Controls.Add(this.tagMaskLabel1);
            this.filterGroupBox1.Controls.Add(this.offset_TB1);
            this.filterGroupBox1.Controls.Add(this.offsetLabel1);
            this.filterGroupBox1.Controls.Add(this.memBank_CB1);
            this.filterGroupBox1.Controls.Add(this.memBankLabel1);
            this.filterGroupBox1.Controls.Add(this.filter_CB1);
            this.filterGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.filterGroupBox1.Name = "filterGroupBox1";
            this.filterGroupBox1.Size = new System.Drawing.Size(289, 165);
            this.filterGroupBox1.TabIndex = 0;
            this.filterGroupBox1.TabStop = false;
            this.filterGroupBox1.Text = "1st Filter";
            // 
            // antennaID_CB1
            // 
            this.antennaID_CB1.Enabled = false;
            this.antennaID_CB1.ForeColor = System.Drawing.Color.Navy;
            this.antennaID_CB1.FormattingEnabled = true;
            this.antennaID_CB1.Location = new System.Drawing.Point(67, 28);
            this.antennaID_CB1.Name = "antennaID_CB1";
            this.antennaID_CB1.Size = new System.Drawing.Size(46, 21);
            this.antennaID_CB1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Antenna ID";
            // 
            // target_CB1
            // 
            this.target_CB1.Enabled = false;
            this.target_CB1.ForeColor = System.Drawing.Color.Navy;
            this.target_CB1.FormattingEnabled = true;
            this.target_CB1.Items.AddRange(new object[] {
            "S0",
            "S1",
            "S2",
            "S3"});
            this.target_CB1.Location = new System.Drawing.Point(238, 136);
            this.target_CB1.Name = "target_CB1";
            this.target_CB1.Size = new System.Drawing.Size(44, 21);
            this.target_CB1.TabIndex = 8;
            // 
            // targetLabel1
            // 
            this.targetLabel1.AutoSize = true;
            this.targetLabel1.Location = new System.Drawing.Point(197, 139);
            this.targetLabel1.Name = "targetLabel1";
            this.targetLabel1.Size = new System.Drawing.Size(38, 13);
            this.targetLabel1.TabIndex = 19;
            this.targetLabel1.Text = "Target";
            // 
            // action_CB1
            // 
            this.action_CB1.Enabled = false;
            this.action_CB1.ForeColor = System.Drawing.Color.Navy;
            this.action_CB1.FormattingEnabled = true;
            this.action_CB1.Location = new System.Drawing.Point(50, 134);
            this.action_CB1.Name = "action_CB1";
            this.action_CB1.Size = new System.Drawing.Size(141, 21);
            this.action_CB1.TabIndex = 7;
            // 
            // actionLabel1
            // 
            this.actionLabel1.AutoSize = true;
            this.actionLabel1.Location = new System.Drawing.Point(6, 139);
            this.actionLabel1.Name = "actionLabel1";
            this.actionLabel1.Size = new System.Drawing.Size(37, 13);
            this.actionLabel1.TabIndex = 17;
            this.actionLabel1.Text = "Action";
            // 
            // filterAction_CB1
            // 
            this.filterAction_CB1.Enabled = false;
            this.filterAction_CB1.ForeColor = System.Drawing.Color.Navy;
            this.filterAction_CB1.FormattingEnabled = true;
            this.filterAction_CB1.Items.AddRange(new object[] {
            "DEFAULT",
            "STATE AWARE",
            "STATE UNAWARE"});
            this.filterAction_CB1.Location = new System.Drawing.Point(67, 98);
            this.filterAction_CB1.Name = "filterAction_CB1";
            this.filterAction_CB1.Size = new System.Drawing.Size(124, 21);
            this.filterAction_CB1.TabIndex = 6;
            this.filterAction_CB1.SelectedIndexChanged += new System.EventHandler(this.filterAction_CB1_SelectedIndexChanged);
            // 
            // filterActionLabel1
            // 
            this.filterActionLabel1.AutoSize = true;
            this.filterActionLabel1.Location = new System.Drawing.Point(6, 101);
            this.filterActionLabel1.Name = "filterActionLabel1";
            this.filterActionLabel1.Size = new System.Drawing.Size(62, 13);
            this.filterActionLabel1.TabIndex = 15;
            this.filterActionLabel1.Text = "Filter Action";
            // 
            // tagMask_TB1
            // 
            this.tagMask_TB1.Enabled = false;
            this.tagMask_TB1.Location = new System.Drawing.Point(67, 60);
            this.tagMask_TB1.Name = "tagMask_TB1";
            this.tagMask_TB1.Size = new System.Drawing.Size(124, 20);
            this.tagMask_TB1.TabIndex = 4;
            // 
            // tagMaskLabel1
            // 
            this.tagMaskLabel1.AutoSize = true;
            this.tagMaskLabel1.Location = new System.Drawing.Point(6, 63);
            this.tagMaskLabel1.Name = "tagMaskLabel1";
            this.tagMaskLabel1.Size = new System.Drawing.Size(63, 13);
            this.tagMaskLabel1.TabIndex = 13;
            this.tagMaskLabel1.Text = "Tag Pattern";
            // 
            // offset_TB1
            // 
            this.offset_TB1.Enabled = false;
            this.offset_TB1.Location = new System.Drawing.Point(253, 60);
            this.offset_TB1.Name = "offset_TB1";
            this.offset_TB1.Size = new System.Drawing.Size(29, 20);
            this.offset_TB1.TabIndex = 5;
            // 
            // offsetLabel1
            // 
            this.offsetLabel1.AutoSize = true;
            this.offsetLabel1.Location = new System.Drawing.Point(197, 63);
            this.offsetLabel1.Name = "offsetLabel1";
            this.offsetLabel1.Size = new System.Drawing.Size(58, 13);
            this.offsetLabel1.TabIndex = 11;
            this.offsetLabel1.Text = "Offset(Bits)";
            // 
            // memBank_CB1
            // 
            this.memBank_CB1.Enabled = false;
            this.memBank_CB1.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB1.FormattingEnabled = true;
            this.memBank_CB1.Items.AddRange(new object[] {
            "EPC",
            "TID",
            "USER"});
            this.memBank_CB1.Location = new System.Drawing.Point(194, 28);
            this.memBank_CB1.Name = "memBank_CB1";
            this.memBank_CB1.Size = new System.Drawing.Size(88, 21);
            this.memBank_CB1.TabIndex = 3;
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(122, 31);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 9;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // filter_CB1
            // 
            this.filter_CB1.AutoSize = true;
            this.filter_CB1.Location = new System.Drawing.Point(50, 0);
            this.filter_CB1.Name = "filter_CB1";
            this.filter_CB1.Size = new System.Drawing.Size(15, 14);
            this.filter_CB1.TabIndex = 1;
            this.filter_CB1.UseVisualStyleBackColor = true;
            this.filter_CB1.CheckedChanged += new System.EventHandler(this.filter_CB1_CheckedChanged);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(226, 354);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 17;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // filterGroupBox2
            // 
            this.filterGroupBox2.Controls.Add(this.antennaID_CB2);
            this.filterGroupBox2.Controls.Add(this.label2);
            this.filterGroupBox2.Controls.Add(this.target_CB2);
            this.filterGroupBox2.Controls.Add(this.label3);
            this.filterGroupBox2.Controls.Add(this.action_CB2);
            this.filterGroupBox2.Controls.Add(this.label4);
            this.filterGroupBox2.Controls.Add(this.filterAction_CB2);
            this.filterGroupBox2.Controls.Add(this.label5);
            this.filterGroupBox2.Controls.Add(this.tagMask_TB2);
            this.filterGroupBox2.Controls.Add(this.label6);
            this.filterGroupBox2.Controls.Add(this.offset_TB2);
            this.filterGroupBox2.Controls.Add(this.label7);
            this.filterGroupBox2.Controls.Add(this.memBank_CB2);
            this.filterGroupBox2.Controls.Add(this.label8);
            this.filterGroupBox2.Controls.Add(this.filter_CB2);
            this.filterGroupBox2.Location = new System.Drawing.Point(12, 183);
            this.filterGroupBox2.Name = "filterGroupBox2";
            this.filterGroupBox2.Size = new System.Drawing.Size(289, 165);
            this.filterGroupBox2.TabIndex = 3;
            this.filterGroupBox2.TabStop = false;
            this.filterGroupBox2.Text = "2nd Filter";
            // 
            // antennaID_CB2
            // 
            this.antennaID_CB2.Enabled = false;
            this.antennaID_CB2.ForeColor = System.Drawing.Color.Navy;
            this.antennaID_CB2.FormattingEnabled = true;
            this.antennaID_CB2.Location = new System.Drawing.Point(67, 28);
            this.antennaID_CB2.Name = "antennaID_CB2";
            this.antennaID_CB2.Size = new System.Drawing.Size(46, 21);
            this.antennaID_CB2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Antenna ID";
            // 
            // target_CB2
            // 
            this.target_CB2.Enabled = false;
            this.target_CB2.ForeColor = System.Drawing.Color.Navy;
            this.target_CB2.FormattingEnabled = true;
            this.target_CB2.Items.AddRange(new object[] {
            "S0",
            "S1",
            "S2",
            "S3"});
            this.target_CB2.Location = new System.Drawing.Point(238, 136);
            this.target_CB2.Name = "target_CB2";
            this.target_CB2.Size = new System.Drawing.Size(44, 21);
            this.target_CB2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Target";
            // 
            // action_CB2
            // 
            this.action_CB2.Enabled = false;
            this.action_CB2.ForeColor = System.Drawing.Color.Navy;
            this.action_CB2.FormattingEnabled = true;
            this.action_CB2.Location = new System.Drawing.Point(50, 134);
            this.action_CB2.Name = "action_CB2";
            this.action_CB2.Size = new System.Drawing.Size(141, 21);
            this.action_CB2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Action";
            // 
            // filterAction_CB2
            // 
            this.filterAction_CB2.Enabled = false;
            this.filterAction_CB2.ForeColor = System.Drawing.Color.Navy;
            this.filterAction_CB2.FormattingEnabled = true;
            this.filterAction_CB2.Items.AddRange(new object[] {
            "DEFAULT",
            "STATE AWARE",
            "STATE UNAWARE"});
            this.filterAction_CB2.Location = new System.Drawing.Point(67, 98);
            this.filterAction_CB2.Name = "filterAction_CB2";
            this.filterAction_CB2.Size = new System.Drawing.Size(124, 21);
            this.filterAction_CB2.TabIndex = 14;
            this.filterAction_CB2.SelectedIndexChanged += new System.EventHandler(this.filterAction_CB2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Filter Action";
            // 
            // tagMask_TB2
            // 
            this.tagMask_TB2.Enabled = false;
            this.tagMask_TB2.Location = new System.Drawing.Point(67, 60);
            this.tagMask_TB2.Name = "tagMask_TB2";
            this.tagMask_TB2.Size = new System.Drawing.Size(124, 20);
            this.tagMask_TB2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tag Pattern";
            // 
            // offset_TB2
            // 
            this.offset_TB2.Enabled = false;
            this.offset_TB2.Location = new System.Drawing.Point(253, 60);
            this.offset_TB2.Name = "offset_TB2";
            this.offset_TB2.Size = new System.Drawing.Size(29, 20);
            this.offset_TB2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Offset(Bits)";
            // 
            // memBank_CB2
            // 
            this.memBank_CB2.Enabled = false;
            this.memBank_CB2.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB2.FormattingEnabled = true;
            this.memBank_CB2.Items.AddRange(new object[] {
            "EPC",
            "TID",
            "USER"});
            this.memBank_CB2.Location = new System.Drawing.Point(194, 28);
            this.memBank_CB2.Name = "memBank_CB2";
            this.memBank_CB2.Size = new System.Drawing.Size(88, 21);
            this.memBank_CB2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Memory Bank";
            // 
            // filter_CB2
            // 
            this.filter_CB2.AutoSize = true;
            this.filter_CB2.Location = new System.Drawing.Point(53, 0);
            this.filter_CB2.Name = "filter_CB2";
            this.filter_CB2.Size = new System.Drawing.Size(15, 14);
            this.filter_CB2.TabIndex = 9;
            this.filter_CB2.UseVisualStyleBackColor = true;
            this.filter_CB2.CheckedChanged += new System.EventHandler(this.filter_CB2_CheckedChanged);
            // 
            // PreFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 388);
            this.Controls.Add(this.filterGroupBox2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.filterGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pre-Filter";
            this.Load += new System.EventHandler(this.PreFilter_Load);
            this.filterGroupBox1.ResumeLayout(false);
            this.filterGroupBox1.PerformLayout();
            this.filterGroupBox2.ResumeLayout(false);
            this.filterGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filterGroupBox1;
        private System.Windows.Forms.CheckBox filter_CB1;
        private System.Windows.Forms.ComboBox memBank_CB1;
        private System.Windows.Forms.Label memBankLabel1;
        private System.Windows.Forms.TextBox offset_TB1;
        private System.Windows.Forms.Label offsetLabel1;
        private System.Windows.Forms.TextBox tagMask_TB1;
        private System.Windows.Forms.Label tagMaskLabel1;
        private System.Windows.Forms.ComboBox filterAction_CB1;
        private System.Windows.Forms.Label filterActionLabel1;
        private System.Windows.Forms.Label actionLabel1;
        private System.Windows.Forms.ComboBox target_CB1;
        private System.Windows.Forms.Label targetLabel1;
        private System.Windows.Forms.ComboBox action_CB1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ComboBox antennaID_CB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox filterGroupBox2;
        private System.Windows.Forms.ComboBox antennaID_CB2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox target_CB2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox action_CB2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox filterAction_CB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tagMask_TB2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox offset_TB2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox memBank_CB2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox filter_CB2;

    }
}