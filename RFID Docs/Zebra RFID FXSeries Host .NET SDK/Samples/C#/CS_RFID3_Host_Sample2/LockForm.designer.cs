namespace CS_RFID3_Host_Sample2
{
    partial class LockForm
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
            this.lockButton = new System.Windows.Forms.Button();
            this.lockPrivilege_CB = new System.Windows.Forms.ComboBox();
            this.lockPrivilegeLabel = new System.Windows.Forms.Label();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tagID_TB = new System.Windows.Forms.TextBox();
            this.tagMaskLabel = new System.Windows.Forms.Label();
            this.memBank_CB = new System.Windows.Forms.ComboBox();
            this.memBankLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accessFilterButton
            // 
            this.accessFilterButton.Location = new System.Drawing.Point(115, 229);
            this.accessFilterButton.Name = "accessFilterButton";
            this.accessFilterButton.Size = new System.Drawing.Size(75, 27);
            this.accessFilterButton.TabIndex = 5;
            this.accessFilterButton.Text = "Access Filter";
            this.accessFilterButton.UseVisualStyleBackColor = true;
            this.accessFilterButton.Click += new System.EventHandler(this.accessFilterButton_Click);
            // 
            // lockButton
            // 
            this.lockButton.Location = new System.Drawing.Point(206, 229);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(75, 27);
            this.lockButton.TabIndex = 6;
            this.lockButton.Text = "Lock";
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // lockPrivilege_CB
            // 
            this.lockPrivilege_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lockPrivilege_CB.ForeColor = System.Drawing.Color.Navy;
            this.lockPrivilege_CB.FormattingEnabled = true;
            this.lockPrivilege_CB.Items.AddRange(new object[] {
            "None",
            "Read & Write",
            "Perma Lock",
            "Perma Unlock",
            "Unlock"});
            this.lockPrivilege_CB.Location = new System.Drawing.Point(90, 145);
            this.lockPrivilege_CB.Name = "lockPrivilege_CB";
            this.lockPrivilege_CB.Size = new System.Drawing.Size(139, 21);
            this.lockPrivilege_CB.TabIndex = 4;
            // 
            // lockPrivilegeLabel
            // 
            this.lockPrivilegeLabel.AutoSize = true;
            this.lockPrivilegeLabel.Location = new System.Drawing.Point(9, 148);
            this.lockPrivilegeLabel.Name = "lockPrivilegeLabel";
            this.lockPrivilegeLabel.Size = new System.Drawing.Size(74, 13);
            this.lockPrivilegeLabel.TabIndex = 49;
            this.lockPrivilegeLabel.Text = "Lock Privilege";
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(90, 61);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(191, 20);
            this.Password_TB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Password (Hex)";
            // 
            // tagID_TB
            // 
            this.tagID_TB.Location = new System.Drawing.Point(90, 21);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(191, 20);
            this.tagID_TB.TabIndex = 1;
            this.tagID_TB.TextChanged += new System.EventHandler(this.taID_TB_TextChanged);
            // 
            // tagMaskLabel
            // 
            this.tagMaskLabel.AutoSize = true;
            this.tagMaskLabel.Location = new System.Drawing.Point(11, 24);
            this.tagMaskLabel.Name = "tagMaskLabel";
            this.tagMaskLabel.Size = new System.Drawing.Size(68, 13);
            this.tagMaskLabel.TabIndex = 56;
            this.tagMaskLabel.Text = "Tag ID (Hex)";
            // 
            // memBank_CB
            // 
            this.memBank_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memBank_CB.ForeColor = System.Drawing.Color.Navy;
            this.memBank_CB.FormattingEnabled = true;
            this.memBank_CB.Items.AddRange(new object[] {
            "Kill Password",
            "Access Password",
            "EPC Memory",
            "TID Memory",
            "User Memory"});
            this.memBank_CB.Location = new System.Drawing.Point(90, 103);
            this.memBank_CB.Name = "memBank_CB";
            this.memBank_CB.Size = new System.Drawing.Size(139, 21);
            this.memBank_CB.TabIndex = 3;
            // 
            // memBankLabel1
            // 
            this.memBankLabel1.AutoSize = true;
            this.memBankLabel1.Location = new System.Drawing.Point(11, 106);
            this.memBankLabel1.Name = "memBankLabel1";
            this.memBankLabel1.Size = new System.Drawing.Size(72, 13);
            this.memBankLabel1.TabIndex = 55;
            this.memBankLabel1.Text = "Memory Bank";
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 268);
            this.Controls.Add(this.Password_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tagID_TB);
            this.Controls.Add(this.tagMaskLabel);
            this.Controls.Add(this.memBank_CB);
            this.Controls.Add(this.memBankLabel1);
            this.Controls.Add(this.lockPrivilege_CB);
            this.Controls.Add(this.lockPrivilegeLabel);
            this.Controls.Add(this.accessFilterButton);
            this.Controls.Add(this.lockButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lock Tags";
            this.Load += new System.EventHandler(this.Lock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accessFilterButton;
        private System.Windows.Forms.ComboBox lockPrivilege_CB;
        private System.Windows.Forms.Label lockPrivilegeLabel;
        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tagID_TB;
        private System.Windows.Forms.Label tagMaskLabel;
        internal System.Windows.Forms.ComboBox memBank_CB;
        private System.Windows.Forms.Label memBankLabel1;
        internal System.Windows.Forms.Button lockButton;
    }
}