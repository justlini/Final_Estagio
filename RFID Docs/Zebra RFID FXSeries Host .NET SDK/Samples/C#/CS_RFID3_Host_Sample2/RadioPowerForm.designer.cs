namespace CS_RFID3_Host_Sample2
{
    partial class RadioPowerForm
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
            this.radioState_CB = new System.Windows.Forms.ComboBox();
            this.radioPowerApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current State";
            // 
            // radioState_CB
            // 
            this.radioState_CB.FormattingEnabled = true;
            this.radioState_CB.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.radioState_CB.Location = new System.Drawing.Point(112, 22);
            this.radioState_CB.Name = "radioState_CB";
            this.radioState_CB.Size = new System.Drawing.Size(89, 21);
            this.radioState_CB.TabIndex = 1;
            this.radioState_CB.Text = "On";
            // 
            // radioPowerApplyButton
            // 
            this.radioPowerApplyButton.Location = new System.Drawing.Point(126, 63);
            this.radioPowerApplyButton.Name = "radioPowerApplyButton";
            this.radioPowerApplyButton.Size = new System.Drawing.Size(75, 23);
            this.radioPowerApplyButton.TabIndex = 2;
            this.radioPowerApplyButton.Text = "Apply";
            this.radioPowerApplyButton.UseVisualStyleBackColor = true;
            this.radioPowerApplyButton.Click += new System.EventHandler(this.radioPowerApplyButton_Click);
            // 
            // RadioPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 98);
            this.Controls.Add(this.radioPowerApplyButton);
            this.Controls.Add(this.radioState_CB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RadioPower";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RadioPower";
            this.Load += new System.EventHandler(this.RadioPower_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox radioState_CB;
        private System.Windows.Forms.Button radioPowerApplyButton;


    }
}