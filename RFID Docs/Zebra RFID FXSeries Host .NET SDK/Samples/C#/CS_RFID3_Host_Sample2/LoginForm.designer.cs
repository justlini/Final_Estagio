namespace CS_RFID3_Host_Sample2
{
    partial class LoginForm
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
            this.readerType_CB = new System.Windows.Forms.ComboBox();
            this.password_TB = new System.Windows.Forms.TextBox();
            this.username_TB = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.readerTypeLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.hostname_TB = new System.Windows.Forms.TextBox();
            this.forceLogin_CB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // readerType_CB
            // 
            this.readerType_CB.FormattingEnabled = true;
            this.readerType_CB.Items.AddRange(new object[] {
            "XR",
            "FX",
            "MC"});
            this.readerType_CB.Location = new System.Drawing.Point(114, 17);
            this.readerType_CB.Name = "readerType_CB";
            this.readerType_CB.Size = new System.Drawing.Size(128, 21);
            this.readerType_CB.TabIndex = 1;
            this.readerType_CB.SelectedIndexChanged += new System.EventHandler(this.readerType_CB_SelectedIndexChanged);
            // 
            // password_TB
            // 
            this.password_TB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.password_TB.Location = new System.Drawing.Point(114, 108);
            this.password_TB.Name = "password_TB";
            this.password_TB.PasswordChar = '*';
            this.password_TB.Size = new System.Drawing.Size(128, 20);
            this.password_TB.TabIndex = 3;
            // 
            // username_TB
            // 
            this.username_TB.Location = new System.Drawing.Point(114, 71);
            this.username_TB.Name = "username_TB";
            this.username_TB.Size = new System.Drawing.Size(128, 20);
            this.username_TB.TabIndex = 2;
            this.username_TB.Text = "admin";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(0, 48);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(113, 13);
            this.IPLabel.TabIndex = 20;
            this.IPLabel.Text = "Host Name/Reader IP";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(0, 111);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 19;
            this.passwordLabel.Text = "Password";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(0, 74);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 13);
            this.userNameLabel.TabIndex = 18;
            this.userNameLabel.Text = "User Name";
            // 
            // readerTypeLabel
            // 
            this.readerTypeLabel.AutoSize = true;
            this.readerTypeLabel.Location = new System.Drawing.Point(0, 20);
            this.readerTypeLabel.Name = "readerTypeLabel";
            this.readerTypeLabel.Size = new System.Drawing.Size(69, 13);
            this.readerTypeLabel.TabIndex = 17;
            this.readerTypeLabel.Text = "Reader Type";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(160, 159);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginApplyButton_Click);
            // 
            // hostname_TB
            // 
            this.hostname_TB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hostname_TB.Location = new System.Drawing.Point(114, 45);
            this.hostname_TB.Name = "hostname_TB";
            this.hostname_TB.Size = new System.Drawing.Size(128, 20);
            this.hostname_TB.TabIndex = 21;
            // 
            // forceLogin_CB
            // 
            this.forceLogin_CB.AutoSize = true;
            this.forceLogin_CB.Location = new System.Drawing.Point(12, 163);
            this.forceLogin_CB.Name = "forceLogin_CB";
            this.forceLogin_CB.Size = new System.Drawing.Size(82, 17);
            this.forceLogin_CB.TabIndex = 22;
            this.forceLogin_CB.Text = "Force Login";
            this.forceLogin_CB.UseVisualStyleBackColor = true;
            this.forceLogin_CB.CheckedChanged += new System.EventHandler(this.forceLogin_CB_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 194);
            this.Controls.Add(this.forceLogin_CB);
            this.Controls.Add(this.hostname_TB);
            this.Controls.Add(this.readerType_CB);
            this.Controls.Add(this.password_TB);
            this.Controls.Add(this.username_TB);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.readerTypeLabel);
            this.Controls.Add(this.loginButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login/Logout";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox readerType_CB;
        private System.Windows.Forms.TextBox password_TB;
        private System.Windows.Forms.TextBox username_TB;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label readerTypeLabel;
        internal System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox hostname_TB;
        private System.Windows.Forms.CheckBox forceLogin_CB;
    }
}