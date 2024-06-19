namespace Fase4
{
    partial class initialPage
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
            this.clearVars = new System.Windows.Forms.Button();
            this.quantMinDiaText = new System.Windows.Forms.NumericUpDown();
            this.quantidadeText = new System.Windows.Forms.NumericUpDown();
            this.submitModelBTN = new System.Windows.Forms.Button();
            this.idSerieText = new System.Windows.Forms.TextBox();
            this.artigoText = new System.Windows.Forms.TextBox();
            this.idOrdProdText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showDbButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.quantMinDiaText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeText)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clearVars
            // 
            this.clearVars.Location = new System.Drawing.Point(180, 333);
            this.clearVars.Name = "clearVars";
            this.clearVars.Size = new System.Drawing.Size(147, 34);
            this.clearVars.TabIndex = 56;
            this.clearVars.Text = "Limpar dados";
            this.clearVars.UseVisualStyleBackColor = true;
            this.clearVars.Click += new System.EventHandler(this.clearVars_Click);
            // 
            // quantMinDiaText
            // 
            this.quantMinDiaText.Location = new System.Drawing.Point(149, 220);
            this.quantMinDiaText.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantMinDiaText.Name = "quantMinDiaText";
            this.quantMinDiaText.Size = new System.Drawing.Size(338, 22);
            this.quantMinDiaText.TabIndex = 55;
            // 
            // quantidadeText
            // 
            this.quantidadeText.Location = new System.Drawing.Point(149, 166);
            this.quantidadeText.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantidadeText.Name = "quantidadeText";
            this.quantidadeText.Size = new System.Drawing.Size(338, 22);
            this.quantidadeText.TabIndex = 54;
            // 
            // submitModelBTN
            // 
            this.submitModelBTN.Location = new System.Drawing.Point(18, 333);
            this.submitModelBTN.Name = "submitModelBTN";
            this.submitModelBTN.Size = new System.Drawing.Size(147, 34);
            this.submitModelBTN.TabIndex = 53;
            this.submitModelBTN.Text = "Confirmar Dados";
            this.submitModelBTN.UseVisualStyleBackColor = true;
            this.submitModelBTN.Click += new System.EventHandler(this.submitModelBTN_Click);
            // 
            // idSerieText
            // 
            this.idSerieText.Location = new System.Drawing.Point(149, 273);
            this.idSerieText.Name = "idSerieText";
            this.idSerieText.Size = new System.Drawing.Size(338, 22);
            this.idSerieText.TabIndex = 52;
            // 
            // artigoText
            // 
            this.artigoText.Location = new System.Drawing.Point(149, 108);
            this.artigoText.Name = "artigoText";
            this.artigoText.Size = new System.Drawing.Size(338, 22);
            this.artigoText.TabIndex = 51;
            // 
            // idOrdProdText
            // 
            this.idOrdProdText.Location = new System.Drawing.Point(149, 52);
            this.idOrdProdText.Name = "idOrdProdText";
            this.idOrdProdText.Size = new System.Drawing.Size(338, 22);
            this.idOrdProdText.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "ID de Serie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Capacidade diária:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Artigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "ID ordem produção:";
            // 
            // showDbButton
            // 
            this.showDbButton.Location = new System.Drawing.Point(340, 333);
            this.showDbButton.Name = "showDbButton";
            this.showDbButton.Size = new System.Drawing.Size(147, 34);
            this.showDbButton.TabIndex = 57;
            this.showDbButton.Text = "Base de Dados";
            this.showDbButton.UseVisualStyleBackColor = true;
            this.showDbButton.Click += new System.EventHandler(this.showDbButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 30);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.exitToolStripMenuItem.Text = "Sair";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.aboutToolStripMenuItem.Text = "Sobre";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quantMinDiaText);
            this.groupBox1.Controls.Add(this.clearVars);
            this.groupBox1.Controls.Add(this.showDbButton);
            this.groupBox1.Controls.Add(this.idOrdProdText);
            this.groupBox1.Controls.Add(this.quantidadeText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.submitModelBTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idSerieText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.artigoText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 395);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info Ordem Produção";
            // 
            // initialPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 452);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "initialPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "initial page";
            this.Load += new System.EventHandler(this.initialPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantMinDiaText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeText)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown quantMinDiaText;
        private System.Windows.Forms.NumericUpDown quantidadeText;
        private System.Windows.Forms.Button submitModelBTN;
        private System.Windows.Forms.TextBox idSerieText;
        private System.Windows.Forms.TextBox artigoText;
        private System.Windows.Forms.TextBox idOrdProdText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearVars;
        private System.Windows.Forms.Button showDbButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

