namespace CS_RFID3_Host_Sample2
{
    partial class AccessFilterForm
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
            this.tagPatternB_GB = new System.Windows.Forms.GroupBox();
            this.tagMask_TB2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.memBankData_TB2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.offset_TB2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.memBank_CB2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.matchPattern_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.tagPatternA_GB = new System.Windows.Forms.GroupBox();
            this.tagMask_TB1 = new System.Windows.Forms.TextBox();
            this.filterActionLabel1 = new System.Windows.Forms.Label();
            this.memBankData_TB1 = new System.Windows.Forms.TextBox();
            this.tagMaskLabel1 = new System.Windows.Forms.Label();
            this.offset_TB1 = new System.Windows.Forms.TextBox();
            this.offsetLabel1 = new System.Windows.Forms.Label();
            this.memBank_CB1 = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.accessFilter_CB1 = new System.Windows.Forms.CheckBox();
            this.tagPatternB_GB.SuspendLayout();
            this.tagPatternA_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagPatternB_GB
            // 
            this.tagPatternB_GB.Controls.Add(this.tagMask_TB2);
            this.tagPatternB_GB.Controls.Add(this.label2);
            this.tagPatternB_GB.Controls.Add(this.memBankData_TB2);
            this.tagPatternB_GB.Controls.Add(this.label3);
            this.tagPatternB_GB.Controls.Add(this.offset_TB2);
            this.tagPatternB_GB.Controls.Add(this.label4);
            this.tagPatternB_GB.Controls.Add(this.memBank_CB2);
            this.tagPatternB_GB.Controls.Add(this.label5);
            this.tagPatternB_GB.Location = new System.Drawing.Point(12, 171);
            this.tagPatternB_GB.Name = "tagPatternB_GB";
            this.tagPatternB_GB.Size = new System.Drawing.Size(279, 104);
            this.tagPatternB_GB.TabIndex = 13;
            this.tagPatternB_GB.TabStop = false;
            this.tagPatternB_GB.Text = "Tag Pattern B";
            // 
            // tagMask_TB2
            // 
            this.tagMask_TB2.Location = new System.Drawing.Point(84, 73);
            this.tagMask_TB2.Name = "tagMask_TB2";
            this.tagMask_TB2.Size = new System.Drawing.Size(184, 20);
            this.tagMask_TB2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tag Mask";
            // 
            // memBankData_TB2
            // 
            this.memBankData_TB2.Location = new System.Drawing.Point(84, 47);
            this.memBankData_TB2.Name = "memBankData_TB2";
            this.memBankData_TB2.Size = new System.Drawing.Size(184, 20);
            this.memBankData_TB2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tag Pattern";
            // 
            // offset_TB2
            // 
            this.offset_TB2.Location = new System.Drawing.Point(223, 19);
            this.offset_TB2.Name = "offset_TB2";
            this.offset_TB2.Size = new System.Drawing.Size(45, 20);
            this.offset_TB2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bit Offset";
            // 
            // memBank_CB2
            // 
            this.memBank_CB2.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB2.FormattingEnabled = true;
            this.memBank_CB2.Items.AddRange(new object[] {
            "RESERVED",
            "EPC",
            "TID",
            "USER"});
            this.memBank_CB2.Location = new System.Drawing.Point(84, 17);
            this.memBank_CB2.Name = "memBank_CB2";
            this.memBank_CB2.Size = new System.Drawing.Size(82, 21);
            this.memBank_CB2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Memory Bank";
            // 
            // matchPattern_CB
            // 
            this.matchPattern_CB.FormattingEnabled = true;
            this.matchPattern_CB.Items.AddRange(new object[] {
            "A AND B",
            "NOT A AND B",
            "NOT A AND NOT B",
            "A AND NOT B ",
            "A"});
            this.matchPattern_CB.Location = new System.Drawing.Point(105, 33);
            this.matchPattern_CB.Name = "matchPattern_CB";
            this.matchPattern_CB.Size = new System.Drawing.Size(121, 21);
            this.matchPattern_CB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Match Pattern";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(214, 281);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 10;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // tagPatternA_GB
            // 
            this.tagPatternA_GB.Controls.Add(this.tagMask_TB1);
            this.tagPatternA_GB.Controls.Add(this.filterActionLabel1);
            this.tagPatternA_GB.Controls.Add(this.memBankData_TB1);
            this.tagPatternA_GB.Controls.Add(this.tagMaskLabel1);
            this.tagPatternA_GB.Controls.Add(this.offset_TB1);
            this.tagPatternA_GB.Controls.Add(this.offsetLabel1);
            this.tagPatternA_GB.Controls.Add(this.memBank_CB1);
            this.tagPatternA_GB.Controls.Add(this.memBankLabel1);
            this.tagPatternA_GB.Location = new System.Drawing.Point(12, 60);
            this.tagPatternA_GB.Name = "tagPatternA_GB";
            this.tagPatternA_GB.Size = new System.Drawing.Size(279, 105);
            this.tagPatternA_GB.TabIndex = 9;
            this.tagPatternA_GB.TabStop = false;
            this.tagPatternA_GB.Text = "Tag Pattern A";
            // 
            // tagMask_TB1
            // 
            this.tagMask_TB1.Location = new System.Drawing.Point(84, 75);
            this.tagMask_TB1.Name = "tagMask_TB1";
            this.tagMask_TB1.Size = new System.Drawing.Size(184, 20);
            this.tagMask_TB1.TabIndex = 5;
            // 
            // filterActionLabel1
            // 
            this.filterActionLabel1.AutoSize = true;
            this.filterActionLabel1.Location = new System.Drawing.Point(6, 78);
            this.filterActionLabel1.Name = "filterActionLabel1";
            this.filterActionLabel1.Size = new System.Drawing.Size(55, 13);
            this.filterActionLabel1.TabIndex = 15;
            this.filterActionLabel1.Text = "Tag Mask";
            // 
            // memBankData_TB1
            // 
            this.memBankData_TB1.Location = new System.Drawing.Point(84, 49);
            this.memBankData_TB1.Name = "memBankData_TB1";
            this.memBankData_TB1.Size = new System.Drawing.Size(184, 20);
            this.memBankData_TB1.TabIndex = 4;
            // 
            // tagMaskLabel1
            // 
            this.tagMaskLabel1.AutoSize = true;
            this.tagMaskLabel1.Location = new System.Drawing.Point(6, 52);
            this.tagMaskLabel1.Name = "tagMaskLabel1";
            this.tagMaskLabel1.Size = new System.Drawing.Size(63, 13);
            this.tagMaskLabel1.TabIndex = 13;
            this.tagMaskLabel1.Text = "Tag Pattern";
            // 
            // offset_TB1
            // 
            this.offset_TB1.Location = new System.Drawing.Point(223, 19);
            this.offset_TB1.Name = "offset_TB1";
            this.offset_TB1.Size = new System.Drawing.Size(45, 20);
            this.offset_TB1.TabIndex = 3;
            // 
            // offsetLabel1
            // 
            this.offsetLabel1.AutoSize = true;
            this.offsetLabel1.Location = new System.Drawing.Point(172, 22);
            this.offsetLabel1.Name = "offsetLabel1";
            this.offsetLabel1.Size = new System.Drawing.Size(50, 13);
            this.offsetLabel1.TabIndex = 11;
            this.offsetLabel1.Text = "Bit Offset";
            // 
            // memBank_CB1
            // 
            this.memBank_CB1.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB1.FormattingEnabled = true;
            this.memBank_CB1.Items.AddRange(new object[] {
            "RESERVED",
            "EPC",
            "TID",
            "USER"});
            this.memBank_CB1.Location = new System.Drawing.Point(84, 19);
            this.memBank_CB1.Name = "memBank_CB1";
            this.memBank_CB1.Size = new System.Drawing.Size(82, 21);
            this.memBank_CB1.TabIndex = 2;
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(6, 23);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 9;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // accessFilter_CB1
            // 
            this.accessFilter_CB1.AutoSize = true;
            this.accessFilter_CB1.Location = new System.Drawing.Point(12, 10);
            this.accessFilter_CB1.Name = "accessFilter_CB1";
            this.accessFilter_CB1.Size = new System.Drawing.Size(70, 17);
            this.accessFilter_CB1.TabIndex = 14;
            this.accessFilter_CB1.Text = "Use Filter";
            this.accessFilter_CB1.UseVisualStyleBackColor = true;
            this.accessFilter_CB1.CheckedChanged += new System.EventHandler(this.accessFilter_CB1_CheckedChanged);
            // 
            // AccessFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 308);
            this.Controls.Add(this.accessFilter_CB1);
            this.Controls.Add(this.tagPatternB_GB);
            this.Controls.Add(this.matchPattern_CB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.tagPatternA_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AccessFilter";
            this.Load += new System.EventHandler(this.AccessFilter_Load);
            this.tagPatternB_GB.ResumeLayout(false);
            this.tagPatternB_GB.PerformLayout();
            this.tagPatternA_GB.ResumeLayout(false);
            this.tagPatternA_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tagPatternB_GB;
        private System.Windows.Forms.TextBox tagMask_TB2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox memBankData_TB2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox offset_TB2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox memBank_CB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox matchPattern_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox tagPatternA_GB;
        private System.Windows.Forms.TextBox tagMask_TB1;
        private System.Windows.Forms.Label filterActionLabel1;
        private System.Windows.Forms.TextBox memBankData_TB1;
        private System.Windows.Forms.Label tagMaskLabel1;
        private System.Windows.Forms.TextBox offset_TB1;
        private System.Windows.Forms.Label offsetLabel1;
        private System.Windows.Forms.ComboBox memBank_CB1;
        private System.Windows.Forms.Label memBankLabel1;
        private System.Windows.Forms.CheckBox accessFilter_CB1;
    }
}