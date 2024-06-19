namespace CS_RFID3_Host_Sample2
{
    partial class RFModeForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Mode Identifier");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("DR");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Bdr");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("M");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Forward Link Modulation");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("PIE");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Min Tari");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Max Tari");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Step Tari");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Spectral Mask Indicator");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("EPC HAG TCConformance");
            this.antenna_CB = new System.Windows.Forms.ComboBox();
            this.antennaIDLlabel = new System.Windows.Forms.Label();
            this.tariValueLabel = new System.Windows.Forms.Label();
            this.tari_TB = new System.Windows.Forms.TextBox();
            this.rfModeGroupBox = new System.Windows.Forms.GroupBox();
            this.rfModelistView = new System.Windows.Forms.ListView();
            this.parameterHeader = new System.Windows.Forms.ColumnHeader();
            this.valueHeader1 = new System.Windows.Forms.ColumnHeader();
            this.rfModeTable_CB = new System.Windows.Forms.ComboBox();
            this.rfModeTablelabel = new System.Windows.Forms.Label();
            this.rfModeApplybutton = new System.Windows.Forms.Button();
            this.rfModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // antenna_CB
            // 
            this.antenna_CB.FormattingEnabled = true;
            this.antenna_CB.Location = new System.Drawing.Point(105, 10);
            this.antenna_CB.Name = "antenna_CB";
            this.antenna_CB.Size = new System.Drawing.Size(70, 21);
            this.antenna_CB.TabIndex = 1;
            this.antenna_CB.SelectedIndexChanged += new System.EventHandler(this.antenna_CB_SelectedIndexChanged);
            // 
            // antennaIDLlabel
            // 
            this.antennaIDLlabel.AutoSize = true;
            this.antennaIDLlabel.Location = new System.Drawing.Point(18, 13);
            this.antennaIDLlabel.Name = "antennaIDLlabel";
            this.antennaIDLlabel.Size = new System.Drawing.Size(61, 13);
            this.antennaIDLlabel.TabIndex = 2;
            this.antennaIDLlabel.Text = "Antenna ID";
            // 
            // tariValueLabel
            // 
            this.tariValueLabel.AutoSize = true;
            this.tariValueLabel.Location = new System.Drawing.Point(18, 44);
            this.tariValueLabel.Name = "tariValueLabel";
            this.tariValueLabel.Size = new System.Drawing.Size(55, 13);
            this.tariValueLabel.TabIndex = 4;
            this.tariValueLabel.Text = "Tari Value";
            // 
            // tari_TB
            // 
            this.tari_TB.Location = new System.Drawing.Point(105, 39);
            this.tari_TB.Name = "tari_TB";
            this.tari_TB.Size = new System.Drawing.Size(70, 20);
            this.tari_TB.TabIndex = 2;
            // 
            // rfModeGroupBox
            // 
            this.rfModeGroupBox.Controls.Add(this.rfModelistView);
            this.rfModeGroupBox.Controls.Add(this.rfModeTable_CB);
            this.rfModeGroupBox.Controls.Add(this.rfModeTablelabel);
            this.rfModeGroupBox.Location = new System.Drawing.Point(12, 59);
            this.rfModeGroupBox.Name = "rfModeGroupBox";
            this.rfModeGroupBox.Size = new System.Drawing.Size(251, 234);
            this.rfModeGroupBox.TabIndex = 6;
            this.rfModeGroupBox.TabStop = false;
            // 
            // rfModelistView
            // 
            this.rfModelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.parameterHeader,
            this.valueHeader1});
            this.rfModelistView.FullRowSelect = true;
            this.rfModelistView.GridLines = true;
            this.rfModelistView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
            this.rfModelistView.Location = new System.Drawing.Point(9, 57);
            this.rfModelistView.Name = "rfModelistView";
            this.rfModelistView.Size = new System.Drawing.Size(231, 165);
            this.rfModelistView.TabIndex = 4;
            this.rfModelistView.UseCompatibleStateImageBehavior = false;
            this.rfModelistView.View = System.Windows.Forms.View.Details;
            // 
            // parameterHeader
            // 
            this.parameterHeader.Text = "Parameter";
            this.parameterHeader.Width = 125;
            // 
            // valueHeader1
            // 
            this.valueHeader1.Text = "Value";
            this.valueHeader1.Width = 101;
            // 
            // rfModeTable_CB
            // 
            this.rfModeTable_CB.FormattingEnabled = true;
            this.rfModeTable_CB.Location = new System.Drawing.Point(93, 22);
            this.rfModeTable_CB.Name = "rfModeTable_CB";
            this.rfModeTable_CB.Size = new System.Drawing.Size(64, 21);
            this.rfModeTable_CB.TabIndex = 3;
            this.rfModeTable_CB.SelectedIndexChanged += new System.EventHandler(this.rfModeTable_CB_SelectedIndexChanged);
            // 
            // rfModeTablelabel
            // 
            this.rfModeTablelabel.AutoSize = true;
            this.rfModeTablelabel.Location = new System.Drawing.Point(6, 25);
            this.rfModeTablelabel.Name = "rfModeTablelabel";
            this.rfModeTablelabel.Size = new System.Drawing.Size(81, 13);
            this.rfModeTablelabel.TabIndex = 5;
            this.rfModeTablelabel.Text = "RF Mode Table";
            // 
            // rfModeApplybutton
            // 
            this.rfModeApplybutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rfModeApplybutton.Location = new System.Drawing.Point(188, 301);
            this.rfModeApplybutton.Name = "rfModeApplybutton";
            this.rfModeApplybutton.Size = new System.Drawing.Size(75, 23);
            this.rfModeApplybutton.TabIndex = 5;
            this.rfModeApplybutton.Text = "Apply";
            this.rfModeApplybutton.UseVisualStyleBackColor = true;
            this.rfModeApplybutton.Click += new System.EventHandler(this.rfModeApplybutton_Click);
            // 
            // RFModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 332);
            this.Controls.Add(this.rfModeApplybutton);
            this.Controls.Add(this.rfModeGroupBox);
            this.Controls.Add(this.tari_TB);
            this.Controls.Add(this.tariValueLabel);
            this.Controls.Add(this.antenna_CB);
            this.Controls.Add(this.antennaIDLlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RFModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RF Mode";
            this.Load += new System.EventHandler(this.RFMode_Load);
            this.rfModeGroupBox.ResumeLayout(false);
            this.rfModeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label antennaIDLlabel;
        private System.Windows.Forms.Label tariValueLabel;
        private System.Windows.Forms.GroupBox rfModeGroupBox;
        private System.Windows.Forms.Label rfModeTablelabel;
        private System.Windows.Forms.ColumnHeader parameterHeader;
        private System.Windows.Forms.ColumnHeader valueHeader1;
        private System.Windows.Forms.Button rfModeApplybutton;
        internal System.Windows.Forms.ComboBox antenna_CB;
        internal System.Windows.Forms.TextBox tari_TB;
        internal System.Windows.Forms.ComboBox rfModeTable_CB;
        internal System.Windows.Forms.ListView rfModelistView;
    }
}