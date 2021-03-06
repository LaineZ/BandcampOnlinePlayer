﻿namespace onlineplayer
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkReopen = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.audiosystemBox = new System.Windows.Forms.ComboBox();
            this.saveQueue = new System.Windows.Forms.CheckBox();
            this.pagesLoad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkArtwork = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMeta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelArt = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.albumSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.albumView = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.potReduct = new NAudio.Gui.Pot();
            this.label4 = new System.Windows.Forms.Label();
            this.potThres = new NAudio.Gui.Pot();
            this.checkComp = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssignControll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::onlineplayer.Properties.Resources.baseline_sd_card_black_18dp;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::onlineplayer.Properties.Resources.baseline_loop_black_18dp;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(114, 22);
            this.toolStripButton3.Text = "Reset all settings";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::onlineplayer.Properties.Resources.baseline_remove_black_18dp;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(144, 22);
            this.toolStripButton2.Text = "Remove blocked artist";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = global::onlineplayer.Properties.Resources.baseline_play_arrow_black_18dp;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Play DSP Example";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkReopen);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.audiosystemBox);
            this.tabPage1.Controls.Add(this.saveQueue);
            this.tabPage1.Controls.Add(this.pagesLoad);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.checkArtwork);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.labelMeta);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.labelArt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(389, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkReopen
            // 
            this.checkReopen.AutoSize = true;
            this.checkReopen.Location = new System.Drawing.Point(6, 126);
            this.checkReopen.Name = "checkReopen";
            this.checkReopen.Size = new System.Drawing.Size(284, 17);
            this.checkReopen.TabIndex = 13;
            this.checkReopen.Text = "Re-open audio device before beginning playing (JACK)";
            this.checkReopen.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "REQUIRES RESTART!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Audio system:";
            // 
            // audiosystemBox
            // 
            this.audiosystemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audiosystemBox.FormattingEnabled = true;
            this.audiosystemBox.Items.AddRange(new object[] {
            "WaveOut (Windows ONLY)",
            "Jack+FFmpeg (Windows, Linux) - Requires jack and FFmpeg installed"});
            this.audiosystemBox.Location = new System.Drawing.Point(6, 181);
            this.audiosystemBox.Name = "audiosystemBox";
            this.audiosystemBox.Size = new System.Drawing.Size(375, 21);
            this.audiosystemBox.TabIndex = 10;
            // 
            // saveQueue
            // 
            this.saveQueue.AutoSize = true;
            this.saveQueue.Location = new System.Drawing.Point(6, 103);
            this.saveQueue.Name = "saveQueue";
            this.saveQueue.Size = new System.Drawing.Size(150, 17);
            this.saveQueue.TabIndex = 9;
            this.saveQueue.Text = "Save tracks queue on exit";
            this.saveQueue.UseVisualStyleBackColor = true;
            // 
            // pagesLoad
            // 
            this.pagesLoad.Location = new System.Drawing.Point(224, 62);
            this.pagesLoad.MaxLength = 10;
            this.pagesLoad.Name = "pagesLoad";
            this.pagesLoad.Size = new System.Drawing.Size(48, 20);
            this.pagesLoad.TabIndex = 8;
            this.pagesLoad.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pages to load:";
            // 
            // checkArtwork
            // 
            this.checkArtwork.AutoSize = true;
            this.checkArtwork.Location = new System.Drawing.Point(146, 20);
            this.checkArtwork.Name = "checkArtwork";
            this.checkArtwork.Size = new System.Drawing.Size(134, 17);
            this.checkArtwork.TabIndex = 6;
            this.checkArtwork.Text = "Enable artwork loading";
            this.checkArtwork.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(314, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Contains tags and metadata, cleaning may increase indexing time\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clean";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Metadata cache size:";
            // 
            // labelMeta
            // 
            this.labelMeta.AutoSize = true;
            this.labelMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMeta.Location = new System.Drawing.Point(2, 58);
            this.labelMeta.Name = "labelMeta";
            this.labelMeta.Size = new System.Drawing.Size(57, 24);
            this.labelMeta.TabIndex = 3;
            this.labelMeta.Text = "0 MB";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artwork cache size:";
            // 
            // labelArt
            // 
            this.labelArt.AutoSize = true;
            this.labelArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArt.Location = new System.Drawing.Point(2, 16);
            this.labelArt.Name = "labelArt";
            this.labelArt.Size = new System.Drawing.Size(57, 24);
            this.labelArt.TabIndex = 0;
            this.labelArt.Text = "0 MB";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(2, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(397, 290);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.albumSize);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.albumView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(389, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Apperance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(193, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Restart or redrawing list required!";
            // 
            // albumSize
            // 
            this.albumSize.Location = new System.Drawing.Point(144, 20);
            this.albumSize.Name = "albumSize";
            this.albumSize.Size = new System.Drawing.Size(47, 20);
            this.albumSize.TabIndex = 3;
            this.albumSize.Text = "64";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Album view image size (max 124):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Default albums view type:";
            // 
            // albumView
            // 
            this.albumView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.albumView.FormattingEnabled = true;
            this.albumView.Items.AddRange(new object[] {
            "Tile",
            "Large Images",
            "Details"});
            this.albumView.Location = new System.Drawing.Point(10, 19);
            this.albumView.Name = "albumView";
            this.albumView.Size = new System.Drawing.Size(121, 21);
            this.albumView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(389, 264);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Blocked artists";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(375, 251);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.linkLabel1);
            this.tabPage5.Controls.Add(this.labelVersion);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.richTextBox1);
            this.tabPage5.Controls.Add(this.pictureBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(389, 264);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(162, 65);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(87, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub webpage";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(162, 26);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(185, 52);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version: 0.6-alpha by 140bpmdubstep\r\nLicensed under MIT License\r\n2019-2020\r\n\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(161, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "BandcampOnlinePlayer";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(6, 109);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(375, 152);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::onlineplayer.Properties.Resources.splash_screen;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.labelInfo);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.potReduct);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.potThres);
            this.tabPage6.Controls.Add(this.checkComp);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(389, 264);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "DSP Effects";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(6, 26);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 13);
            this.labelInfo.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Reduction";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // potReduct
            // 
            this.potReduct.Enabled = false;
            this.potReduct.Location = new System.Drawing.Point(183, 7);
            this.potReduct.Maximum = 12D;
            this.potReduct.Minimum = -24D;
            this.potReduct.Name = "potReduct";
            this.potReduct.Size = new System.Drawing.Size(32, 32);
            this.potReduct.TabIndex = 5;
            this.potReduct.Value = -10D;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Threshold";
            // 
            // potThres
            // 
            this.potThres.Enabled = false;
            this.potThres.Location = new System.Drawing.Point(123, 6);
            this.potThres.Maximum = 20D;
            this.potThres.Minimum = -50D;
            this.potThres.Name = "potThres";
            this.potThres.Size = new System.Drawing.Size(32, 32);
            this.potThres.TabIndex = 3;
            this.potThres.Value = 0D;
            // 
            // checkComp
            // 
            this.checkComp.AutoSize = true;
            this.checkComp.Location = new System.Drawing.Point(6, 6);
            this.checkComp.Name = "checkComp";
            this.checkComp.Size = new System.Drawing.Size(81, 17);
            this.checkComp.TabIndex = 0;
            this.checkComp.Text = "Compressor";
            this.checkComp.UseVisualStyleBackColor = true;
            this.checkComp.CheckedChanged += new System.EventHandler(this.checkComp_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Action
            // 
            this.Action.DisplayIndex = 0;
            this.Action.Text = "Action";
            this.Action.Width = 125;
            // 
            // AssignControll
            // 
            this.AssignControll.DisplayIndex = 1;
            this.AssignControll.Text = "Assiggn control";
            this.AssignControll.Width = 193;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(399, 318);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox pagesLoad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkArtwork;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMeta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelArt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox albumSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox albumView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.CheckBox saveQueue;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox audiosystemBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkReopen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox checkComp;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.ColumnHeader AssignControll;
        private System.Windows.Forms.Label label12;
        private NAudio.Gui.Pot potReduct;
        private System.Windows.Forms.Label label4;
        private NAudio.Gui.Pot potThres;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}