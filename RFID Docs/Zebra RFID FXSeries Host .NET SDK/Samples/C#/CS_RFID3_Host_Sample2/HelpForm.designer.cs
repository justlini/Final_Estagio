namespace CS_RFID3_Host_Sample2
{
    partial class HelpForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyRightLabel = new System.Windows.Forms.Label();
            this.dllVersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(227, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(28, 17);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(136, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "CS_RFID3_Host_Sample2 ";
            // 
            // copyRightLabel
            // 
            this.copyRightLabel.AutoSize = true;
            this.copyRightLabel.Location = new System.Drawing.Point(28, 61);
            this.copyRightLabel.Name = "copyRightLabel";
            this.copyRightLabel.Size = new System.Drawing.Size(94, 13);
            this.copyRightLabel.TabIndex = 2;
            this.copyRightLabel.Text = "Copyright (C) 2010";
            // 
            // dllVersionLabel
            // 
            this.dllVersionLabel.AutoSize = true;
            this.dllVersionLabel.Location = new System.Drawing.Point(28, 39);
            this.dllVersionLabel.Name = "dllVersionLabel";
            this.dllVersionLabel.Size = new System.Drawing.Size(0, 13);
            this.dllVersionLabel.TabIndex = 3;
            // 
            // HelpForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 107);
            this.Controls.Add(this.dllVersionLabel);
            this.Controls.Add(this.copyRightLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About CS_RFID3_Host_Sample2";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label copyRightLabel;
        internal System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label dllVersionLabel;
    }
}