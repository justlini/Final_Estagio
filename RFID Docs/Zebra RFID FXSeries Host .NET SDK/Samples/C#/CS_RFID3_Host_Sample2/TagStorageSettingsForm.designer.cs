namespace CS_RFID3_Host_Sample2
{
    partial class TagStorageSettingsForm
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
            this.storageApplyButton = new System.Windows.Forms.Button();
            this.idLength_TB = new System.Windows.Forms.TextBox();
            this.maxCount_TB = new System.Windows.Forms.TextBox();
            this.hostNameLabel = new System.Windows.Forms.Label();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.memoryBankSize_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPhaseInfo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // storageApplyButton
            // 
            this.storageApplyButton.Location = new System.Drawing.Point(101, 178);
            this.storageApplyButton.Name = "storageApplyButton";
            this.storageApplyButton.Size = new System.Drawing.Size(84, 26);
            this.storageApplyButton.TabIndex = 4;
            this.storageApplyButton.Text = "Apply";
            this.storageApplyButton.UseVisualStyleBackColor = true;
            this.storageApplyButton.Click += new System.EventHandler(this.storageApplyButton_Click);
            // 
            // idLength_TB
            // 
            this.idLength_TB.Location = new System.Drawing.Point(101, 63);
            this.idLength_TB.Name = "idLength_TB";
            this.idLength_TB.Size = new System.Drawing.Size(105, 20);
            this.idLength_TB.TabIndex = 2;
            // 
            // maxCount_TB
            // 
            this.maxCount_TB.Location = new System.Drawing.Point(101, 19);
            this.maxCount_TB.Name = "maxCount_TB";
            this.maxCount_TB.Size = new System.Drawing.Size(104, 20);
            this.maxCount_TB.TabIndex = 1;
            // 
            // hostNameLabel
            // 
            this.hostNameLabel.Location = new System.Drawing.Point(20, 55);
            this.hostNameLabel.Name = "hostNameLabel";
            this.hostNameLabel.Size = new System.Drawing.Size(70, 28);
            this.hostNameLabel.TabIndex = 13;
            this.hostNameLabel.Text = "Max Tag ID Length";
            // 
            // filenameLabel
            // 
            this.filenameLabel.Location = new System.Drawing.Point(20, 11);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(75, 28);
            this.filenameLabel.TabIndex = 12;
            this.filenameLabel.Text = "Maximum Tag Count";
            // 
            // memoryBankSize_TB
            // 
            this.memoryBankSize_TB.Location = new System.Drawing.Point(101, 108);
            this.memoryBankSize_TB.Name = "memoryBankSize_TB";
            this.memoryBankSize_TB.Size = new System.Drawing.Size(104, 20);
            this.memoryBankSize_TB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Max Size of Memory Bank";
            // 
            // checkBoxPhaseInfo
            // 
            this.checkBoxPhaseInfo.AutoSize = true;
            this.checkBoxPhaseInfo.Location = new System.Drawing.Point(101, 144);
            this.checkBoxPhaseInfo.Name = "checkBoxPhaseInfo";
            this.checkBoxPhaseInfo.Size = new System.Drawing.Size(111, 17);
            this.checkBoxPhaseInfo.TabIndex = 17;
            this.checkBoxPhaseInfo.Text = "Phase Information";
            this.checkBoxPhaseInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tag Fields";
            // 
            // TagStorageSettingsForm
            // 
            this.AcceptButton = this.storageApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 216);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxPhaseInfo);
            this.Controls.Add(this.memoryBankSize_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idLength_TB);
            this.Controls.Add(this.maxCount_TB);
            this.Controls.Add(this.hostNameLabel);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.storageApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagStorageSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Storage Settings";
            this.Load += new System.EventHandler(this.TagStorageSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button storageApplyButton;
        private System.Windows.Forms.TextBox idLength_TB;
        private System.Windows.Forms.TextBox maxCount_TB;
        private System.Windows.Forms.Label hostNameLabel;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.TextBox memoryBankSize_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPhaseInfo;
        private System.Windows.Forms.Label label2;
    }
}