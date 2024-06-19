namespace CS_RFID3_Host_Sample2
{
    partial class BlockEraseForm
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
            this.accessFilterButton = new System.Windows.Forms.Button();
            this.eraseButton = new System.Windows.Forms.Button();
            this.length_TB = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.tagID_TB = new System.Windows.Forms.TextBox();
            this.tagIDLabel = new System.Windows.Forms.Label();
            this.offset_TB = new System.Windows.Forms.TextBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.memBank_CB = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accessFilterButton
            // 
            this.accessFilterButton.Location = new System.Drawing.Point(115, 233);
            this.accessFilterButton.Name = "accessFilterButton";
            this.accessFilterButton.Size = new System.Drawing.Size(75, 23);
            this.accessFilterButton.TabIndex = 6;
            this.accessFilterButton.Text = "Access Filter";
            this.accessFilterButton.UseVisualStyleBackColor = true;
            this.accessFilterButton.Click += new System.EventHandler(this.accessFilterButton_Click);
            // 
            // eraseButton
            // 
            this.eraseButton.Location = new System.Drawing.Point(207, 233);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(75, 23);
            this.eraseButton.TabIndex = 7;
            this.eraseButton.Text = "Erase";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // length_TB
            // 
            this.length_TB.Location = new System.Drawing.Point(242, 138);
            this.length_TB.Name = "length_TB";
            this.length_TB.Size = new System.Drawing.Size(40, 20);
            this.length_TB.TabIndex = 5;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(139, 141);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(101, 13);
            this.lengthLabel.TabIndex = 43;
            this.lengthLabel.Text = "No. of Bytes Length";
            // 
            // tagID_TB
            // 
            this.tagID_TB.Location = new System.Drawing.Point(90, 19);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(192, 20);
            this.tagID_TB.TabIndex = 1;
            this.tagID_TB.TextChanged += new System.EventHandler(this.tagID_TB_TextChanged);
            // 
            // tagIDLabel
            // 
            this.tagIDLabel.AutoSize = true;
            this.tagIDLabel.Location = new System.Drawing.Point(12, 22);
            this.tagIDLabel.Name = "tagIDLabel";
            this.tagIDLabel.Size = new System.Drawing.Size(68, 13);
            this.tagIDLabel.TabIndex = 41;
            this.tagIDLabel.Text = "Tag ID (Hex)";
            // 
            // offset_TB
            // 
            this.offset_TB.Location = new System.Drawing.Point(90, 138);
            this.offset_TB.Name = "offset_TB";
            this.offset_TB.Size = new System.Drawing.Size(40, 20);
            this.offset_TB.TabIndex = 4;
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(12, 141);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(70, 13);
            this.offsetLabel.TabIndex = 39;
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
            this.memBank_CB.Location = new System.Drawing.Point(90, 97);
            this.memBank_CB.Name = "memBank_CB";
            this.memBank_CB.Size = new System.Drawing.Size(110, 21);
            this.memBank_CB.TabIndex = 3;
            this.memBank_CB.SelectedIndexChanged += new System.EventHandler(this.memBank_CB_SelectedIndexChanged);
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(12, 100);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 37;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(90, 58);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(192, 20);
            this.Password_TB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Password (Hex)";
            // 
            // BlockEraseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 268);
            this.Controls.Add(this.Password_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accessFilterButton);
            this.Controls.Add(this.eraseButton);
            this.Controls.Add(this.length_TB);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.tagID_TB);
            this.Controls.Add(this.tagIDLabel);
            this.Controls.Add(this.offset_TB);
            this.Controls.Add(this.offsetLabel);
            this.Controls.Add(this.memBank_CB);
            this.Controls.Add(this.memBankLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlockEraseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Block Erase";
            this.Load += new System.EventHandler(this.BlockErase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accessFilterButton;
        private System.Windows.Forms.TextBox length_TB;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox tagID_TB;
        private System.Windows.Forms.Label tagIDLabel;
        private System.Windows.Forms.TextBox offset_TB;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.ComboBox memBank_CB;
        private System.Windows.Forms.Label memBankLabel1;
        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button eraseButton;
    }
}