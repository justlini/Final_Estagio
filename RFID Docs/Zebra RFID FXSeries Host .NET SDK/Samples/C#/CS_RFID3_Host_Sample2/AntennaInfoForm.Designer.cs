namespace CS_RFID3_Host_Sample2
{
    partial class AntennaInfoForm
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
            this.Antenna_GB = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.selectAll_CB = new System.Windows.Forms.CheckBox();
            this.Antenna_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Antenna_GB
            // 
            this.Antenna_GB.Controls.Add(this.selectAll_CB);
            this.Antenna_GB.Location = new System.Drawing.Point(12, 12);
            this.Antenna_GB.Name = "Antenna_GB";
            this.Antenna_GB.Size = new System.Drawing.Size(270, 104);
            this.Antenna_GB.TabIndex = 0;
            this.Antenna_GB.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(207, 122);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // selectAll_CB
            // 
            this.selectAll_CB.AutoSize = true;
            this.selectAll_CB.Location = new System.Drawing.Point(0, 0);
            this.selectAll_CB.Name = "selectAll_CB";
            this.selectAll_CB.Size = new System.Drawing.Size(70, 17);
            this.selectAll_CB.TabIndex = 0;
            this.selectAll_CB.Text = "Select All";
            this.selectAll_CB.UseVisualStyleBackColor = true;
            this.selectAll_CB.CheckedChanged += new System.EventHandler(this.selectAll_CB_CheckedChanged);
            // 
            // AntennaInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 157);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.Antenna_GB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AntennaInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AntennaInfo";
            this.Load += new System.EventHandler(this.AntennaInfo_Load);
            this.Antenna_GB.ResumeLayout(false);
            this.Antenna_GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Antenna_GB;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.CheckBox selectAll_CB;
    }
}