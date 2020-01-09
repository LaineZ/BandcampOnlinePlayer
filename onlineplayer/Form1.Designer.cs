namespace onlineplayer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelTrackName = new System.Windows.Forms.Label();
            this.labelTrackInfo = new System.Windows.Forms.Label();
            this.trackSeek = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolSort = new System.Windows.Forms.ToolStripButton();
            this.toolSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSavePlaylist = new System.Windows.Forms.ToolStripButton();
            this.openPlaylist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMidiOpen = new System.Windows.Forms.ToolStripButton();
            this.toolMidiClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrev = new System.Windows.Forms.ToolStripButton();
            this.toolPlay = new System.Windows.Forms.ToolStripButton();
            this.toolNext = new System.Windows.Forms.ToolStripButton();
            this.toolStream = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBlock = new System.Windows.Forms.ToolStripButton();
            this.toolShuffle = new System.Windows.Forms.ToolStripButton();
            this.toolClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolSearch = new System.Windows.Forms.ToolStripTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAlbumWebpageInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockSelectedArtiststreamingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureArtwork = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listAlbums = new System.Windows.Forms.ListView();
            this.listTags = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.queueList = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listGlobalSearch = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.trackSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTrackName
            // 
            this.labelTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTrackName.AutoSize = true;
            this.labelTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTrackName.Location = new System.Drawing.Point(662, 250);
            this.labelTrackName.Name = "labelTrackName";
            this.labelTrackName.Size = new System.Drawing.Size(37, 13);
            this.labelTrackName.TabIndex = 2;
            this.labelTrackName.Text = "None";
            // 
            // labelTrackInfo
            // 
            this.labelTrackInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTrackInfo.AutoSize = true;
            this.labelTrackInfo.Location = new System.Drawing.Point(662, 263);
            this.labelTrackInfo.Name = "labelTrackInfo";
            this.labelTrackInfo.Size = new System.Drawing.Size(33, 13);
            this.labelTrackInfo.TabIndex = 3;
            this.labelTrackInfo.Text = "None";
            // 
            // trackSeek
            // 
            this.trackSeek.AllowDrop = true;
            this.trackSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackSeek.Location = new System.Drawing.Point(0, 470);
            this.trackSeek.Maximum = 0;
            this.trackSeek.Name = "trackSeek";
            this.trackSeek.Size = new System.Drawing.Size(761, 45);
            this.trackSeek.TabIndex = 7;
            this.trackSeek.TickFrequency = 0;
            this.trackSeek.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackSeek.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "00:00:00";
            // 
            // trackVolume
            // 
            this.trackVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVolume.Location = new System.Drawing.Point(756, 470);
            this.trackVolume.Maximum = 100;
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(151, 45);
            this.trackVolume.TabIndex = 9;
            this.trackVolume.TickFrequency = 5;
            this.trackVolume.Value = 100;
            this.trackVolume.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(676, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Volume: 100%";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRefresh,
            this.toolSort,
            this.toolSettings,
            this.toolStripSeparator3,
            this.toolSavePlaylist,
            this.openPlaylist,
            this.toolStripSeparator4,
            this.toolMidiOpen,
            this.toolMidiClose,
            this.toolStripSeparator2,
            this.toolPrev,
            this.toolPlay,
            this.toolNext,
            this.toolStream,
            this.toolStripSeparator1,
            this.toolBlock,
            this.toolShuffle,
            this.toolClearAll,
            this.toolSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(907, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolRefresh
            // 
            this.toolRefresh.Enabled = false;
            this.toolRefresh.Image = global::onlineplayer.Properties.Resources.baseline_loop_black_18dp;
            this.toolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRefresh.Name = "toolRefresh";
            this.toolRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolRefresh.Text = "Refresh";
            this.toolRefresh.ToolTipText = "Refresh albums";
            this.toolRefresh.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolSort
            // 
            this.toolSort.Checked = true;
            this.toolSort.CheckOnClick = true;
            this.toolSort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolSort.Image = global::onlineplayer.Properties.Resources.ic_search_18pt;
            this.toolSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSort.Name = "toolSort";
            this.toolSort.Size = new System.Drawing.Size(65, 22);
            this.toolSort.Text = "Sorting";
            this.toolSort.ToolTipText = "Sorting:\r\nEnabled - sort by popularity. \r\nDisabled: sort by newest";
            this.toolSort.Click += new System.EventHandler(this.toolSort_Click);
            // 
            // toolSettings
            // 
            this.toolSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSettings.Image = global::onlineplayer.Properties.Resources.ic_settings_18pt;
            this.toolSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSettings.Name = "toolSettings";
            this.toolSettings.Size = new System.Drawing.Size(23, 22);
            this.toolSettings.Text = "Settings";
            this.toolSettings.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSavePlaylist
            // 
            this.toolSavePlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSavePlaylist.Image = global::onlineplayer.Properties.Resources.ic_album_black_18dp;
            this.toolSavePlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSavePlaylist.Name = "toolSavePlaylist";
            this.toolSavePlaylist.Size = new System.Drawing.Size(23, 22);
            this.toolSavePlaylist.Text = "Save playlist";
            this.toolSavePlaylist.Click += new System.EventHandler(this.toolSavePlaylist_Click);
            // 
            // openPlaylist
            // 
            this.openPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openPlaylist.Image = global::onlineplayer.Properties.Resources.ic_open_in_browser_18pt;
            this.openPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openPlaylist.Name = "openPlaylist";
            this.openPlaylist.Size = new System.Drawing.Size(23, 22);
            this.openPlaylist.Text = "Open playlist";
            this.openPlaylist.Click += new System.EventHandler(this.openPlaylist_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolMidiOpen
            // 
            this.toolMidiOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMidiOpen.Image = global::onlineplayer.Properties.Resources.ic_add_18pt;
            this.toolMidiOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMidiOpen.Name = "toolMidiOpen";
            this.toolMidiOpen.Size = new System.Drawing.Size(23, 22);
            this.toolMidiOpen.Text = "Open MIDI";
            this.toolMidiOpen.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolMidiClose
            // 
            this.toolMidiClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMidiClose.Image = global::onlineplayer.Properties.Resources.baseline_remove_black_18dp;
            this.toolMidiClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMidiClose.Name = "toolMidiClose";
            this.toolMidiClose.Size = new System.Drawing.Size(23, 22);
            this.toolMidiClose.Text = "Close MIDI";
            this.toolMidiClose.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPrev
            // 
            this.toolPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrev.Image = global::onlineplayer.Properties.Resources.baseline_skip_previous_black_18dp;
            this.toolPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrev.Name = "toolPrev";
            this.toolPrev.Size = new System.Drawing.Size(23, 22);
            this.toolPrev.Text = "Prev";
            this.toolPrev.ToolTipText = "Prev";
            this.toolPrev.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolPlay
            // 
            this.toolPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPlay.Image = global::onlineplayer.Properties.Resources.baseline_play_arrow_black_18dp;
            this.toolPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPlay.Name = "toolPlay";
            this.toolPlay.Size = new System.Drawing.Size(23, 22);
            this.toolPlay.Text = "Play/Pause";
            this.toolPlay.ToolTipText = "Play/Pause";
            this.toolPlay.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolNext
            // 
            this.toolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNext.Image = global::onlineplayer.Properties.Resources.ic_skip_next_black_18dp;
            this.toolNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNext.Name = "toolNext";
            this.toolNext.Size = new System.Drawing.Size(23, 22);
            this.toolNext.Text = "Next";
            this.toolNext.ToolTipText = "Next";
            this.toolNext.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStream
            // 
            this.toolStream.Image = global::onlineplayer.Properties.Resources.baseline_play_arrow_black_18dp;
            this.toolStream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStream.Name = "toolStream";
            this.toolStream.Size = new System.Drawing.Size(136, 22);
            this.toolStream.Text = "Play as stream mode";
            this.toolStream.ToolTipText = "Play as stream mode - automatically builds a playlist";
            this.toolStream.Click += new System.EventHandler(this.toolStripButton5_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBlock
            // 
            this.toolBlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBlock.Image = global::onlineplayer.Properties.Resources.baseline_not_interested_black_18dp;
            this.toolBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBlock.Name = "toolBlock";
            this.toolBlock.Size = new System.Drawing.Size(23, 22);
            this.toolBlock.Text = "toolStripButton7";
            this.toolBlock.ToolTipText = "Block selected artist (Not interested)";
            this.toolBlock.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolShuffle
            // 
            this.toolShuffle.CheckOnClick = true;
            this.toolShuffle.Image = global::onlineplayer.Properties.Resources.baseline_shuffle_black_18dp;
            this.toolShuffle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShuffle.Name = "toolShuffle";
            this.toolShuffle.Size = new System.Drawing.Size(23, 22);
            this.toolShuffle.ToolTipText = "Shuffle";
            this.toolShuffle.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolClearAll
            // 
            this.toolClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClearAll.Image = global::onlineplayer.Properties.Resources.ic_clear_black_18dp;
            this.toolClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClearAll.Name = "toolClearAll";
            this.toolClearAll.Size = new System.Drawing.Size(23, 22);
            this.toolClearAll.Text = "toolStripButton9";
            this.toolClearAll.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolSearch
            // 
            this.toolSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(200, 25);
            this.toolSearch.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem,
            this.openInBrowserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(278, 70);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Image = global::onlineplayer.Properties.Resources.baseline_play_arrow_black_18dp;
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // addAlbumTracksInQueueifAvailbleToolStripMenuItem
            // 
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem.Name = "addAlbumTracksInQueueifAvailbleToolStripMenuItem";
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem.Text = "Add album tracks in queue (if availble)";
            this.addAlbumTracksInQueueifAvailbleToolStripMenuItem.Click += new System.EventHandler(this.addAlbumTracksInQueueifAvailbleToolStripMenuItem_Click);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.openInBrowserToolStripMenuItem.Text = "Open album page in browser";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(67, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Stopped";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem1,
            this.removeFromQueueToolStripMenuItem,
            this.openAlbumWebpageInBrowserToolStripMenuItem,
            this.blockSelectedArtiststreamingModeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(277, 92);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Image = global::onlineplayer.Properties.Resources.baseline_play_arrow_black_18dp;
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(276, 22);
            this.playToolStripMenuItem1.Text = "Play";
            // 
            // removeFromQueueToolStripMenuItem
            // 
            this.removeFromQueueToolStripMenuItem.Image = global::onlineplayer.Properties.Resources.baseline_remove_black_18dp;
            this.removeFromQueueToolStripMenuItem.Name = "removeFromQueueToolStripMenuItem";
            this.removeFromQueueToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.removeFromQueueToolStripMenuItem.Text = "Remove from queue";
            this.removeFromQueueToolStripMenuItem.Click += new System.EventHandler(this.removeFromQueueToolStripMenuItem_Click);
            // 
            // openAlbumWebpageInBrowserToolStripMenuItem
            // 
            this.openAlbumWebpageInBrowserToolStripMenuItem.Name = "openAlbumWebpageInBrowserToolStripMenuItem";
            this.openAlbumWebpageInBrowserToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.openAlbumWebpageInBrowserToolStripMenuItem.Text = "Open album webpage in browser";
            // 
            // blockSelectedArtiststreamingModeToolStripMenuItem
            // 
            this.blockSelectedArtiststreamingModeToolStripMenuItem.Image = global::onlineplayer.Properties.Resources.baseline_not_interested_black_18dp;
            this.blockSelectedArtiststreamingModeToolStripMenuItem.Name = "blockSelectedArtiststreamingModeToolStripMenuItem";
            this.blockSelectedArtiststreamingModeToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.blockSelectedArtiststreamingModeToolStripMenuItem.Text = "Block selected artist (streaming mode)";
            this.blockSelectedArtiststreamingModeToolStripMenuItem.Click += new System.EventHandler(this.blockSelectedArtiststreamingModeToolStripMenuItem_Click);
            // 
            // pictureArtwork
            // 
            this.pictureArtwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureArtwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureArtwork.Location = new System.Drawing.Point(665, 31);
            this.pictureArtwork.Name = "pictureArtwork";
            this.pictureArtwork.Size = new System.Drawing.Size(230, 216);
            this.pictureArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureArtwork.TabIndex = 1;
            this.pictureArtwork.TabStop = false;
            this.pictureArtwork.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(127, 493);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(33, 13);
            this.labelStatus.TabIndex = 13;
            this.labelStatus.Text = "Done";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(659, 445);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listTags);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tags";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Albums & Play queue";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listAlbums
            // 
            this.listAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAlbums.HideSelection = false;
            this.listAlbums.Location = new System.Drawing.Point(3, 3);
            this.listAlbums.MultiSelect = false;
            this.listAlbums.Name = "listAlbums";
            this.listAlbums.Size = new System.Drawing.Size(365, 410);
            this.listAlbums.TabIndex = 5;
            this.listAlbums.UseCompatibleStateImageBehavior = false;
            this.listAlbums.View = System.Windows.Forms.View.Tile;
            // 
            // listTags
            // 
            this.listTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listTags.FormattingEnabled = true;
            this.listTags.Location = new System.Drawing.Point(0, 0);
            this.listTags.Name = "listTags";
            this.listTags.Size = new System.Drawing.Size(651, 420);
            this.listTags.TabIndex = 0;
            this.listTags.DoubleClick += new System.EventHandler(this.listBox1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.listAlbums, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.queueList, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 416);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // queueList
            // 
            this.queueList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queueList.HideSelection = false;
            this.queueList.Location = new System.Drawing.Point(374, 3);
            this.queueList.MultiSelect = false;
            this.queueList.Name = "queueList";
            this.queueList.Size = new System.Drawing.Size(274, 410);
            this.queueList.TabIndex = 6;
            this.queueList.UseCompatibleStateImageBehavior = false;
            this.queueList.View = System.Windows.Forms.View.Tile;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listGlobalSearch);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(651, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Global search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(651, 24);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listGlobalSearch
            // 
            this.listGlobalSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGlobalSearch.HideSelection = false;
            this.listGlobalSearch.Location = new System.Drawing.Point(0, 26);
            this.listGlobalSearch.Name = "listGlobalSearch";
            this.listGlobalSearch.Size = new System.Drawing.Size(651, 393);
            this.listGlobalSearch.TabIndex = 1;
            this.listGlobalSearch.TileSize = new System.Drawing.Size(256, 64);
            this.listGlobalSearch.UseCompatibleStateImageBehavior = false;
            this.listGlobalSearch.View = System.Windows.Forms.View.Tile;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTrackInfo);
            this.Controls.Add(this.labelTrackName);
            this.Controls.Add(this.pictureArtwork);
            this.Controls.Add(this.trackSeek);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bandcamp online player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureArtwork;
        private System.Windows.Forms.Label labelTrackName;
        private System.Windows.Forms.Label labelTrackInfo;
        private System.Windows.Forms.TrackBar trackSeek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolPrev;
        private System.Windows.Forms.ToolStripButton toolPlay;
        private System.Windows.Forms.ToolStripButton toolNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAlbumTracksInQueueifAvailbleToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeFromQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAlbumWebpageInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStream;
        private System.Windows.Forms.ToolStripButton toolSettings;
        private System.Windows.Forms.ToolStripButton toolBlock;
        private System.Windows.Forms.ToolStripButton toolShuffle;
        private System.Windows.Forms.ToolStripMenuItem blockSelectedArtiststreamingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolClearAll;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripButton toolMidiClose;
        private System.Windows.Forms.ToolStripButton toolMidiOpen;
        private System.Windows.Forms.ToolStripTextBox toolSearch;
        private System.Windows.Forms.ToolStripButton toolSort;
        private System.Windows.Forms.ToolStripButton toolSavePlaylist;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton openPlaylist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listAlbums;
        private System.Windows.Forms.ListBox listTags;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView queueList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listGlobalSearch;
        private System.Windows.Forms.TextBox textBox1;
    }
}

