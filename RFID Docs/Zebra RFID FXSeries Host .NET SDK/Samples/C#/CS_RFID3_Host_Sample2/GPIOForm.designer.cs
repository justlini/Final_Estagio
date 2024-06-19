namespace CS_RFID3_Host_Sample2
{
    partial class GPIOForm
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
            this.gpoGroupBox = new System.Windows.Forms.GroupBox();
            this.gpoButton = new System.Windows.Forms.Button();
            this.gpiGroupBox = new System.Windows.Forms.GroupBox();
            this.gpiButton = new System.Windows.Forms.Button();
            this.gpoGroupBox.SuspendLayout();
            this.gpiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoGroupBox
            // 
            this.gpoGroupBox.Controls.Add(this.gpoButton);
            this.gpoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.gpoGroupBox.Name = "gpoGroupBox";
            this.gpoGroupBox.Size = new System.Drawing.Size(267, 107);
            this.gpoGroupBox.TabIndex = 0;
            this.gpoGroupBox.TabStop = false;
            this.gpoGroupBox.Text = "GPO States";
            // 
            // gpoButton
            // 
            this.gpoButton.Location = new System.Drawing.Point(197, 79);
            this.gpoButton.Name = "gpoButton";
            this.gpoButton.Size = new System.Drawing.Size(64, 22);
            this.gpoButton.TabIndex = 28;
            this.gpoButton.Text = "Apply";
            this.gpoButton.UseVisualStyleBackColor = true;
            this.gpoButton.Click += new System.EventHandler(this.gpoButton_Click);
            // 
            // gpiGroupBox
            // 
            this.gpiGroupBox.Controls.Add(this.gpiButton);
            this.gpiGroupBox.Location = new System.Drawing.Point(13, 125);
            this.gpiGroupBox.Name = "gpiGroupBox";
            this.gpiGroupBox.Size = new System.Drawing.Size(266, 100);
            this.gpiGroupBox.TabIndex = 1;
            this.gpiGroupBox.TabStop = false;
            this.gpiGroupBox.Text = "GPI Enable";
            // 
            // gpiButton
            // 
            this.gpiButton.Location = new System.Drawing.Point(196, 72);
            this.gpiButton.Name = "gpiButton";
            this.gpiButton.Size = new System.Drawing.Size(64, 22);
            this.gpiButton.TabIndex = 29;
            this.gpiButton.Text = "Apply";
            this.gpiButton.UseVisualStyleBackColor = true;
            this.gpiButton.Click += new System.EventHandler(this.gpiButton_Click);
            // 
            // GPIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 245);
            this.Controls.Add(this.gpiGroupBox);
            this.Controls.Add(this.gpoGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPIO";
            this.Load += new System.EventHandler(this.GPIO_Load);
            this.gpoGroupBox.ResumeLayout(false);
            this.gpoGroupBox.PerformLayout();
            this.gpiGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoGroupBox;
        private System.Windows.Forms.Button gpoButton;
        private System.Windows.Forms.GroupBox gpiGroupBox;
        private System.Windows.Forms.Button gpiButton;
    }
}