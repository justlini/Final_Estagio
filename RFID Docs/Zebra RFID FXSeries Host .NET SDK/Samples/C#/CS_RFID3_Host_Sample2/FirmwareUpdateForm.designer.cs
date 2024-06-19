namespace CS_RFID3_Host_Sample2
{
    partial class FirmwareUpdateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.location_TB = new System.Windows.Forms.TextBox();
            this.firmwareApplyButton = new System.Windows.Forms.Button();
            this.password_TB = new System.Windows.Forms.TextBox();
            this.username_TB = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.ftp_GB = new System.Windows.Forms.GroupBox();
            this.update_PB = new System.Windows.Forms.ProgressBar();
            this.update_CB = new System.Windows.Forms.ComboBox();
            this.updateDesc_TB = new System.Windows.Forms.TextBox();
            this.updateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ftp_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // location_TB
            // 
            this.location_TB.Location = new System.Drawing.Point(12, 134);
            this.location_TB.Name = "location_TB";
            this.location_TB.Size = new System.Drawing.Size(257, 20);
            this.location_TB.TabIndex = 7;
            // 
            // firmwareApplyButton
            // 
            this.firmwareApplyButton.Location = new System.Drawing.Point(194, 159);
            this.firmwareApplyButton.Name = "firmwareApplyButton";
            this.firmwareApplyButton.Size = new System.Drawing.Size(75, 23);
            this.firmwareApplyButton.TabIndex = 8;
            this.firmwareApplyButton.Text = "Start";
            this.firmwareApplyButton.UseVisualStyleBackColor = true;
            this.firmwareApplyButton.Click += new System.EventHandler(this.firmwareApplyButton_Click);
            // 
            // password_TB
            // 
            this.password_TB.Location = new System.Drawing.Point(88, 50);
            this.password_TB.Name = "password_TB";
            this.password_TB.Size = new System.Drawing.Size(128, 20);
            this.password_TB.TabIndex = 2;
            // 
            // username_TB
            // 
            this.username_TB.Location = new System.Drawing.Point(88, 20);
            this.username_TB.Name = "username_TB";
            this.username_TB.Size = new System.Drawing.Size(128, 20);
            this.username_TB.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(8, 53);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 26;
            this.passwordLabel.Text = "Password";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(8, 23);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 13);
            this.userNameLabel.TabIndex = 25;
            this.userNameLabel.Text = "User Name";
            // 
            // ftp_GB
            // 
            this.ftp_GB.Controls.Add(this.username_TB);
            this.ftp_GB.Controls.Add(this.userNameLabel);
            this.ftp_GB.Controls.Add(this.password_TB);
            this.ftp_GB.Controls.Add(this.passwordLabel);
            this.ftp_GB.Location = new System.Drawing.Point(12, 7);
            this.ftp_GB.Name = "ftp_GB";
            this.ftp_GB.Size = new System.Drawing.Size(222, 79);
            this.ftp_GB.TabIndex = 31;
            this.ftp_GB.TabStop = false;
            this.ftp_GB.Text = "FTP Server";
            // 
            // update_PB
            // 
            this.update_PB.Location = new System.Drawing.Point(12, 188);
            this.update_PB.Name = "update_PB";
            this.update_PB.Size = new System.Drawing.Size(257, 18);
            this.update_PB.Step = 1;
            this.update_PB.TabIndex = 33;
            // 
            // update_CB
            // 
            this.update_CB.FormattingEnabled = true;
            this.update_CB.Location = new System.Drawing.Point(12, 94);
            this.update_CB.Name = "update_CB";
            this.update_CB.Size = new System.Drawing.Size(222, 21);
            this.update_CB.TabIndex = 34;
            // 
            // updateDesc_TB
            // 
            this.updateDesc_TB.Location = new System.Drawing.Point(12, 212);
            this.updateDesc_TB.Name = "updateDesc_TB";
            this.updateDesc_TB.ReadOnly = true;
            this.updateDesc_TB.Size = new System.Drawing.Size(257, 20);
            this.updateDesc_TB.TabIndex = 35;
            // 
            // updateBackgroundWorker
            // 
            this.updateBackgroundWorker.WorkerReportsProgress = true;
            this.updateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateBackgroundWorker_DoWork);
            this.updateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateBackgroundWorker_RunWorkerCompleted);
            this.updateBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateBackgroundWorker_ProgressChanged);
            // 
            // FirmwareUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 259);
            this.Controls.Add(this.updateDesc_TB);
            this.Controls.Add(this.update_CB);
            this.Controls.Add(this.update_PB);
            this.Controls.Add(this.ftp_GB);
            this.Controls.Add(this.firmwareApplyButton);
            this.Controls.Add(this.location_TB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirmwareUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmware Update";
            this.Load += new System.EventHandler(this.FirmwareUpdateForm_Load);
            this.ftp_GB.ResumeLayout(false);
            this.ftp_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.GroupBox ftp_GB;
        internal System.Windows.Forms.ProgressBar update_PB;
        internal System.Windows.Forms.TextBox location_TB;
        internal System.Windows.Forms.Button firmwareApplyButton;
        internal System.Windows.Forms.TextBox password_TB;
        internal System.Windows.Forms.TextBox username_TB;
        internal System.Windows.Forms.ComboBox update_CB;
        internal System.Windows.Forms.TextBox updateDesc_TB;
        internal System.ComponentModel.BackgroundWorker updateBackgroundWorker;

    }
}