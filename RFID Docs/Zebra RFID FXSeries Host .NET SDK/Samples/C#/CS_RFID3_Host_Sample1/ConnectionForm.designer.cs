namespace CS_RFID3_Host_Sample1 
{
    partial class ConnectionForm
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
            this.readerIPLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.connectionButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.hostname_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // readerIPLabel
            // 
            this.readerIPLabel.AutoSize = true;
            this.readerIPLabel.Location = new System.Drawing.Point(12, 23);
            this.readerIPLabel.Name = "readerIPLabel";
            this.readerIPLabel.Size = new System.Drawing.Size(113, 13);
            this.readerIPLabel.TabIndex = 8;
            this.readerIPLabel.Text = "Host Name/Reader IP";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 59);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 9;
            this.portLabel.Text = "Port";
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(187, 90);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(92, 23);
            this.connectionButton.TabIndex = 5;
            this.connectionButton.Text = "Connect";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(12, 95);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(0, 13);
            this.connectionLabel.TabIndex = 14;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(128, 56);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(71, 20);
            this.port_TB.TabIndex = 4;
            this.port_TB.Text = "5084";
            // 
            // hostname_TB
            // 
            this.hostname_TB.Location = new System.Drawing.Point(128, 22);
            this.hostname_TB.Name = "hostname_TB";
            this.hostname_TB.Size = new System.Drawing.Size(152, 20);
            this.hostname_TB.TabIndex = 1;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 125);
            this.Controls.Add(this.hostname_TB);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.readerIPLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Settings";
            this.Load += new System.EventHandler(this.ConnectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label readerIPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label connectionLabel;
        internal System.Windows.Forms.Button connectionButton;
        internal System.Windows.Forms.TextBox port_TB;
        internal System.Windows.Forms.TextBox hostname_TB;
    }
}