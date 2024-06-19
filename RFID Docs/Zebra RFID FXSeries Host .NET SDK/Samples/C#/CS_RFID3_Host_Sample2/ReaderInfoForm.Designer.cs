using Symbol.RFID3; 
namespace CS_RFID3_Host_Sample2
{
    partial class ReaderInfoForm
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
            this.ReaderNamelabel = new System.Windows.Forms.Label();
            this.FirmwareVersionlabel = new System.Windows.Forms.Label();
            this.RamAvailablelabel = new System.Windows.Forms.Label();
            this.FlashAvailablelabel = new System.Windows.Forms.Label();
            this.SerialNumberlabel = new System.Windows.Forms.Label();
            this.SerialNumberDisplaylabel = new System.Windows.Forms.Label();
            this.FlashAvailableDisplaylabel = new System.Windows.Forms.Label();
            this.RamAvailableDisplayLabel = new System.Windows.Forms.Label();
            this.FirmwareVersionDisplaylabel = new System.Windows.Forms.Label();
            this.ReaderNameDisplaylabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReaderNamelabel
            // 
            this.ReaderNamelabel.AutoSize = true;
            this.ReaderNamelabel.Location = new System.Drawing.Point(29, 22);
            this.ReaderNamelabel.Name = "ReaderNamelabel";
            this.ReaderNamelabel.Size = new System.Drawing.Size(73, 13);
            this.ReaderNamelabel.TabIndex = 0;
            this.ReaderNamelabel.Text = "Reader Name";
            // 
            // FirmwareVersionlabel
            // 
            this.FirmwareVersionlabel.AutoSize = true;
            this.FirmwareVersionlabel.Location = new System.Drawing.Point(29, 50);
            this.FirmwareVersionlabel.Name = "FirmwareVersionlabel";
            this.FirmwareVersionlabel.Size = new System.Drawing.Size(87, 13);
            this.FirmwareVersionlabel.TabIndex = 1;
            this.FirmwareVersionlabel.Text = "Firmware Version";
            // 
            // RamAvailablelabel
            // 
            this.RamAvailablelabel.AutoSize = true;
            this.RamAvailablelabel.Location = new System.Drawing.Point(29, 78);
            this.RamAvailablelabel.Name = "RamAvailablelabel";
            this.RamAvailablelabel.Size = new System.Drawing.Size(77, 13);
            this.RamAvailablelabel.TabIndex = 2;
            this.RamAvailablelabel.Text = "RAM Available";
            // 
            // FlashAvailablelabel
            // 
            this.FlashAvailablelabel.AutoSize = true;
            this.FlashAvailablelabel.Location = new System.Drawing.Point(29, 106);
            this.FlashAvailablelabel.Name = "FlashAvailablelabel";
            this.FlashAvailablelabel.Size = new System.Drawing.Size(78, 13);
            this.FlashAvailablelabel.TabIndex = 3;
            this.FlashAvailablelabel.Text = "Flash Available";
            // 
            // SerialNumberlabel
            // 
            this.SerialNumberlabel.AutoSize = true;
            this.SerialNumberlabel.Location = new System.Drawing.Point(29, 134);
            this.SerialNumberlabel.Name = "SerialNumberlabel";
            this.SerialNumberlabel.Size = new System.Drawing.Size(73, 13);
            this.SerialNumberlabel.TabIndex = 4;
            this.SerialNumberlabel.Text = "Serial Number";
            // 
            // SerialNumberDisplaylabel
            // 
            this.SerialNumberDisplaylabel.AutoSize = true;
            this.SerialNumberDisplaylabel.Location = new System.Drawing.Point(135, 134);
            this.SerialNumberDisplaylabel.Name = "SerialNumberDisplaylabel";
            this.SerialNumberDisplaylabel.Size = new System.Drawing.Size(0, 13);
            this.SerialNumberDisplaylabel.TabIndex = 9;
            // 
            // FlashAvailableDisplaylabel
            // 
            this.FlashAvailableDisplaylabel.AutoSize = true;
            this.FlashAvailableDisplaylabel.Location = new System.Drawing.Point(135, 106);
            this.FlashAvailableDisplaylabel.Name = "FlashAvailableDisplaylabel";
            this.FlashAvailableDisplaylabel.Size = new System.Drawing.Size(0, 13);
            this.FlashAvailableDisplaylabel.TabIndex = 8;
            // 
            // RamAvailableDisplayLabel
            // 
            this.RamAvailableDisplayLabel.AutoSize = true;
            this.RamAvailableDisplayLabel.Location = new System.Drawing.Point(135, 78);
            this.RamAvailableDisplayLabel.Name = "RamAvailableDisplayLabel";
            this.RamAvailableDisplayLabel.Size = new System.Drawing.Size(0, 13);
            this.RamAvailableDisplayLabel.TabIndex = 7;

            // 
            // FirmwareVersionDisplaylabel
            // 
            this.FirmwareVersionDisplaylabel.AutoSize = true;
            this.FirmwareVersionDisplaylabel.Location = new System.Drawing.Point(135, 50);
            this.FirmwareVersionDisplaylabel.Name = "FirmwareVersionDisplaylabel";
            this.FirmwareVersionDisplaylabel.Size = new System.Drawing.Size(0, 13);
            this.FirmwareVersionDisplaylabel.TabIndex = 6;

            // 
            // ReaderNameDisplaylabel
            // 
            this.ReaderNameDisplaylabel.AutoSize = true;
            this.ReaderNameDisplaylabel.Location = new System.Drawing.Point(135, 22);
            this.ReaderNameDisplaylabel.Name = "ReaderNameDisplaylabel";
            this.ReaderNameDisplaylabel.Size = new System.Drawing.Size(0, 13);
            this.ReaderNameDisplaylabel.TabIndex = 5;
           
            // 
            // ReaderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(277, 172);
            this.Controls.Add(this.SerialNumberDisplaylabel);
            this.Controls.Add(this.FlashAvailableDisplaylabel);
            this.Controls.Add(this.RamAvailableDisplayLabel);
            this.Controls.Add(this.FirmwareVersionDisplaylabel);
            this.Controls.Add(this.ReaderNameDisplaylabel);
            this.Controls.Add(this.SerialNumberlabel);
            this.Controls.Add(this.FlashAvailablelabel);
            this.Controls.Add(this.RamAvailablelabel);
            this.Controls.Add(this.FirmwareVersionlabel);
            this.Controls.Add(this.ReaderNamelabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReaderInfoForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reader System Info";
            this.Load += new System.EventHandler(this.ReaderInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReaderNamelabel;
        private System.Windows.Forms.Label FirmwareVersionlabel;
        private System.Windows.Forms.Label RamAvailablelabel;
        private System.Windows.Forms.Label FlashAvailablelabel;
        private System.Windows.Forms.Label SerialNumberlabel;
        private System.Windows.Forms.Label SerialNumberDisplaylabel;
        private System.Windows.Forms.Label FlashAvailableDisplaylabel;
        private System.Windows.Forms.Label RamAvailableDisplayLabel;
        private System.Windows.Forms.Label FirmwareVersionDisplaylabel;
        private System.Windows.Forms.Label ReaderNameDisplaylabel;
    }
}