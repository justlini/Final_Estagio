namespace CS_RFID3_Host_Sample2
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
            this.secureModeCheckBox = new System.Windows.Forms.CheckBox();
            this.validatePeerCertCheckBox = new System.Windows.Forms.CheckBox();
            this.certFilePath_TB = new System.Windows.Forms.TextBox();
            this.certFilePathBrowseButton = new System.Windows.Forms.Button();
            this.CertFileLabel = new System.Windows.Forms.Label();
            this.PrivateKeyFileLabel = new System.Windows.Forms.Label();
            this.privateKeyFileBrowseButton = new System.Windows.Forms.Button();
            this.privateKeyFilePath_TB = new System.Windows.Forms.TextBox();
            this.KeyPassPhraseLabel = new System.Windows.Forms.Label();
            this.keyPassPhrase_TB = new System.Windows.Forms.TextBox();
            this.RootCertFilePathLabel = new System.Windows.Forms.Label();
            this.rootCertFilePathBrowseButton = new System.Windows.Forms.Button();
            this.rootCertFilePath_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // readerIPLabel
            // 
            this.readerIPLabel.AutoSize = true;
            this.readerIPLabel.Location = new System.Drawing.Point(9, 23);
            this.readerIPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.readerIPLabel.Name = "readerIPLabel";
            this.readerIPLabel.Size = new System.Drawing.Size(145, 17);
            this.readerIPLabel.TabIndex = 8;
            this.readerIPLabel.Text = "Host Name/Reader IP";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(404, 23);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(34, 17);
            this.portLabel.TabIndex = 9;
            this.portLabel.Text = "Port";
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(251, 262);
            this.connectionButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(135, 47);
            this.connectionButton.TabIndex = 5;
            this.connectionButton.Text = "Connect";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(16, 117);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(0, 17);
            this.connectionLabel.TabIndex = 14;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(449, 23);
            this.port_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(93, 22);
            this.port_TB.TabIndex = 4;
            this.port_TB.Text = "5084";
            // 
            // hostname_TB
            // 
            this.hostname_TB.Location = new System.Drawing.Point(171, 23);
            this.hostname_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hostname_TB.Name = "hostname_TB";
            this.hostname_TB.Size = new System.Drawing.Size(201, 22);
            this.hostname_TB.TabIndex = 1;
            this.hostname_TB.Text = "169.254.10.1";
            // 
            // secureModeCheckBox
            // 
            this.secureModeCheckBox.AutoSize = true;
            this.secureModeCheckBox.Location = new System.Drawing.Point(40, 76);
            this.secureModeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.secureModeCheckBox.Name = "secureModeCheckBox";
            this.secureModeCheckBox.Size = new System.Drawing.Size(114, 21);
            this.secureModeCheckBox.TabIndex = 15;
            this.secureModeCheckBox.Text = "Secure Mode";
            this.secureModeCheckBox.UseVisualStyleBackColor = true;
            this.secureModeCheckBox.CheckedChanged += new System.EventHandler(this.secureModeCheckBox_CheckedChanged);
            // 
            // validatePeerCertCheckBox
            // 
            this.validatePeerCertCheckBox.AutoSize = true;
            this.validatePeerCertCheckBox.Enabled = false;
            this.validatePeerCertCheckBox.Location = new System.Drawing.Point(253, 76);
            this.validatePeerCertCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.validatePeerCertCheckBox.Name = "validatePeerCertCheckBox";
            this.validatePeerCertCheckBox.Size = new System.Drawing.Size(182, 21);
            this.validatePeerCertCheckBox.TabIndex = 16;
            this.validatePeerCertCheckBox.Text = "Validate Peer Certificate";
            this.validatePeerCertCheckBox.UseVisualStyleBackColor = true;
            // 
            // certFilePath_TB
            // 
            this.certFilePath_TB.Enabled = false;
            this.certFilePath_TB.Location = new System.Drawing.Point(131, 121);
            this.certFilePath_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.certFilePath_TB.Name = "certFilePath_TB";
            this.certFilePath_TB.Size = new System.Drawing.Size(443, 22);
            this.certFilePath_TB.TabIndex = 17;
            // 
            // certFilePathBrowseButton
            // 
            this.certFilePathBrowseButton.Enabled = false;
            this.certFilePathBrowseButton.Location = new System.Drawing.Point(583, 117);
            this.certFilePathBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.certFilePathBrowseButton.Name = "certFilePathBrowseButton";
            this.certFilePathBrowseButton.Size = new System.Drawing.Size(80, 31);
            this.certFilePathBrowseButton.TabIndex = 18;
            this.certFilePathBrowseButton.Text = "Browse";
            this.certFilePathBrowseButton.UseVisualStyleBackColor = true;
            this.certFilePathBrowseButton.Click += new System.EventHandler(this.certFilePathBrowseButton_Click);
            // 
            // CertFileLabel
            // 
            this.CertFileLabel.AutoSize = true;
            this.CertFileLabel.Location = new System.Drawing.Point(25, 124);
            this.CertFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CertFileLabel.Name = "CertFileLabel";
            this.CertFileLabel.Size = new System.Drawing.Size(101, 17);
            this.CertFileLabel.TabIndex = 19;
            this.CertFileLabel.Text = "Certificate File:";
            // 
            // PrivateKeyFileLabel
            // 
            this.PrivateKeyFileLabel.AutoSize = true;
            this.PrivateKeyFileLabel.Location = new System.Drawing.Point(16, 158);
            this.PrivateKeyFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrivateKeyFileLabel.Name = "PrivateKeyFileLabel";
            this.PrivateKeyFileLabel.Size = new System.Drawing.Size(110, 17);
            this.PrivateKeyFileLabel.TabIndex = 22;
            this.PrivateKeyFileLabel.Text = "Private Key File:";
            // 
            // privateKeyFileBrowseButton
            // 
            this.privateKeyFileBrowseButton.Enabled = false;
            this.privateKeyFileBrowseButton.Location = new System.Drawing.Point(583, 153);
            this.privateKeyFileBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.privateKeyFileBrowseButton.Name = "privateKeyFileBrowseButton";
            this.privateKeyFileBrowseButton.Size = new System.Drawing.Size(80, 31);
            this.privateKeyFileBrowseButton.TabIndex = 21;
            this.privateKeyFileBrowseButton.Text = "Browse";
            this.privateKeyFileBrowseButton.UseVisualStyleBackColor = true;
            this.privateKeyFileBrowseButton.Click += new System.EventHandler(this.privateKeyFileBrowseButton_Click);
            // 
            // privateKeyFilePath_TB
            // 
            this.privateKeyFilePath_TB.Enabled = false;
            this.privateKeyFilePath_TB.Location = new System.Drawing.Point(131, 156);
            this.privateKeyFilePath_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.privateKeyFilePath_TB.Name = "privateKeyFilePath_TB";
            this.privateKeyFilePath_TB.Size = new System.Drawing.Size(443, 22);
            this.privateKeyFilePath_TB.TabIndex = 20;
            // 
            // KeyPassPhraseLabel
            // 
            this.KeyPassPhraseLabel.AutoSize = true;
            this.KeyPassPhraseLabel.Location = new System.Drawing.Point(7, 190);
            this.KeyPassPhraseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KeyPassPhraseLabel.Name = "KeyPassPhraseLabel";
            this.KeyPassPhraseLabel.Size = new System.Drawing.Size(120, 17);
            this.KeyPassPhraseLabel.TabIndex = 24;
            this.KeyPassPhraseLabel.Text = "Key Pass Phrase:";
            // 
            // keyPassPhrase_TB
            // 
            this.keyPassPhrase_TB.Enabled = false;
            this.keyPassPhrase_TB.Location = new System.Drawing.Point(131, 188);
            this.keyPassPhrase_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.keyPassPhrase_TB.Name = "keyPassPhrase_TB";
            this.keyPassPhrase_TB.PasswordChar = '*';
            this.keyPassPhrase_TB.Size = new System.Drawing.Size(164, 22);
            this.keyPassPhrase_TB.TabIndex = 23;
            // 
            // RootCertFilePathLabel
            // 
            this.RootCertFilePathLabel.AutoSize = true;
            this.RootCertFilePathLabel.Location = new System.Drawing.Point(28, 225);
            this.RootCertFilePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RootCertFilePathLabel.Name = "RootCertFilePathLabel";
            this.RootCertFilePathLabel.Size = new System.Drawing.Size(98, 17);
            this.RootCertFilePathLabel.TabIndex = 27;
            this.RootCertFilePathLabel.Text = "Root Cert File:";
            // 
            // rootCertFilePathBrowseButton
            // 
            this.rootCertFilePathBrowseButton.Enabled = false;
            this.rootCertFilePathBrowseButton.Location = new System.Drawing.Point(584, 220);
            this.rootCertFilePathBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rootCertFilePathBrowseButton.Name = "rootCertFilePathBrowseButton";
            this.rootCertFilePathBrowseButton.Size = new System.Drawing.Size(80, 31);
            this.rootCertFilePathBrowseButton.TabIndex = 26;
            this.rootCertFilePathBrowseButton.Text = "Browse";
            this.rootCertFilePathBrowseButton.UseVisualStyleBackColor = true;
            this.rootCertFilePathBrowseButton.Click += new System.EventHandler(this.rootCertFilePathBrowseButton_Click);
            // 
            // rootCertFilePath_TB
            // 
            this.rootCertFilePath_TB.Enabled = false;
            this.rootCertFilePath_TB.Location = new System.Drawing.Point(132, 224);
            this.rootCertFilePath_TB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rootCertFilePath_TB.Name = "rootCertFilePath_TB";
            this.rootCertFilePath_TB.Size = new System.Drawing.Size(443, 22);
            this.rootCertFilePath_TB.TabIndex = 25;
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.connectionButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 321);
            this.Controls.Add(this.RootCertFilePathLabel);
            this.Controls.Add(this.rootCertFilePathBrowseButton);
            this.Controls.Add(this.rootCertFilePath_TB);
            this.Controls.Add(this.KeyPassPhraseLabel);
            this.Controls.Add(this.keyPassPhrase_TB);
            this.Controls.Add(this.PrivateKeyFileLabel);
            this.Controls.Add(this.privateKeyFileBrowseButton);
            this.Controls.Add(this.privateKeyFilePath_TB);
            this.Controls.Add(this.CertFileLabel);
            this.Controls.Add(this.certFilePathBrowseButton);
            this.Controls.Add(this.certFilePath_TB);
            this.Controls.Add(this.validatePeerCertCheckBox);
            this.Controls.Add(this.secureModeCheckBox);
            this.Controls.Add(this.hostname_TB);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.readerIPLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        internal System.Windows.Forms.CheckBox secureModeCheckBox;
        internal System.Windows.Forms.CheckBox validatePeerCertCheckBox;
        internal System.Windows.Forms.TextBox certFilePath_TB;
        internal System.Windows.Forms.Button certFilePathBrowseButton;
        internal System.Windows.Forms.Label CertFileLabel;
        internal System.Windows.Forms.Label PrivateKeyFileLabel;
        internal System.Windows.Forms.Button privateKeyFileBrowseButton;
        internal System.Windows.Forms.TextBox privateKeyFilePath_TB;
        internal System.Windows.Forms.Label KeyPassPhraseLabel;
        internal System.Windows.Forms.TextBox keyPassPhrase_TB;
        internal System.Windows.Forms.Label RootCertFilePathLabel;
        internal System.Windows.Forms.Button rootCertFilePathBrowseButton;
        internal System.Windows.Forms.TextBox rootCertFilePath_TB;
    }
}