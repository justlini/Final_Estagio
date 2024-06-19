namespace bd_connection_teste_fase2
{
    partial class LeituraTag
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            textBox6 = new TextBox();
            label9 = new Label();
            button4 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(265, 28);
            label1.TabIndex = 0;
            label1.Text = "LEITURA DE TAGS (TABELA 2)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 445);
            label7.Name = "label7";
            label7.Size = new Size(176, 20);
            label7.TabIndex = 12;
            label7.Text = "SQL LeituraTag (Tabela 2)";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 473);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(427, 164);
            dataGridView1.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(109, 191);
            button2.Name = "button2";
            button2.Size = new Size(206, 31);
            button2.TabIndex = 16;
            button2.Text = "Procurar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(293, 440);
            button3.Name = "button3";
            button3.Size = new Size(146, 31);
            button3.TabIndex = 17;
            button3.Text = "Mostra tabela";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 42);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(427, 396);
            tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(419, 363);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Adicionar";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(102, 318);
            button1.Name = "button1";
            button1.Size = new Size(206, 31);
            button1.TabIndex = 22;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 156);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(407, 27);
            textBox5.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 133);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 20;
            label6.Text = "Posto";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(9, 220);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(404, 27);
            textBox4.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 197);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 18;
            label5.Text = "Hora_Leitura";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(9, 280);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(404, 27);
            textBox3.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 257);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 16;
            label4.Text = "Data_Leitura";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 91);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(407, 27);
            textBox2.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 68);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 14;
            label3.Text = "ID_Tag";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(407, 27);
            textBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 8);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 12;
            label2.Text = "ID_Ordem_de_Producao";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox6);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(419, 363);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Procurar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(6, 144);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(407, 27);
            textBox6.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 121);
            label9.Name = "label9";
            label9.Size = new Size(168, 20);
            label9.TabIndex = 17;
            label9.Text = "ID_Ordem_de_Producao";
            // 
            // button4
            // 
            button4.Location = new Point(280, 11);
            button4.Name = "button4";
            button4.Size = new Size(149, 29);
            button4.TabIndex = 19;
            button4.Text = "Produção (Tabela 1)";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // LeituraTag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 649);
            Controls.Add(button4);
            Controls.Add(tabControl1);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "LeituraTag";
            Text = "Leitura de Tags";
            Load += LeituraTag_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button1;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private TabPage tabPage2;
        private TextBox textBox6;
        private Label label9;
        private Button button4;
        private System.Windows.Forms.Timer timer1;
    }
}