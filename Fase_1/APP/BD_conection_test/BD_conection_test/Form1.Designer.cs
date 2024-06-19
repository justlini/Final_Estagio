namespace BD_conection_test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            numericUpDown2 = new NumericUpDown();
            button3 = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(13, 54);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(115, 27);
            numericUpDown1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 31);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(134, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(361, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 31);
            label2.Name = "label2";
            label2.Size = new Size(185, 20);
            label2.TabIndex = 3;
            label2.Text = "Nome a dar Update na BD";
            // 
            // button1
            // 
            button1.Location = new Point(12, 87);
            button1.Name = "button1";
            button1.Size = new Size(186, 33);
            button1.TabIndex = 4;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 155);
            label3.Name = "label3";
            label3.Size = new Size(283, 20);
            label3.TabIndex = 5;
            label3.Text = "Nome a inserir na BD (ID auto increment)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 178);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(482, 27);
            textBox2.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(12, 211);
            button2.Name = "button2";
            button2.Size = new Size(186, 33);
            button2.TabIndex = 7;
            button2.Text = "Insert new line";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(12, 292);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(483, 27);
            numericUpDown2.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(11, 325);
            button3.Name = "button3";
            button3.Size = new Size(186, 33);
            button3.TabIndex = 9;
            button3.Text = "Delete line";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 269);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 10;
            label4.Text = "ID";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 377);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(482, 174);
            dataGridView1.TabIndex = 11;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(13, 561);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(482, 112);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 685);
            Controls.Add(richTextBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(numericUpDown2);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Name = "Form1";
            Text = "Update";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox textBox2;
        private Button button2;
        private NumericUpDown numericUpDown2;
        private Button button3;
        private Label label4;
        private DataGridView dataGridView1;
        private RichTextBox richTextBox1;
    }
}
