namespace CS_RFID3_Host_Sample1
{
    partial class CapabilitiesForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Reader ID");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Firmware Version");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Model Name");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("No. of Antennas");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("No. of GPI");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("No. of GPO");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Max Ops in Access Sequence");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Max No. Of Pre-Filters");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Country Code");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Communication Standard");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("UTC Clock");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Block Erase");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Block Write");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Block Permalock");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Recommission");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Write UMI");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("State-aware Singulation");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Tag Event Reporting");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("RSSI Filtering");
            this.capabilitiesView = new System.Windows.Forms.ListView();
            this.CapabilityCol = new System.Windows.Forms.ColumnHeader();
            this.ValueCol = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // capabilitiesView
            // 
            this.capabilitiesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CapabilityCol,
            this.ValueCol});
            this.capabilitiesView.FullRowSelect = true;
            this.capabilitiesView.GridLines = true;
            this.capabilitiesView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
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
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19});
            this.capabilitiesView.Location = new System.Drawing.Point(12, 12);
            this.capabilitiesView.Name = "capabilitiesView";
            this.capabilitiesView.Size = new System.Drawing.Size(313, 290);
            this.capabilitiesView.TabIndex = 1;
            this.capabilitiesView.UseCompatibleStateImageBehavior = false;
            this.capabilitiesView.View = System.Windows.Forms.View.Details;
            // 
            // CapabilityCol
            // 
            this.CapabilityCol.Text = "Capability";
            this.CapabilityCol.Width = 152;
            // 
            // ValueCol
            // 
            this.ValueCol.Text = "Value";
            this.ValueCol.Width = 157;
            // 
            // CapabilitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 318);
            this.Controls.Add(this.capabilitiesView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CapabilitiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Capabilities";
            this.Load += new System.EventHandler(this.Capabilities_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader CapabilityCol;
        private System.Windows.Forms.ColumnHeader ValueCol;
        internal System.Windows.Forms.ListView capabilitiesView;
    }
}