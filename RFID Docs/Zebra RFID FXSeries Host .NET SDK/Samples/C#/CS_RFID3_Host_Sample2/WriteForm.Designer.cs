namespace CS_RFID3_Host_Sample2
{
    partial class WriteForm
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
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accessFilterButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.length_TB = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.tagID_TB = new System.Windows.Forms.TextBox();
            this.tagMaskLabel = new System.Windows.Forms.Label();
            this.offset_TB = new System.Windows.Forms.TextBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.memBank_CB = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(91, 61);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(191, 20);
            this.Password_TB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Password (Hex)";
            // 
            // accessFilterButton
            // 
            this.accessFilterButton.Location = new System.Drawing.Point(126, 257);
            this.accessFilterButton.Name = "accessFilterButton";
            this.accessFilterButton.Size = new System.Drawing.Size(75, 23);
            this.accessFilterButton.TabIndex = 7;
            this.accessFilterButton.Text = "Access Filter";
            this.accessFilterButton.UseVisualStyleBackColor = true;
            this.accessFilterButton.Click += new System.EventHandler(this.accessFilterButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(207, 257);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(75, 23);
            this.writeButton.TabIndex = 8;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // length_TB
            // 
            this.length_TB.Location = new System.Drawing.Point(242, 147);
            this.length_TB.Name = "length_TB";
            this.length_TB.Size = new System.Drawing.Size(40, 20);
            this.length_TB.TabIndex = 5;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(138, 150);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(101, 13);
            this.lengthLabel.TabIndex = 34;
            this.lengthLabel.Text = "No. of Bytes Length";
            // 
            // tagID_TB
            // 
            this.tagID_TB.Location = new System.Drawing.Point(91, 21);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(191, 20);
            this.tagID_TB.TabIndex = 1;
            this.tagID_TB.TextChanged += new System.EventHandler(this.tagID_TB_TextChanged);
            // 
            // tagMaskLabel
            // 
            this.tagMaskLabel.AutoSize = true;
            this.tagMaskLabel.Location = new System.Drawing.Point(12, 24);
            this.tagMaskLabel.Name = "tagMaskLabel";
            this.tagMaskLabel.Size = new System.Drawing.Size(68, 13);
            this.tagMaskLabel.TabIndex = 33;
            this.tagMaskLabel.Text = "Tag ID (Hex)";
            // 
            // offset_TB
            // 
            this.offset_TB.Location = new System.Drawing.Point(91, 147);
            this.offset_TB.Name = "offset_TB";
            this.offset_TB.Size = new System.Drawing.Size(40, 20);
            this.offset_TB.TabIndex = 4;
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(12, 150);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(70, 13);
            this.offsetLabel.TabIndex = 32;
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
            this.memBank_CB.Location = new System.Drawing.Point(91, 103);
            this.memBank_CB.Name = "memBank_CB";
            this.memBank_CB.Size = new System.Drawing.Size(110, 21);
            this.memBank_CB.TabIndex = 3;
            this.memBank_CB.SelectedIndexChanged += new System.EventHandler(this.memBank_CB_SelectedIndexChanged);
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(12, 106);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 31;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Data (Hex)";
            // 
            // data_TB
            // 
            this.data_TB.Location = new System.Drawing.Point(91, 188);
            this.data_TB.Multiline = true;
            this.data_TB.Name = "data_TB";
            this.data_TB.Size = new System.Drawing.Size(191, 61);
            this.data_TB.TabIndex = 6;
            // 
            // WriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 292);
            this.Controls.Add(this.data_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Password_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessFilterButton);
            this.Controls.Add(this.writeButton);
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
            this.Name = "WriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Write/Block Write";
            this.Load += new System.EventHandler(this.Write_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button accessFilterButton;
        internal System.Windows.Forms.TextBox length_TB;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox tagID_TB;
        private System.Windows.Forms.Label tagMaskLabel;
        internal System.Windows.Forms.TextBox offset_TB;
        private System.Windows.Forms.Label offsetLabel;
        internal System.Windows.Forms.ComboBox memBank_CB;
        private System.Windows.Forms.Label memBankLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox data_TB;
        internal System.Windows.Forms.Button writeButton;
    }
}