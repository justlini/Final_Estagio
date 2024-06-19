namespace CS_RFID3_Host_Sample2
{
    partial class ReadPointForm
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
            this.antennaID_CB = new System.Windows.Forms.ComboBox();
            this.antennaIDLlabel = new System.Windows.Forms.Label();
            this.readPointButton = new System.Windows.Forms.Button();
            this.readPoint_CB = new System.Windows.Forms.ComboBox();
            this.readPointStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // antennaID_CB
            // 
            this.antennaID_CB.FormattingEnabled = true;
            this.antennaID_CB.Location = new System.Drawing.Point(109, 21);
            this.antennaID_CB.Name = "antennaID_CB";
            this.antennaID_CB.Size = new System.Drawing.Size(121, 21);
            this.antennaID_CB.TabIndex = 3;
            this.antennaID_CB.SelectedIndexChanged += new System.EventHandler(this.antennaID_CB_SelectedIndexChanged);
            // 
            // antennaIDLlabel
            // 
            this.antennaIDLlabel.AutoSize = true;
            this.antennaIDLlabel.Location = new System.Drawing.Point(17, 24);
            this.antennaIDLlabel.Name = "antennaIDLlabel";
            this.antennaIDLlabel.Size = new System.Drawing.Size(61, 13);
            this.antennaIDLlabel.TabIndex = 2;
            this.antennaIDLlabel.Text = "Antenna ID";
            // 
            // readPointButton
            // 
            this.readPointButton.Location = new System.Drawing.Point(163, 109);
            this.readPointButton.Name = "readPointButton";
            this.readPointButton.Size = new System.Drawing.Size(75, 23);
            this.readPointButton.TabIndex = 6;
            this.readPointButton.Text = "Apply";
            this.readPointButton.UseVisualStyleBackColor = true;
            this.readPointButton.Click += new System.EventHandler(this.readPointButton_Click);
            // 
            // readPoint_CB
            // 
            this.readPoint_CB.FormattingEnabled = true;
            this.readPoint_CB.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.readPoint_CB.Location = new System.Drawing.Point(109, 58);
            this.readPoint_CB.Name = "readPoint_CB";
            this.readPoint_CB.Size = new System.Drawing.Size(121, 21);
            this.readPoint_CB.TabIndex = 8;
            this.readPoint_CB.Text = "Disable";
            // 
            // readPointStatusLabel
            // 
            this.readPointStatusLabel.AutoSize = true;
            this.readPointStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readPointStatusLabel.Location = new System.Drawing.Point(39, 59);
            this.readPointStatusLabel.Name = "readPointStatusLabel";
            this.readPointStatusLabel.Size = new System.Drawing.Size(41, 15);
            this.readPointStatusLabel.TabIndex = 7;
            this.readPointStatusLabel.Text = "Status";
            // 
            // ReadPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 144);
            this.Controls.Add(this.readPoint_CB);
            this.Controls.Add(this.readPointStatusLabel);
            this.Controls.Add(this.readPointButton);
            this.Controls.Add(this.antennaID_CB);
            this.Controls.Add(this.antennaIDLlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Read Point";
            this.Load += new System.EventHandler(this.ReadPointForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox antennaID_CB;
        private System.Windows.Forms.Label antennaIDLlabel;
        private System.Windows.Forms.Button readPointButton;
        private System.Windows.Forms.ComboBox readPoint_CB;
        private System.Windows.Forms.Label readPointStatusLabel;
    }
}