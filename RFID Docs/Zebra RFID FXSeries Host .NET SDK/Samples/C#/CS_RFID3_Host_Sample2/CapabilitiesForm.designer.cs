namespace CS_RFID3_Host_Sample2
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
            this.ClientSize = new System.Drawing.Size(339, 317);
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