namespace CS_RFID3_Host_Sample2
{
    partial class ReadForm
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
            this.tagID_TB = new System.Windows.Forms.TextBox();
            this.tagMaskLabel = new System.Windows.Forms.Label();
            this.offset_TB = new System.Windows.Forms.TextBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.memBank_CB = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.length_TB = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.accessFilterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.ReadData_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tagID_TB
            // 
            this.tagID_TB.Location = new System.Drawing.Point(90, 12);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(191, 20);
            this.tagID_TB.TabIndex = 1;
            this.tagID_TB.TextChanged += new System.EventHandler(this.tagID_TB_TextChanged);
            // 
            // tagMaskLabel
            // 
            this.tagMaskLabel.AutoSize = true;
            this.tagMaskLabel.Location = new System.Drawing.Point(13, 15);
            this.tagMaskLabel.Name = "tagMaskLabel";
            this.tagMaskLabel.Size = new System.Drawing.Size(68, 13);
            this.tagMaskLabel.TabIndex = 19;
            this.tagMaskLabel.Text = "Tag ID (Hex)";
            // 
            // offset_TB
            // 
            this.offset_TB.Location = new System.Drawing.Point(90, 134);
            this.offset_TB.Name = "offset_TB";
            this.offset_TB.Size = new System.Drawing.Size(40, 20);
            this.offset_TB.TabIndex = 4;
            this.offset_TB.TextChanged += new System.EventHandler(this.offset_TB_TextChanged);
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(13, 137);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(70, 13);
            this.offsetLabel.TabIndex = 17;
            this.offsetLabel.Text = "Offset (Bytes)";
            // 
            // memBank_CB
            // 
            this.memBank_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memBank_CB.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB.FormattingEnabled = true;
            this.memBank_CB.Items.AddRange(new object[] {
            "RESERVED",
            "EPC",
            "TID",
            "USER"});
            this.memBank_CB.Location = new System.Drawing.Point(90, 90);
            this.memBank_CB.Name = "memBank_CB";
            this.memBank_CB.Size = new System.Drawing.Size(110, 21);
            this.memBank_CB.TabIndex = 3;
            this.memBank_CB.SelectedIndexChanged += new System.EventHandler(this.memBank_CB_SelectedIndexChanged);
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(13, 93);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 15;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // length_TB
            // 
            this.length_TB.Location = new System.Drawing.Point(241, 134);
            this.length_TB.Name = "length_TB";
            this.length_TB.Size = new System.Drawing.Size(40, 20);
            this.length_TB.TabIndex = 5;
            this.length_TB.TextChanged += new System.EventHandler(this.length_TB_TextChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(137, 137);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(101, 13);
            this.lengthLabel.TabIndex = 21;
            this.lengthLabel.Text = "No. of Bytes Length";
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(206, 282);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 7;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // accessFilterButton
            // 
            this.accessFilterButton.Location = new System.Drawing.Point(125, 282);
            this.accessFilterButton.Name = "accessFilterButton";
            this.accessFilterButton.Size = new System.Drawing.Size(75, 23);
            this.accessFilterButton.TabIndex = 6;
            this.accessFilterButton.Text = "Access Filter";
            this.accessFilterButton.UseVisualStyleBackColor = true;
            this.accessFilterButton.Click += new System.EventHandler(this.accessFilterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Password (Hex)";
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(90, 49);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(191, 20);
            this.Password_TB.TabIndex = 2;
            // 
            // ReadData_TB
            // 
            this.ReadData_TB.Location = new System.Drawing.Point(16, 184);
            this.ReadData_TB.Multiline = true;
            this.ReadData_TB.Name = "ReadData_TB";
            this.ReadData_TB.ReadOnly = true;
            this.ReadData_TB.Size = new System.Drawing.Size(265, 84);
            this.ReadData_TB.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Data Read (Hex)";
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 317);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReadData_TB);
            this.Controls.Add(this.Password_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessFilterButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.length_TB);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.tagID_TB);
            this.Controls.Add(this.tagMaskLabel);
            this.Controls.Add(this.offset_TB);
            this.Controls.Add(this.offsetLabel);
            this.Controls.Add(this.memBank_CB);
            this.Controls.Add(this.memBankLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Read Tag";
            this.Load += new System.EventHandler(this.Read_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tagID_TB;
        private System.Windows.Forms.Label tagMaskLabel;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.Label memBankLabel1;
        private System.Windows.Forms.Label lengthLabel;
        internal System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button accessFilterButton;
        internal System.Windows.Forms.TextBox offset_TB;
        internal System.Windows.Forms.TextBox length_TB;
        internal System.Windows.Forms.ComboBox memBank_CB;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox Password_TB;
        public System.Windows.Forms.TextBox ReadData_TB;
        private System.Windows.Forms.Label label2;
    }
}