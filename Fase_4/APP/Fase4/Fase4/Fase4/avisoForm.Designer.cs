namespace Fase4
{
    partial class avisoForm
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
            this.rfid_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.aviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rfid_button
            // 
            this.rfid_button.Location = new System.Drawing.Point(112, 197);
            this.rfid_button.Name = "rfid_button";
            this.rfid_button.Size = new System.Drawing.Size(147, 34);
            this.rfid_button.TabIndex = 0;
            this.rfid_button.Text = "Iniciar Leituras";
            this.rfid_button.UseVisualStyleBackColor = true;
            this.rfid_button.Click += new System.EventHandler(this.rfid_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(282, 197);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(147, 34);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancelar";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // aviso
            // 
            this.aviso.AutoSize = true;
            this.aviso.Location = new System.Drawing.Point(88, 28);
            this.aviso.Name = "aviso";
            this.aviso.Size = new System.Drawing.Size(44, 16);
            this.aviso.TabIndex = 2;
            this.aviso.Text = "label1";
            // 
            // avisoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 256);
            this.Controls.Add(this.aviso);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.rfid_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "avisoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "avisoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.avisoForm_FormClosed);
            this.Load += new System.EventHandler(this.avisoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rfid_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label aviso;
    }
}