namespace CS_RFID3_Host_Sample2
{
    partial class TagDataForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("TagID");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Antenna");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("RSSI");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Phase");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("PC Bits");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Memory Bank Data");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("MB");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Offset");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Length");
            this.tagDataView = new System.Windows.Forms.ListView();
            this.ItemCol = new System.Windows.Forms.ColumnHeader();
            this.ValueCol = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // tagDataView
            // 
            this.tagDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemCol,
            this.ValueCol});
            this.tagDataView.FullRowSelect = true;
            this.tagDataView.GridLines = true;
            this.tagDataView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.tagDataView.Location = new System.Drawing.Point(12, 12);
            this.tagDataView.Name = "tagDataView";
            this.tagDataView.Size = new System.Drawing.Size(311, 142);
            this.tagDataView.TabIndex = 2;
            this.tagDataView.UseCompatibleStateImageBehavior = false;
            this.tagDataView.View = System.Windows.Forms.View.Details;
            // 
            // ItemCol
            // 
            this.ItemCol.Text = "Item";
            this.ItemCol.Width = 103;
            // 
            // ValueCol
            // 
            this.ValueCol.Text = "Value";
            this.ValueCol.Width = 194;
            // 
            // TagDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 167);
            this.Controls.Add(this.tagDataView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TagData";
            this.Load += new System.EventHandler(this.TagData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView tagDataView;
        private System.Windows.Forms.ColumnHeader ItemCol;
        private System.Windows.Forms.ColumnHeader ValueCol;
    }
}