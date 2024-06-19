namespace CS_RFID3_Host_Sample2
{
    partial class LocateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.locateButton = new System.Windows.Forms.Button();
            this.tagID_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(96, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Locating tag";
            // 
            // locateButton
            // 
            this.locateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locateButton.Location = new System.Drawing.Point(179, 233);
            this.locateButton.Name = "locateButton";
            this.locateButton.Size = new System.Drawing.Size(75, 23);
            this.locateButton.TabIndex = 0;
            this.locateButton.Text = "Start";
            this.locateButton.Click += new System.EventHandler(this.locateButton_Click);
            // 
            // tagID_TB
            // 
            this.tagID_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagID_TB.Location = new System.Drawing.Point(24, 32);
            this.tagID_TB.Name = "tagID_TB";
            this.tagID_TB.Size = new System.Drawing.Size(226, 21);
            this.tagID_TB.TabIndex = 3;
            // 
            // LocateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(277, 268);
            this.Controls.Add(this.tagID_TB);
            this.Controls.Add(this.locateButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "LocateForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Locate Tag";
            this.Load += new System.EventHandler(this.LocateForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LocateForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button locateButton;
        private System.Windows.Forms.TextBox tagID_TB;

       
    }
}