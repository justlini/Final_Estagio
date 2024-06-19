namespace Receber_tags_tabela_01
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.read_button = new System.Windows.Forms.Button();
            this.clearDB_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.readCountLabel = new System.Windows.Forms.Label();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tagDataView = new System.Windows.Forms.DataGridView();
            this.insertDB_button = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // read_button
            // 
            resources.ApplyResources(this.read_button, "read_button");
            this.read_button.Name = "read_button";
            this.read_button.UseCompatibleTextRendering = true;
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // clearDB_button
            // 
            resources.ApplyResources(this.clearDB_button, "clearDB_button");
            this.clearDB_button.Name = "clearDB_button";
            this.clearDB_button.UseCompatibleTextRendering = true;
            this.clearDB_button.UseVisualStyleBackColor = true;
            this.clearDB_button.Click += new System.EventHandler(this.clearDB_button_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // readCountLabel
            // 
            resources.ApplyResources(this.readCountLabel, "readCountLabel");
            this.readCountLabel.Name = "readCountLabel";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            resources.ApplyResources(this.configToolStripMenuItem, "configToolStripMenuItem");
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            resources.ApplyResources(this.connectionToolStripMenuItem, "connectionToolStripMenuItem");
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            resources.ApplyResources(this.disconnectToolStripMenuItem, "disconnectToolStripMenuItem");
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // tagDataView
            // 
            this.tagDataView.AllowUserToDeleteRows = false;
            this.tagDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tagDataView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tagDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.tagDataView, "tagDataView");
            this.tagDataView.Name = "tagDataView";
            this.tagDataView.ReadOnly = true;
            this.tagDataView.RowHeadersVisible = false;
            this.tagDataView.RowTemplate.Height = 24;
            this.tagDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // insertDB_button
            // 
            resources.ApplyResources(this.insertDB_button, "insertDB_button");
            this.insertDB_button.Name = "insertDB_button";
            this.insertDB_button.UseCompatibleTextRendering = true;
            this.insertDB_button.UseVisualStyleBackColor = true;
            this.insertDB_button.Click += new System.EventHandler(this.insertDB_button_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insertDB_button);
            this.Controls.Add(this.tagDataView);
            this.Controls.Add(this.readCountLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clearDB_button);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button read_button;
        private System.Windows.Forms.Button clearDB_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label readCountLabel;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView tagDataView;
        private System.Windows.Forms.Button insertDB_button;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

