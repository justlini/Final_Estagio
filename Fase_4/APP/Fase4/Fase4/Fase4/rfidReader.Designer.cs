namespace Fase4
{
    partial class rfidReader
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
            this.components = new System.ComponentModel.Container();
            this.clear_checkBox = new System.Windows.Forms.CheckBox();
            this.viewBd_btn = new System.Windows.Forms.Button();
            this.insertDB_button = new System.Windows.Forms.Button();
            this.tagDataView = new System.Windows.Forms.DataGridView();
            this.readCountLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.read_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textIdOrdProd = new System.Windows.Forms.TextBox();
            this.textArtigo = new System.Windows.Forms.TextBox();
            this.textQuantidade = new System.Windows.Forms.TextBox();
            this.textQuantMin = new System.Windows.Forms.TextBox();
            this.textIdSerie = new System.Windows.Forms.TextBox();
            this.hours_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.date_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tagDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clear_checkBox
            // 
            this.clear_checkBox.AutoSize = true;
            this.clear_checkBox.Enabled = false;
            this.clear_checkBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clear_checkBox.Location = new System.Drawing.Point(650, 372);
            this.clear_checkBox.Name = "clear_checkBox";
            this.clear_checkBox.Size = new System.Drawing.Size(191, 20);
            this.clear_checkBox.TabIndex = 30;
            this.clear_checkBox.Text = "Mostrar apenas tags atuais";
            this.clear_checkBox.UseVisualStyleBackColor = true;
            this.clear_checkBox.CheckedChanged += new System.EventHandler(this.clear_checkBox_CheckedChanged);
            // 
            // viewBd_btn
            // 
            this.viewBd_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewBd_btn.Location = new System.Drawing.Point(704, 326);
            this.viewBd_btn.Name = "viewBd_btn";
            this.viewBd_btn.Size = new System.Drawing.Size(147, 34);
            this.viewBd_btn.TabIndex = 29;
            this.viewBd_btn.Text = "Ver base de dados";
            this.viewBd_btn.UseCompatibleTextRendering = true;
            this.viewBd_btn.UseVisualStyleBackColor = true;
            this.viewBd_btn.Click += new System.EventHandler(this.viewBd_btn_Click);
            // 
            // insertDB_button
            // 
            this.insertDB_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.insertDB_button.Location = new System.Drawing.Point(478, 326);
            this.insertDB_button.Name = "insertDB_button";
            this.insertDB_button.Size = new System.Drawing.Size(220, 34);
            this.insertDB_button.TabIndex = 28;
            this.insertDB_button.Text = "Inserir manualmente na DB";
            this.insertDB_button.UseCompatibleTextRendering = true;
            this.insertDB_button.UseVisualStyleBackColor = true;
            this.insertDB_button.Click += new System.EventHandler(this.insertDB_button_Click);
            // 
            // tagDataView
            // 
            this.tagDataView.AllowUserToDeleteRows = false;
            this.tagDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tagDataView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tagDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagDataView.Location = new System.Drawing.Point(12, 398);
            this.tagDataView.Name = "tagDataView";
            this.tagDataView.ReadOnly = true;
            this.tagDataView.RowHeadersVisible = false;
            this.tagDataView.RowHeadersWidth = 51;
            this.tagDataView.RowTemplate.Height = 24;
            this.tagDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tagDataView.Size = new System.Drawing.Size(840, 316);
            this.tagDataView.TabIndex = 27;
            // 
            // readCountLabel
            // 
            this.readCountLabel.AutoSize = true;
            this.readCountLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.readCountLabel.Location = new System.Drawing.Point(165, 335);
            this.readCountLabel.Name = "readCountLabel";
            this.readCountLabel.Size = new System.Drawing.Size(104, 16);
            this.readCountLabel.TabIndex = 26;
            this.readCountLabel.Text = "Nº de Leituras: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(797, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 26);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 730);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(779, 22);
            this.textBox1.TabIndex = 24;
            // 
            // read_button
            // 
            this.read_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.read_button.Location = new System.Drawing.Point(12, 326);
            this.read_button.Name = "read_button";
            this.read_button.Size = new System.Drawing.Size(147, 34);
            this.read_button.TabIndex = 21;
            this.read_button.Text = "Parar leitura";
            this.read_button.UseCompatibleTextRendering = true;
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.configToolStripMenuItem.Text = "Opções";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Sair";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "Sobre";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "ID ordem produção:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Artigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Quantidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Capacidade diária:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "ID Serie:";
            // 
            // textIdOrdProd
            // 
            this.textIdOrdProd.Location = new System.Drawing.Point(172, 44);
            this.textIdOrdProd.Name = "textIdOrdProd";
            this.textIdOrdProd.ReadOnly = true;
            this.textIdOrdProd.Size = new System.Drawing.Size(274, 22);
            this.textIdOrdProd.TabIndex = 40;
            // 
            // textArtigo
            // 
            this.textArtigo.Location = new System.Drawing.Point(172, 84);
            this.textArtigo.Name = "textArtigo";
            this.textArtigo.ReadOnly = true;
            this.textArtigo.Size = new System.Drawing.Size(274, 22);
            this.textArtigo.TabIndex = 41;
            // 
            // textQuantidade
            // 
            this.textQuantidade.Location = new System.Drawing.Point(172, 124);
            this.textQuantidade.Name = "textQuantidade";
            this.textQuantidade.ReadOnly = true;
            this.textQuantidade.Size = new System.Drawing.Size(274, 22);
            this.textQuantidade.TabIndex = 42;
            // 
            // textQuantMin
            // 
            this.textQuantMin.Location = new System.Drawing.Point(172, 164);
            this.textQuantMin.Name = "textQuantMin";
            this.textQuantMin.ReadOnly = true;
            this.textQuantMin.Size = new System.Drawing.Size(274, 22);
            this.textQuantMin.TabIndex = 43;
            // 
            // textIdSerie
            // 
            this.textIdSerie.Location = new System.Drawing.Point(172, 203);
            this.textIdSerie.Name = "textIdSerie";
            this.textIdSerie.ReadOnly = true;
            this.textIdSerie.Size = new System.Drawing.Size(274, 22);
            this.textIdSerie.TabIndex = 44;
            // 
            // hours_label
            // 
            this.hours_label.AutoSize = true;
            this.hours_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hours_label.Location = new System.Drawing.Point(610, 146);
            this.hours_label.Name = "hours_label";
            this.hours_label.Size = new System.Drawing.Size(111, 29);
            this.hours_label.TabIndex = 45;
            this.hours_label.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_label.Location = new System.Drawing.Point(594, 114);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(141, 29);
            this.date_label.TabIndex = 46;
            this.date_label.Text = "00/00/0000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_label);
            this.groupBox1.Controls.Add(this.hours_label);
            this.groupBox1.Controls.Add(this.textIdSerie);
            this.groupBox1.Controls.Add(this.textQuantMin);
            this.groupBox1.Controls.Add(this.textQuantidade);
            this.groupBox1.Controls.Add(this.textArtigo);
            this.groupBox1.Controls.Add(this.textIdOrdProd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 264);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info. Ordem de Produção";
            // 
            // rfidReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 766);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clear_checkBox);
            this.Controls.Add(this.viewBd_btn);
            this.Controls.Add(this.insertDB_button);
            this.Controls.Add(this.tagDataView);
            this.Controls.Add(this.readCountLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "rfidReader";
            this.Text = "rfidReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.rfidReader_FormClosing);
            this.Load += new System.EventHandler(this.rfidReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox clear_checkBox;
        private System.Windows.Forms.Button viewBd_btn;
        private System.Windows.Forms.Button insertDB_button;
        private System.Windows.Forms.DataGridView tagDataView;
        private System.Windows.Forms.Label readCountLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button read_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textIdOrdProd;
        private System.Windows.Forms.TextBox textArtigo;
        private System.Windows.Forms.TextBox textQuantidade;
        private System.Windows.Forms.TextBox textQuantMin;
        private System.Windows.Forms.TextBox textIdSerie;
        private System.Windows.Forms.Label hours_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}