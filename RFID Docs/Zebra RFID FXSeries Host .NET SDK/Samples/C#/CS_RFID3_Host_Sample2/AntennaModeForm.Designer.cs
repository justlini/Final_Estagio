namespace CS_RFID3_Host_Sample2
{
    partial class AntennaModeForm
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
            this.antModeApplyButton = new System.Windows.Forms.Button();
            this.antMode_CB = new System.Windows.Forms.ComboBox();
            this.antModeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // antModeApplyButton
            // 
            this.antModeApplyButton.Location = new System.Drawing.Point(124, 61);
            this.antModeApplyButton.Name = "antModeApplyButton";
            this.antModeApplyButton.Size = new System.Drawing.Size(75, 23);
            this.antModeApplyButton.TabIndex = 5;
            this.antModeApplyButton.Text = "Apply";
            this.antModeApplyButton.UseVisualStyleBackColor = true;
            this.antModeApplyButton.Click += new System.EventHandler(this.antModeApplyButton_Click);
            // 
            // antMode_CB
            // 
            this.antMode_CB.FormattingEnabled = true;
            this.antMode_CB.Items.AddRange(new object[] {
            "BiStatic",
            "MonoStatic"});
            this.antMode_CB.Location = new System.Drawing.Point(110, 21);
            this.antMode_CB.Name = "antMode_CB";
            this.antMode_CB.Size = new System.Drawing.Size(89, 21);
            this.antMode_CB.TabIndex = 4;
            this.antMode_CB.Text = "MonoStatic";
            // 
            // antModeLabel
            // 
            this.antModeLabel.AutoSize = true;
            this.antModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antModeLabel.Location = new System.Drawing.Point(34, 22);
            this.antModeLabel.Name = "antModeLabel";
            this.antModeLabel.Size = new System.Drawing.Size(39, 15);
            this.antModeLabel.TabIndex = 3;
            this.antModeLabel.Text = "Mode";
            // 
            // AntennaModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 96);
            this.Controls.Add(this.antModeApplyButton);
            this.Controls.Add(this.antMode_CB);
            this.Controls.Add(this.antModeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AntennaModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Antenna Mode";
            this.Load += new System.EventHandler(this.AntennaModeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button antModeApplyButton;
        private System.Windows.Forms.ComboBox antMode_CB;
        private System.Windows.Forms.Label antModeLabel;
    }
}