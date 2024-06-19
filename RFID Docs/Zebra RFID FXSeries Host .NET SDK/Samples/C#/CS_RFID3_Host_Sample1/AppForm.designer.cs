namespace CS_RFID3_Host_Sample1
{
    partial class AppForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capabilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.gpiLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.functionCallStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gpiStateGB = new System.Windows.Forms.GroupBox();
            this.gpiNumberLabel = new System.Windows.Forms.Label();
            this.transmitPowerGB = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dataContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tagDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockWriteDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockEraseDataContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.totalTagLabel = new System.Windows.Forms.Label();
            this.clearReports_CB = new System.Windows.Forms.CheckBox();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gpiStateGB.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            this.dataContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.capabilitiesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.connectionToolStripMenuItem.Text = "Connection...";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // capabilitiesToolStripMenuItem
            // 
            this.capabilitiesToolStripMenuItem.Name = "capabilitiesToolStripMenuItem";
            this.capabilitiesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.capabilitiesToolStripMenuItem.Text = "Capabilities...";
            this.capabilitiesToolStripMenuItem.Click += new System.EventHandler(this.capabilitiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // inventoryList
            // 
            this.inventoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(10, 65);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(762, 425);
            this.inventoryList.TabIndex = 1;
            this.inventoryList.UseCompatibleStateImageBehavior = false;
            this.inventoryList.View = System.Windows.Forms.View.Details;
            this.inventoryList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.inventoryList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EPC ID";
            this.columnHeader1.Width = 202;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Antenna";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tag Count";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 73;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "RSSI";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PC Bits";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 55;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Memory Bank Data";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 185;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "MB";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 55;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Offset";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 50;
            // 
            // gpiLabel
            // 
            this.gpiLabel.AutoSize = true;
            this.gpiLabel.Location = new System.Drawing.Point(6, 27);
            this.gpiLabel.Name = "gpiLabel";
            this.gpiLabel.Size = new System.Drawing.Size(68, 13);
            this.gpiLabel.TabIndex = 5;
            this.gpiLabel.Text = "Red For Low";
            // 
            // readButton
            // 
            this.readButton.Enabled = false;
            this.readButton.Location = new System.Drawing.Point(11, 35);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(94, 23);
            this.readButton.TabIndex = 2;
            this.readButton.Text = "Start Reading";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GreenYellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(80, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(114, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.GreenYellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(150, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(185, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(321, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.GreenYellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(288, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(254, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "  ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.GreenYellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(220, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "  ";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionCallStatusLabel,
            this.connectionStatusLabel,
            this.connectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 493);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(784, 25);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip";
            // 
            // functionCallStatusLabel
            // 
            this.functionCallStatusLabel.AutoSize = false;
            this.functionCallStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.functionCallStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.functionCallStatusLabel.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.functionCallStatusLabel.Name = "functionCallStatusLabel";
            this.functionCallStatusLabel.Size = new System.Drawing.Size(716, 20);
            this.functionCallStatusLabel.Text = "Ready";
            this.functionCallStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = false;
            this.connectionStatus.BackgroundImage = global::CS_RFID3_Host_Sample1.Properties.Resources.disconnected;
            this.connectionStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectionStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.connectionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(50, 20);
            this.connectionStatus.Text = "Disconnected";
            // 
            // gpiStateGB
            // 
            this.gpiStateGB.Controls.Add(this.gpiNumberLabel);
            this.gpiStateGB.Controls.Add(this.label6);
            this.gpiStateGB.Controls.Add(this.label7);
            this.gpiStateGB.Controls.Add(this.label8);
            this.gpiStateGB.Controls.Add(this.label9);
            this.gpiStateGB.Controls.Add(this.label5);
            this.gpiStateGB.Controls.Add(this.label4);
            this.gpiStateGB.Controls.Add(this.label3);
            this.gpiStateGB.Controls.Add(this.label2);
            this.gpiStateGB.Controls.Add(this.gpiLabel);
            this.gpiStateGB.Location = new System.Drawing.Point(12, 331);
            this.gpiStateGB.Name = "gpiStateGB";
            this.gpiStateGB.Size = new System.Drawing.Size(347, 54);
            this.gpiStateGB.TabIndex = 20;
            this.gpiStateGB.TabStop = false;
            this.gpiStateGB.Text = "GPI State";
            // 
            // gpiNumberLabel
            // 
            this.gpiNumberLabel.AutoSize = true;
            this.gpiNumberLabel.Location = new System.Drawing.Point(77, 38);
            this.gpiNumberLabel.Name = "gpiNumberLabel";
            this.gpiNumberLabel.Size = new System.Drawing.Size(259, 13);
            this.gpiNumberLabel.TabIndex = 18;
            this.gpiNumberLabel.Text = " 1          2          3         4          5          6         7         8";
            // 
            // transmitPowerGB
            // 
            this.transmitPowerGB.Controls.Add(this.label12);
            this.transmitPowerGB.Controls.Add(this.label10);
            this.transmitPowerGB.Controls.Add(this.label11);
            this.transmitPowerGB.Controls.Add(this.hScrollBar1);
            this.transmitPowerGB.Location = new System.Drawing.Point(11, 331);
            this.transmitPowerGB.Name = "transmitPowerGB";
            this.transmitPowerGB.Size = new System.Drawing.Size(347, 53);
            this.transmitPowerGB.TabIndex = 23;
            this.transmitPowerGB.TabStop = false;
            this.transmitPowerGB.Text = "Transmit Power (dbm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "2920";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "1620";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "1620";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 16);
            this.hScrollBar1.Maximum = 2920;
            this.hScrollBar1.Minimum = 1620;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(314, 19);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 1620;
            // 
            // dataContextMenuStrip
            // 
            this.dataContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagDataToolStripMenuItem,
            this.readDataContextMenuItem,
            this.writeDataContextMenuItem,
            this.lockDataContextMenuItem,
            this.killDataContextMenuItem,
            this.blockWriteDataContextMenuItem,
            this.blockEraseDataContextMenuItem});
            this.dataContextMenuStrip.Name = "dataContextMenuStrip";
            this.dataContextMenuStrip.Size = new System.Drawing.Size(140, 158);
            // 
            // tagDataToolStripMenuItem
            // 
            this.tagDataToolStripMenuItem.Name = "tagDataToolStripMenuItem";
            this.tagDataToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.tagDataToolStripMenuItem.Text = "Tag Data";
            this.tagDataToolStripMenuItem.Click += new System.EventHandler(this.tagDataToolStripMenuItem_Click);
            // 
            // readDataContextMenuItem
            // 
            this.readDataContextMenuItem.Name = "readDataContextMenuItem";
            this.readDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.readDataContextMenuItem.Text = "Read";
            this.readDataContextMenuItem.Click += new System.EventHandler(this.readDataContextMenuItem_Click);
            // 
            // writeDataContextMenuItem
            // 
            this.writeDataContextMenuItem.Name = "writeDataContextMenuItem";
            this.writeDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.writeDataContextMenuItem.Text = "Write";
            this.writeDataContextMenuItem.Click += new System.EventHandler(this.writeDataContextMenuItem_Click);
            // 
            // lockDataContextMenuItem
            // 
            this.lockDataContextMenuItem.Name = "lockDataContextMenuItem";
            this.lockDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.lockDataContextMenuItem.Text = "Lock";
            this.lockDataContextMenuItem.Click += new System.EventHandler(this.lockDataContextMenuItem_Click);
            // 
            // killDataContextMenuItem
            // 
            this.killDataContextMenuItem.Name = "killDataContextMenuItem";
            this.killDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.killDataContextMenuItem.Text = "Kill";
            this.killDataContextMenuItem.Click += new System.EventHandler(this.killDataContextMenuItem_Click);
            // 
            // blockWriteDataContextMenuItem
            // 
            this.blockWriteDataContextMenuItem.Name = "blockWriteDataContextMenuItem";
            this.blockWriteDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.blockWriteDataContextMenuItem.Text = "Block Write";
            this.blockWriteDataContextMenuItem.Click += new System.EventHandler(this.blockWriteDataContextMenuItem_Click);
            // 
            // blockEraseDataContextMenuItem
            // 
            this.blockEraseDataContextMenuItem.Name = "blockEraseDataContextMenuItem";
            this.blockEraseDataContextMenuItem.Size = new System.Drawing.Size(139, 22);
            this.blockEraseDataContextMenuItem.Text = "Block Erase";
            this.blockEraseDataContextMenuItem.Click += new System.EventHandler(this.blockEraseDataContextMenuItem_Click);
            // 
            // connectBackgroundWorker
            // 
            this.connectBackgroundWorker.WorkerReportsProgress = true;
            this.connectBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectBackgroundWorker_DoWork);
            this.connectBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.connectBackgroundWorker_RunWorkerCompleted);
            this.connectBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.connectBackgroundWorker_ProgressChanged);
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.accessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.accessBackgroundWorker_RunWorkerCompleted);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.accessBackgroundWorker_ProgressChanged);
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.totalTagValueLabel.Location = new System.Drawing.Point(179, 40);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(100, 16);
            this.totalTagValueLabel.TabIndex = 26;
            this.totalTagValueLabel.Text = "0(0)";
            // 
            // totalTagLabel
            // 
            this.totalTagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.totalTagLabel.Location = new System.Drawing.Point(111, 40);
            this.totalTagLabel.Name = "totalTagLabel";
            this.totalTagLabel.Size = new System.Drawing.Size(62, 16);
            this.totalTagLabel.TabIndex = 25;
            this.totalTagLabel.Text = "Total Tags: ";
            // 
            // clearReports_CB
            // 
            this.clearReports_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearReports_CB.AutoSize = true;
            this.clearReports_CB.Location = new System.Drawing.Point(682, 39);
            this.clearReports_CB.Name = "clearReports_CB";
            this.clearReports_CB.Size = new System.Drawing.Size(90, 17);
            this.clearReports_CB.TabIndex = 27;
            this.clearReports_CB.Text = "Clear Reports";
            this.clearReports_CB.UseVisualStyleBackColor = true;
            this.clearReports_CB.CheckedChanged += new System.EventHandler(this.clearReports_CB_CheckedChanged);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 518);
            this.Controls.Add(this.clearReports_CB);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.inventoryList);
            this.Controls.Add(this.totalTagValueLabel);
            this.Controls.Add(this.totalTagLabel);
            this.Controls.Add(this.readButton);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(8, 250);
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CS_RFID3_Host_Sample1";
            this.Load += new System.EventHandler(this.AppForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.AppForm_ClientSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            this.dataContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label gpiLabel;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capabilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpiStateGB;
        private System.Windows.Forms.Label gpiNumberLabel;
        private System.Windows.Forms.GroupBox transmitPowerGB;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip dataContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tagDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockWriteDataContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockEraseDataContextMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        internal System.ComponentModel.BackgroundWorker connectBackgroundWorker;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        internal System.Windows.Forms.ToolStripStatusLabel functionCallStatusLabel;
        internal System.Windows.Forms.ListView inventoryList;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label totalTagValueLabel;
        private System.Windows.Forms.Label totalTagLabel;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.CheckBox clearReports_CB;
    }
}