namespace Que.Server
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewQueue = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListNumbers = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelTrackAlbum = new System.Windows.Forms.Label();
            this.labelTrackArtist = new System.Windows.Forms.Label();
            this.labelTrackName = new System.Windows.Forms.Label();
            this.pictureBoxTrackAlbumCover = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarPlayed = new ProgressODoom.ProgressBarEx();
            this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
            this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
            this.javaProgressPainter1 = new ProgressODoom.JavaProgressPainter();
            this.labelTimeRemaining = new System.Windows.Forms.Label();
            this.labelTimeElapsed = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelSimpleSearch = new System.Windows.Forms.Panel();
            this.loadingCircleSearchFull = new MRG.Controls.UI.LoadingCircle();
            this.textBoxSearchFull = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFullSearch = new System.Windows.Forms.Panel();
            this.tableLayoutPanelFullSearch = new System.Windows.Forms.TableLayoutPanel();
            this.listViewSearchResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.loadingCircleSearch = new MRG.Controls.UI.LoadingCircle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelDidYouMean = new System.Windows.Forms.LinkLabel();
            this.labelSearchResults = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrackAlbumCover)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelSimpleSearch.SuspendLayout();
            this.panelFullSearch.SuspendLayout();
            this.tableLayoutPanelFullSearch.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.86562F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.13438F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSearch, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1259, 710);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.listViewQueue, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(684, 726);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listViewQueue
            // 
            this.listViewQueue.AllowDrop = true;
            this.listViewQueue.BackColor = System.Drawing.Color.Gray;
            this.listViewQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewQueue.Font = new System.Drawing.Font("Segoe WP SemiLight", 10F);
            this.listViewQueue.ForeColor = System.Drawing.Color.White;
            this.listViewQueue.LargeImageList = this.imageListNumbers;
            this.listViewQueue.Location = new System.Drawing.Point(0, 295);
            this.listViewQueue.Margin = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.listViewQueue.Name = "listViewQueue";
            this.listViewQueue.Size = new System.Drawing.Size(684, 406);
            this.listViewQueue.SmallImageList = this.imageListNumbers;
            this.listViewQueue.TabIndex = 3;
            this.listViewQueue.UseCompatibleStateImageBehavior = false;
            this.listViewQueue.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewQueue_ItemDrag);
            this.listViewQueue.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewQueue_DragDrop);
            this.listViewQueue.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewQueue_DragEnter);
            this.listViewQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewQueue_KeyUp);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Title";
            this.columnHeader4.Width = 154;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Artist";
            this.columnHeader5.Width = 188;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Album";
            this.columnHeader6.Width = 160;
            // 
            // imageListNumbers
            // 
            this.imageListNumbers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNumbers.ImageStream")));
            this.imageListNumbers.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListNumbers.Images.SetKeyName(0, "glass_numbers_0.png");
            this.imageListNumbers.Images.SetKeyName(1, "glass_numbers_1.png");
            this.imageListNumbers.Images.SetKeyName(2, "glass_numbers_2.png");
            this.imageListNumbers.Images.SetKeyName(3, "glass_numbers_3.png");
            this.imageListNumbers.Images.SetKeyName(4, "glass_numbers_4.png");
            this.imageListNumbers.Images.SetKeyName(5, "glass_numbers_5.png");
            this.imageListNumbers.Images.SetKeyName(6, "glass_numbers_6.png");
            this.imageListNumbers.Images.SetKeyName(7, "glass_numbers_7.png");
            this.imageListNumbers.Images.SetKeyName(8, "glass_numbers_8.png");
            this.imageListNumbers.Images.SetKeyName(9, "glass_numbers_9.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonPlay);
            this.panel1.Controls.Add(this.labelTrackAlbum);
            this.panel1.Controls.Add(this.labelTrackArtist);
            this.panel1.Controls.Add(this.labelTrackName);
            this.panel1.Controls.Add(this.pictureBoxTrackAlbumCover);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MinimumSize = new System.Drawing.Size(659, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 247);
            this.panel1.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = global::Que.Server.Properties.Resources._1313182712_button_black_last;
            this.buttonNext.Location = new System.Drawing.Point(314, 173);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(71, 70);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = global::Que.Server.Properties.Resources._1313182641_button_black_play;
            this.buttonPlay.Location = new System.Drawing.Point(240, 173);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(66, 70);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelTrackAlbum
            // 
            this.labelTrackAlbum.AutoSize = true;
            this.labelTrackAlbum.Font = new System.Drawing.Font("Segoe WP SemiLight", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrackAlbum.ForeColor = System.Drawing.Color.White;
            this.labelTrackAlbum.Location = new System.Drawing.Point(252, 119);
            this.labelTrackAlbum.Name = "labelTrackAlbum";
            this.labelTrackAlbum.Size = new System.Drawing.Size(0, 22);
            this.labelTrackAlbum.TabIndex = 3;
            // 
            // labelTrackArtist
            // 
            this.labelTrackArtist.AutoSize = true;
            this.labelTrackArtist.Font = new System.Drawing.Font("Segoe WP SemiLight", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrackArtist.ForeColor = System.Drawing.Color.White;
            this.labelTrackArtist.Location = new System.Drawing.Point(253, 77);
            this.labelTrackArtist.Name = "labelTrackArtist";
            this.labelTrackArtist.Size = new System.Drawing.Size(0, 22);
            this.labelTrackArtist.TabIndex = 2;
            // 
            // labelTrackName
            // 
            this.labelTrackName.AutoSize = true;
            this.labelTrackName.Font = new System.Drawing.Font("Segoe WP SemiLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrackName.ForeColor = System.Drawing.Color.White;
            this.labelTrackName.Location = new System.Drawing.Point(252, 29);
            this.labelTrackName.Name = "labelTrackName";
            this.labelTrackName.Size = new System.Drawing.Size(172, 28);
            this.labelTrackName.TabIndex = 1;
            this.labelTrackName.Text = "No track selected";
            // 
            // pictureBoxTrackAlbumCover
            // 
            this.pictureBoxTrackAlbumCover.Image = global::Que.Server.Properties.Resources.unknown_album_cover;
            this.pictureBoxTrackAlbumCover.Location = new System.Drawing.Point(12, 7);
            this.pictureBoxTrackAlbumCover.Name = "pictureBoxTrackAlbumCover";
            this.pictureBoxTrackAlbumCover.Size = new System.Drawing.Size(222, 234);
            this.pictureBoxTrackAlbumCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTrackAlbumCover.TabIndex = 0;
            this.pictureBoxTrackAlbumCover.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 247);
            this.panel2.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(671, 30);
            this.panel2.MinimumSize = new System.Drawing.Size(671, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 30);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel4.Controls.Add(this.progressBarPlayed, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelTimeRemaining, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelTimeElapsed, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(671, 30);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // progressBarPlayed
            // 
            this.progressBarPlayed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarPlayed.BackgroundPainter = this.plainBackgroundPainter1;
            this.progressBarPlayed.BorderPainter = this.plainBorderPainter1;
            this.progressBarPlayed.Location = new System.Drawing.Point(52, 4);
            this.progressBarPlayed.Margin = new System.Windows.Forms.Padding(0);
            this.progressBarPlayed.MarqueePercentage = 25;
            this.progressBarPlayed.MarqueeSpeed = 30;
            this.progressBarPlayed.MarqueeStep = 1;
            this.progressBarPlayed.Maximum = 100;
            this.progressBarPlayed.Minimum = 0;
            this.progressBarPlayed.Name = "progressBarPlayed";
            this.progressBarPlayed.ProgressPadding = 0;
            this.progressBarPlayed.ProgressPainter = this.javaProgressPainter1;
            this.progressBarPlayed.ProgressType = ProgressODoom.ProgressType.Smooth;
            this.progressBarPlayed.ShowPercentage = false;
            this.progressBarPlayed.Size = new System.Drawing.Size(560, 22);
            this.progressBarPlayed.TabIndex = 5;
            this.progressBarPlayed.Value = 0;
            this.progressBarPlayed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.progressBarPlayed_MouseUp);
            // 
            // plainBackgroundPainter1
            // 
            this.plainBackgroundPainter1.Color = System.Drawing.Color.Transparent;
            this.plainBackgroundPainter1.GlossPainter = null;
            // 
            // plainBorderPainter1
            // 
            this.plainBorderPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.plainBorderPainter1.RoundedCorners = false;
            this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
            // 
            // javaProgressPainter1
            // 
            this.javaProgressPainter1.Color = System.Drawing.Color.SkyBlue;
            this.javaProgressPainter1.GlossPainter = null;
            this.javaProgressPainter1.ProgressBorderPainter = null;
            // 
            // labelTimeRemaining
            // 
            this.labelTimeRemaining.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTimeRemaining.AutoSize = true;
            this.labelTimeRemaining.Font = new System.Drawing.Font("Segoe WP SemiLight", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeRemaining.ForeColor = System.Drawing.Color.White;
            this.labelTimeRemaining.Location = new System.Drawing.Point(668, 7);
            this.labelTimeRemaining.Name = "labelTimeRemaining";
            this.labelTimeRemaining.Size = new System.Drawing.Size(0, 15);
            this.labelTimeRemaining.TabIndex = 2;
            this.labelTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimeElapsed
            // 
            this.labelTimeElapsed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeElapsed.AutoSize = true;
            this.labelTimeElapsed.Font = new System.Drawing.Font("Segoe WP SemiLight", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeElapsed.ForeColor = System.Drawing.Color.White;
            this.labelTimeElapsed.Location = new System.Drawing.Point(3, 7);
            this.labelTimeElapsed.Name = "labelTimeElapsed";
            this.labelTimeElapsed.Size = new System.Drawing.Size(0, 15);
            this.labelTimeElapsed.TabIndex = 1;
            this.labelTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.panelSimpleSearch);
            this.panelSearch.Controls.Add(this.panelFullSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.panelSearch.Location = new System.Drawing.Point(693, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(563, 726);
            this.panelSearch.TabIndex = 1;
            // 
            // panelSimpleSearch
            // 
            this.panelSimpleSearch.Controls.Add(this.loadingCircleSearchFull);
            this.panelSimpleSearch.Controls.Add(this.textBoxSearchFull);
            this.panelSimpleSearch.Controls.Add(this.label1);
            this.panelSimpleSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSimpleSearch.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.panelSimpleSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSimpleSearch.Name = "panelSimpleSearch";
            this.panelSimpleSearch.Size = new System.Drawing.Size(563, 726);
            this.panelSimpleSearch.TabIndex = 1;
            // 
            // loadingCircleSearchFull
            // 
            this.loadingCircleSearchFull.Active = true;
            this.loadingCircleSearchFull.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleSearchFull.InnerCircleRadius = 8;
            this.loadingCircleSearchFull.Location = new System.Drawing.Point(483, 286);
            this.loadingCircleSearchFull.Name = "loadingCircleSearchFull";
            this.loadingCircleSearchFull.NumberSpoke = 24;
            this.loadingCircleSearchFull.OuterCircleRadius = 9;
            this.loadingCircleSearchFull.RotationSpeed = 100;
            this.loadingCircleSearchFull.Size = new System.Drawing.Size(35, 29);
            this.loadingCircleSearchFull.SpokeThickness = 4;
            this.loadingCircleSearchFull.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircleSearchFull.TabIndex = 3;
            this.loadingCircleSearchFull.Text = "loadingCircle1";
            this.loadingCircleSearchFull.Visible = false;
            // 
            // textBoxSearchFull
            // 
            this.textBoxSearchFull.BackColor = System.Drawing.Color.LightGray;
            this.textBoxSearchFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchFull.Font = new System.Drawing.Font("Segoe WP SemiLight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchFull.Location = new System.Drawing.Point(117, 275);
            this.textBoxSearchFull.Name = "textBoxSearchFull";
            this.textBoxSearchFull.Size = new System.Drawing.Size(359, 39);
            this.textBoxSearchFull.TabIndex = 1;
            this.textBoxSearchFull.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSearchFull.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe WP SemiLight", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(215, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search...";
            // 
            // panelFullSearch
            // 
            this.panelFullSearch.Controls.Add(this.tableLayoutPanelFullSearch);
            this.panelFullSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFullSearch.Location = new System.Drawing.Point(0, 0);
            this.panelFullSearch.Name = "panelFullSearch";
            this.panelFullSearch.Size = new System.Drawing.Size(563, 726);
            this.panelFullSearch.TabIndex = 0;
            this.panelFullSearch.Visible = false;
            // 
            // tableLayoutPanelFullSearch
            // 
            this.tableLayoutPanelFullSearch.ColumnCount = 1;
            this.tableLayoutPanelFullSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFullSearch.Controls.Add(this.listViewSearchResults, 0, 1);
            this.tableLayoutPanelFullSearch.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanelFullSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFullSearch.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelFullSearch.Name = "tableLayoutPanelFullSearch";
            this.tableLayoutPanelFullSearch.RowCount = 2;
            this.tableLayoutPanelFullSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanelFullSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFullSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelFullSearch.Size = new System.Drawing.Size(563, 726);
            this.tableLayoutPanelFullSearch.TabIndex = 3;
            // 
            // listViewSearchResults
            // 
            this.listViewSearchResults.AllowDrop = true;
            this.listViewSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchResults.FullRowSelect = true;
            this.listViewSearchResults.Location = new System.Drawing.Point(0, 62);
            this.listViewSearchResults.Margin = new System.Windows.Forms.Padding(0);
            this.listViewSearchResults.Name = "listViewSearchResults";
            this.listViewSearchResults.Size = new System.Drawing.Size(563, 676);
            this.listViewSearchResults.TabIndex = 1;
            this.listViewSearchResults.UseCompatibleStateImageBehavior = false;
            this.listViewSearchResults.View = System.Windows.Forms.View.Details;
            this.listViewSearchResults.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewSearchResults_ItemDrag);
            this.listViewSearchResults.DoubleClick += new System.EventHandler(this.listViewSearchResults_DoubleClick);
            this.listViewSearchResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewSearchResults_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 187;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artist";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Album";
            this.columnHeader3.Width = 121;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxSearch, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(563, 62);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe WP SemiLight", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(528, 27);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonClear);
            this.panel3.Controls.Add(this.loadingCircleSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(531, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 31);
            this.panel3.TabIndex = 6;
            // 
            // buttonClear
            // 
            this.buttonClear.AutoSize = true;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Image = global::Que.Server.Properties.Resources._1313272364_delete;
            this.buttonClear.Location = new System.Drawing.Point(1, -3);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(27, 29);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // loadingCircleSearch
            // 
            this.loadingCircleSearch.Active = true;
            this.loadingCircleSearch.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleSearch.InnerCircleRadius = 8;
            this.loadingCircleSearch.Location = new System.Drawing.Point(0, 0);
            this.loadingCircleSearch.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.loadingCircleSearch.Name = "loadingCircleSearch";
            this.loadingCircleSearch.NumberSpoke = 24;
            this.loadingCircleSearch.OuterCircleRadius = 9;
            this.loadingCircleSearch.RotationSpeed = 100;
            this.loadingCircleSearch.Size = new System.Drawing.Size(28, 33);
            this.loadingCircleSearch.SpokeThickness = 4;
            this.loadingCircleSearch.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircleSearch.TabIndex = 4;
            this.loadingCircleSearch.Text = "loadingCircle1";
            this.loadingCircleSearch.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.linkLabelDidYouMean);
            this.flowLayoutPanel1.Controls.Add(this.labelSearchResults);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 25);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // linkLabelDidYouMean
            // 
            this.linkLabelDidYouMean.AutoSize = true;
            this.linkLabelDidYouMean.LinkColor = System.Drawing.Color.White;
            this.linkLabelDidYouMean.Location = new System.Drawing.Point(3, 0);
            this.linkLabelDidYouMean.Name = "linkLabelDidYouMean";
            this.linkLabelDidYouMean.Size = new System.Drawing.Size(111, 19);
            this.linkLabelDidYouMean.TabIndex = 1;
            this.linkLabelDidYouMean.TabStop = true;
            this.linkLabelDidYouMean.Text = "Did you mean \'\'?";
            this.linkLabelDidYouMean.Visible = false;
            this.linkLabelDidYouMean.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabelDidYouMean.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDidYouMean_LinkClicked);
            // 
            // labelSearchResults
            // 
            this.labelSearchResults.AutoSize = true;
            this.labelSearchResults.ForeColor = System.Drawing.Color.LightGray;
            this.labelSearchResults.Location = new System.Drawing.Point(120, 0);
            this.labelSearchResults.Name = "labelSearchResults";
            this.labelSearchResults.Size = new System.Drawing.Size(0, 19);
            this.labelSearchResults.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1259, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(1259, 734);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe WP SemiLight", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Q Jukebox Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrackAlbumCover)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSimpleSearch.ResumeLayout(false);
            this.panelSimpleSearch.PerformLayout();
            this.panelFullSearch.ResumeLayout(false);
            this.tableLayoutPanelFullSearch.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelSimpleSearch;
        private System.Windows.Forms.TextBox textBoxSearchFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFullSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFullSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ListView listViewSearchResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageListNumbers;
        private MRG.Controls.UI.LoadingCircle loadingCircleSearchFull;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MRG.Controls.UI.LoadingCircle loadingCircleSearch;
        private ProgressODoom.PlainBorderPainter plainBorderPainter1;
        private ProgressODoom.JavaProgressPainter javaProgressPainter1;
        private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listViewQueue;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ProgressODoom.ProgressBarEx progressBarPlayed;
        private System.Windows.Forms.Label labelTimeRemaining;
        private System.Windows.Forms.Label labelTimeElapsed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelTrackAlbum;
        private System.Windows.Forms.Label labelTrackArtist;
        private System.Windows.Forms.Label labelTrackName;
        private System.Windows.Forms.PictureBox pictureBoxTrackAlbumCover;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelDidYouMean;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelSearchResults;
    }
}

