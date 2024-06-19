namespace Fase4
{
    partial class allDataBaseAcess
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
            this.dataGrid_DB = new System.Windows.Forms.DataGridView();
            this.chooseBd_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelSearch3 = new System.Windows.Forms.Label();
            this.search_TextBox3 = new System.Windows.Forms.TextBox();
            this.labelSearch2 = new System.Windows.Forms.Label();
            this.search_TextBox2 = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.labelSearch1 = new System.Windows.Forms.Label();
            this.search_TextBox1 = new System.Windows.Forms.TextBox();
            this.tabelaAtual_label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_DB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid_DB
            // 
            this.dataGrid_DB.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid_DB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_DB.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid_DB.Location = new System.Drawing.Point(12, 416);
            this.dataGrid_DB.Name = "dataGrid_DB";
            this.dataGrid_DB.RowHeadersVisible = false;
            this.dataGrid_DB.RowHeadersWidth = 51;
            this.dataGrid_DB.RowTemplate.Height = 24;
            this.dataGrid_DB.Size = new System.Drawing.Size(840, 290);
            this.dataGrid_DB.TabIndex = 0;
            // 
            // chooseBd_comboBox
            // 
            this.chooseBd_comboBox.FormattingEnabled = true;
            this.chooseBd_comboBox.Location = new System.Drawing.Point(147, 43);
            this.chooseBd_comboBox.Name = "chooseBd_comboBox";
            this.chooseBd_comboBox.Size = new System.Drawing.Size(342, 24);
            this.chooseBd_comboBox.TabIndex = 1;
            this.chooseBd_comboBox.SelectedIndexChanged += new System.EventHandler(this.chooseBd_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chooseBd_comboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabelas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecionar Tabela";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 118);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 251);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "     Procurar      ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelSearch3);
            this.groupBox2.Controls.Add(this.search_TextBox3);
            this.groupBox2.Controls.Add(this.labelSearch2);
            this.groupBox2.Controls.Add(this.search_TextBox2);
            this.groupBox2.Controls.Add(this.searchButton);
            this.groupBox2.Controls.Add(this.labelSearch1);
            this.groupBox2.Controls.Add(this.search_TextBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 210);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procurar Tags";
            // 
            // labelSearch3
            // 
            this.labelSearch3.AutoSize = true;
            this.labelSearch3.Location = new System.Drawing.Point(42, 148);
            this.labelSearch3.Name = "labelSearch3";
            this.labelSearch3.Size = new System.Drawing.Size(52, 16);
            this.labelSearch3.TabIndex = 6;
            this.labelSearch3.Text = "Antena:";
            // 
            // search_TextBox3
            // 
            this.search_TextBox3.Location = new System.Drawing.Point(97, 145);
            this.search_TextBox3.Name = "search_TextBox3";
            this.search_TextBox3.Size = new System.Drawing.Size(342, 22);
            this.search_TextBox3.TabIndex = 5;
            // 
            // labelSearch2
            // 
            this.labelSearch2.AutoSize = true;
            this.labelSearch2.Location = new System.Drawing.Point(10, 95);
            this.labelSearch2.Name = "labelSearch2";
            this.labelSearch2.Size = new System.Drawing.Size(84, 16);
            this.labelSearch2.TabIndex = 4;
            this.labelSearch2.Text = "EPC da Tag:";
            // 
            // search_TextBox2
            // 
            this.search_TextBox2.Location = new System.Drawing.Point(97, 92);
            this.search_TextBox2.Name = "search_TextBox2";
            this.search_TextBox2.Size = new System.Drawing.Size(342, 22);
            this.search_TextBox2.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(667, 170);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(147, 34);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Procurar";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // labelSearch1
            // 
            this.labelSearch1.AutoSize = true;
            this.labelSearch1.Location = new System.Drawing.Point(24, 42);
            this.labelSearch1.Name = "labelSearch1";
            this.labelSearch1.Size = new System.Drawing.Size(70, 16);
            this.labelSearch1.TabIndex = 1;
            this.labelSearch1.Text = "ID da Tag:";
            // 
            // search_TextBox1
            // 
            this.search_TextBox1.Location = new System.Drawing.Point(97, 39);
            this.search_TextBox1.Name = "search_TextBox1";
            this.search_TextBox1.Size = new System.Drawing.Size(342, 22);
            this.search_TextBox1.TabIndex = 0;
            // 
            // tabelaAtual_label
            // 
            this.tabelaAtual_label.AutoSize = true;
            this.tabelaAtual_label.Location = new System.Drawing.Point(13, 397);
            this.tabelaAtual_label.Name = "tabelaAtual_label";
            this.tabelaAtual_label.Size = new System.Drawing.Size(54, 16);
            this.tabelaAtual_label.TabIndex = 3;
            this.tabelaAtual_label.Text = "Tabela:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(688, 390);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Mostrar todas as Tags";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // allDataBaseAcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 718);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabelaAtual_label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGrid_DB);
            this.MaximizeBox = false;
            this.Name = "allDataBaseAcess";
            this.Text = "allDataBaseAcess";
            this.Load += new System.EventHandler(this.allDataBaseAcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_DB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_DB;
        private System.Windows.Forms.ComboBox chooseBd_comboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label tabelaAtual_label;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox search_TextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelSearch1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelSearch3;
        private System.Windows.Forms.TextBox search_TextBox3;
        private System.Windows.Forms.Label labelSearch2;
        private System.Windows.Forms.TextBox search_TextBox2;
    }
}