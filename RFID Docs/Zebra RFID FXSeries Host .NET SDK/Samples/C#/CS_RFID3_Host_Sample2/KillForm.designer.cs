namespace CS_RFID3_Host_Sample2
{
    partial class KillForm
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
            this.tagIDLabel = new System.Windows.Forms.Label();
            this.killPwdLabel = new System.Windows.Forms.Label();
            this.killPwd_TB = new System.Windows.Forms.TextBox();
            this.accessFilterButton = new System.Windows.Forms.Button();
            this.killButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tagID_TB
            // 
            this.tagID_TB.Location = new System.Drawing.Point(97, 22);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(174, 20);
            this.tagID_TB.TabIndex = 1;
            this.tagID_TB.TextChanged += new System.EventHandler(this.tagID_TB_TextChanged);
            // 
            // tagIDLabel
            // 
            this.tagIDLabel.AutoSize = true;
            this.tagIDLabel.Location = new System.Drawing.Point(19, 25);
            this.tagIDLabel.Name = "tagIDLabel";
            this.tagIDLabel.Size = new System.Drawing.Size(68, 13);
            this.tagIDLabel.TabIndex = 45;
            this.tagIDLabel.Text = "Tag ID (Hex)";
            // 
            // killPwdLabel
            // 
            this.killPwdLabel.Location = new System.Drawing.Point(19, 62);
            this.killPwdLabel.Name = "killPwdLabel";
            this.killPwdLabel.Size = new System.Drawing.Size(69, 28);
            this.killPwdLabel.TabIndex = 43;
            this.killPwdLabel.Text = "Kill Password (Hex)";
            // 
            // killPwd_TB
            // 
            this.killPwd_TB.Location = new System.Drawing.Point(97, 63);
            this.killPwd_TB.Name = "killPwd_TB";
            this.killPwd_TB.Size = new System.Drawing.Size(174, 20);
            this.killPwd_TB.TabIndex = 2;
            // 
            // accessFilterButton
            // 
            this.accessFilterButton.Location = new System.Drawing.Point(117, 229);
            this.accessFilterButton.Name = "accessFilterButton";
            this.accessFilterButton.Size = new System.Drawing.Size(75, 27);
            this.accessFilterButton.TabIndex = 3;
            this.accessFilterButton.Text = "Access Filter";
            this.accessFilterButton.UseVisualStyleBackColor = true;
            this.accessFilterButton.Click += new System.EventHandler(this.accessFilterButton_Click);
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(207, 229);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(75, 27);
            this.killButton.TabIndex = 4;
            this.killButton.Text = "Kill";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // KillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 268);
            this.Controls.Add(this.accessFilterButton);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.killPwd_TB);
            this.Controls.Add(this.tagID_TB);
            this.Controls.Add(this.tagIDLabel);
            this.Controls.Add(this.killPwdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kill Tags";
            this.Load += new System.EventHandler(this.Kill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tagID_TB;
        private System.Windows.Forms.Label tagIDLabel;
        private System.Windows.Forms.Label killPwdLabel;
        private System.Windows.Forms.TextBox killPwd_TB;
        private System.Windows.Forms.Button accessFilterButton;
        internal System.Windows.Forms.Button killButton;
    }
}