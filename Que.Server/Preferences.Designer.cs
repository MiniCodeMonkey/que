namespace Que.Server
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxProtectWithPassword = new System.Windows.Forms.CheckBox();
            this.groupBoxPasswordProtection = new System.Windows.Forms.GroupBox();
            this.labelReenterSettingsPassword = new System.Windows.Forms.Label();
            this.textBoxReenterPassword = new System.Windows.Forms.TextBox();
            this.labelEnterSettingsPassword = new System.Windows.Forms.Label();
            this.textBoxEnterSettingsPassword = new System.Windows.Forms.TextBox();
            this.groupBoxQueSize = new System.Windows.Forms.GroupBox();
            this.labelUnitQueueSize = new System.Windows.Forms.Label();
            this.labelQueueSize = new System.Windows.Forms.Label();
            this.numericUpDownQueueSize = new System.Windows.Forms.NumericUpDown();
            this.tabPagePlaylistManager = new System.Windows.Forms.TabPage();
            this.checkBoxEnablePlaylistManager = new System.Windows.Forms.CheckBox();
            this.groupBoxSongFrequency = new System.Windows.Forms.GroupBox();
            this.labelUnitSongFrequency = new System.Windows.Forms.Label();
            this.labelSongFrequency = new System.Windows.Forms.Label();
            this.numericUpDownSongFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBoxArtistThrottling = new System.Windows.Forms.GroupBox();
            this.labelUnitArtistThrottling = new System.Windows.Forms.Label();
            this.labelArtistThrottling = new System.Windows.Forms.Label();
            this.numericUpDownArtistThrottling = new System.Windows.Forms.NumericUpDown();
            this.tabPageSpotifySettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSpotifyPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSpotifyUsername = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxPasswordProtection.SuspendLayout();
            this.groupBoxQueSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueueSize)).BeginInit();
            this.tabPagePlaylistManager.SuspendLayout();
            this.groupBoxSongFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSongFrequency)).BeginInit();
            this.groupBoxArtistThrottling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArtistThrottling)).BeginInit();
            this.tabPageSpotifySettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.mainTabControl, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(477, 389);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPageGeneral);
            this.mainTabControl.Controls.Add(this.tabPagePlaylistManager);
            this.mainTabControl.Controls.Add(this.tabPageSpotifySettings);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.mainTabControl.Location = new System.Drawing.Point(3, 3);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(471, 337);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxProtectWithPassword);
            this.tabPageGeneral.Controls.Add(this.groupBoxPasswordProtection);
            this.tabPageGeneral.Controls.Add(this.groupBoxQueSize);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Size = new System.Drawing.Size(463, 307);
            this.tabPageGeneral.TabIndex = 3;
            this.tabPageGeneral.Text = "General settings";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxProtectWithPassword
            // 
            this.checkBoxProtectWithPassword.AutoSize = true;
            this.checkBoxProtectWithPassword.Location = new System.Drawing.Point(28, 125);
            this.checkBoxProtectWithPassword.Name = "checkBoxProtectWithPassword";
            this.checkBoxProtectWithPassword.Size = new System.Drawing.Size(216, 23);
            this.checkBoxProtectWithPassword.TabIndex = 9;
            this.checkBoxProtectWithPassword.Text = "Protect settings with password";
            this.checkBoxProtectWithPassword.UseVisualStyleBackColor = true;
            this.checkBoxProtectWithPassword.CheckedChanged += new System.EventHandler(this.checkBoxProtectWithPassword_CheckedChanged);
            // 
            // groupBoxPasswordProtection
            // 
            this.groupBoxPasswordProtection.Controls.Add(this.labelReenterSettingsPassword);
            this.groupBoxPasswordProtection.Controls.Add(this.textBoxReenterPassword);
            this.groupBoxPasswordProtection.Controls.Add(this.labelEnterSettingsPassword);
            this.groupBoxPasswordProtection.Controls.Add(this.textBoxEnterSettingsPassword);
            this.groupBoxPasswordProtection.Font = new System.Drawing.Font("Segoe WP", 9.75F);
            this.groupBoxPasswordProtection.Location = new System.Drawing.Point(21, 148);
            this.groupBoxPasswordProtection.Name = "groupBoxPasswordProtection";
            this.groupBoxPasswordProtection.Size = new System.Drawing.Size(392, 119);
            this.groupBoxPasswordProtection.TabIndex = 8;
            this.groupBoxPasswordProtection.TabStop = false;
            this.groupBoxPasswordProtection.Text = "Password protection";
            // 
            // labelReenterSettingsPassword
            // 
            this.labelReenterSettingsPassword.AutoSize = true;
            this.labelReenterSettingsPassword.Location = new System.Drawing.Point(160, 72);
            this.labelReenterSettingsPassword.Name = "labelReenterSettingsPassword";
            this.labelReenterSettingsPassword.Size = new System.Drawing.Size(119, 17);
            this.labelReenterSettingsPassword.TabIndex = 7;
            this.labelReenterSettingsPassword.Text = "Re-enter password";
            // 
            // textBoxReenterPassword
            // 
            this.textBoxReenterPassword.Location = new System.Drawing.Point(7, 69);
            this.textBoxReenterPassword.Name = "textBoxReenterPassword";
            this.textBoxReenterPassword.Size = new System.Drawing.Size(147, 25);
            this.textBoxReenterPassword.TabIndex = 6;
            this.textBoxReenterPassword.UseSystemPasswordChar = true;
            // 
            // labelEnterSettingsPassword
            // 
            this.labelEnterSettingsPassword.AutoSize = true;
            this.labelEnterSettingsPassword.Location = new System.Drawing.Point(160, 41);
            this.labelEnterSettingsPassword.Name = "labelEnterSettingsPassword";
            this.labelEnterSettingsPassword.Size = new System.Drawing.Size(99, 17);
            this.labelEnterSettingsPassword.TabIndex = 5;
            this.labelEnterSettingsPassword.Text = "Enter password";
            // 
            // textBoxEnterSettingsPassword
            // 
            this.textBoxEnterSettingsPassword.Location = new System.Drawing.Point(7, 38);
            this.textBoxEnterSettingsPassword.Name = "textBoxEnterSettingsPassword";
            this.textBoxEnterSettingsPassword.Size = new System.Drawing.Size(147, 25);
            this.textBoxEnterSettingsPassword.TabIndex = 4;
            this.textBoxEnterSettingsPassword.UseSystemPasswordChar = true;
            // 
            // groupBoxQueSize
            // 
            this.groupBoxQueSize.Controls.Add(this.labelUnitQueueSize);
            this.groupBoxQueSize.Controls.Add(this.labelQueueSize);
            this.groupBoxQueSize.Controls.Add(this.numericUpDownQueueSize);
            this.groupBoxQueSize.Font = new System.Drawing.Font("Segoe WP", 9.75F);
            this.groupBoxQueSize.Location = new System.Drawing.Point(21, 26);
            this.groupBoxQueSize.Name = "groupBoxQueSize";
            this.groupBoxQueSize.Size = new System.Drawing.Size(392, 63);
            this.groupBoxQueSize.TabIndex = 7;
            this.groupBoxQueSize.TabStop = false;
            this.groupBoxQueSize.Text = "Queue size";
            // 
            // labelUnitQueueSize
            // 
            this.labelUnitQueueSize.AutoSize = true;
            this.labelUnitQueueSize.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelUnitQueueSize.Location = new System.Drawing.Point(49, 23);
            this.labelUnitQueueSize.Name = "labelUnitQueueSize";
            this.labelUnitQueueSize.Size = new System.Drawing.Size(45, 19);
            this.labelUnitQueueSize.TabIndex = 6;
            this.labelUnitQueueSize.Text = "songs";
            // 
            // labelQueueSize
            // 
            this.labelQueueSize.AutoSize = true;
            this.labelQueueSize.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelQueueSize.Location = new System.Drawing.Point(113, 23);
            this.labelQueueSize.Name = "labelQueueSize";
            this.labelQueueSize.Size = new System.Drawing.Size(186, 19);
            this.labelQueueSize.TabIndex = 1;
            this.labelQueueSize.Text = "Sets the length of the queue.";
            // 
            // numericUpDownQueueSize
            // 
            this.numericUpDownQueueSize.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQueueSize.Location = new System.Drawing.Point(7, 23);
            this.numericUpDownQueueSize.Name = "numericUpDownQueueSize";
            this.numericUpDownQueueSize.Size = new System.Drawing.Size(40, 25);
            this.numericUpDownQueueSize.TabIndex = 0;
            // 
            // tabPagePlaylistManager
            // 
            this.tabPagePlaylistManager.Controls.Add(this.checkBoxEnablePlaylistManager);
            this.tabPagePlaylistManager.Controls.Add(this.groupBoxSongFrequency);
            this.tabPagePlaylistManager.Controls.Add(this.groupBoxArtistThrottling);
            this.tabPagePlaylistManager.Location = new System.Drawing.Point(4, 26);
            this.tabPagePlaylistManager.Name = "tabPagePlaylistManager";
            this.tabPagePlaylistManager.Size = new System.Drawing.Size(463, 307);
            this.tabPagePlaylistManager.TabIndex = 2;
            this.tabPagePlaylistManager.Text = "Playlist Manager";
            this.tabPagePlaylistManager.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnablePlaylistManager
            // 
            this.checkBoxEnablePlaylistManager.AutoSize = true;
            this.checkBoxEnablePlaylistManager.Location = new System.Drawing.Point(33, 20);
            this.checkBoxEnablePlaylistManager.Name = "checkBoxEnablePlaylistManager";
            this.checkBoxEnablePlaylistManager.Size = new System.Drawing.Size(173, 23);
            this.checkBoxEnablePlaylistManager.TabIndex = 6;
            this.checkBoxEnablePlaylistManager.Text = "Enable Playlist Manager";
            this.checkBoxEnablePlaylistManager.UseVisualStyleBackColor = true;
            this.checkBoxEnablePlaylistManager.CheckedChanged += new System.EventHandler(this.checkBoxEnablePlaylistManager_CheckedChanged);
            // 
            // groupBoxSongFrequency
            // 
            this.groupBoxSongFrequency.Controls.Add(this.labelUnitSongFrequency);
            this.groupBoxSongFrequency.Controls.Add(this.labelSongFrequency);
            this.groupBoxSongFrequency.Controls.Add(this.numericUpDownSongFrequency);
            this.groupBoxSongFrequency.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongFrequency.Location = new System.Drawing.Point(33, 135);
            this.groupBoxSongFrequency.Name = "groupBoxSongFrequency";
            this.groupBoxSongFrequency.Size = new System.Drawing.Size(392, 63);
            this.groupBoxSongFrequency.TabIndex = 5;
            this.groupBoxSongFrequency.TabStop = false;
            this.groupBoxSongFrequency.Text = "Song frequency";
            // 
            // labelUnitSongFrequency
            // 
            this.labelUnitSongFrequency.AutoSize = true;
            this.labelUnitSongFrequency.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelUnitSongFrequency.Location = new System.Drawing.Point(50, 24);
            this.labelUnitSongFrequency.Name = "labelUnitSongFrequency";
            this.labelUnitSongFrequency.Size = new System.Drawing.Size(35, 19);
            this.labelUnitSongFrequency.TabIndex = 8;
            this.labelUnitSongFrequency.Text = "min.";
            // 
            // labelSongFrequency
            // 
            this.labelSongFrequency.AutoSize = true;
            this.labelSongFrequency.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelSongFrequency.Location = new System.Drawing.Point(113, 16);
            this.labelSongFrequency.Name = "labelSongFrequency";
            this.labelSongFrequency.Size = new System.Drawing.Size(284, 38);
            this.labelSongFrequency.TabIndex = 2;
            this.labelSongFrequency.Text = "Sets the number of minutes before a specific \r\nsong can be added to the queue aga" +
    "in.";
            // 
            // numericUpDownSongFrequency
            // 
            this.numericUpDownSongFrequency.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSongFrequency.Location = new System.Drawing.Point(7, 22);
            this.numericUpDownSongFrequency.Name = "numericUpDownSongFrequency";
            this.numericUpDownSongFrequency.Size = new System.Drawing.Size(40, 25);
            this.numericUpDownSongFrequency.TabIndex = 1;
            // 
            // groupBoxArtistThrottling
            // 
            this.groupBoxArtistThrottling.Controls.Add(this.labelUnitArtistThrottling);
            this.groupBoxArtistThrottling.Controls.Add(this.labelArtistThrottling);
            this.groupBoxArtistThrottling.Controls.Add(this.numericUpDownArtistThrottling);
            this.groupBoxArtistThrottling.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxArtistThrottling.Location = new System.Drawing.Point(33, 59);
            this.groupBoxArtistThrottling.Name = "groupBoxArtistThrottling";
            this.groupBoxArtistThrottling.Size = new System.Drawing.Size(392, 63);
            this.groupBoxArtistThrottling.TabIndex = 4;
            this.groupBoxArtistThrottling.TabStop = false;
            this.groupBoxArtistThrottling.Text = "Artist throttling";
            // 
            // labelUnitArtistThrottling
            // 
            this.labelUnitArtistThrottling.AutoSize = true;
            this.labelUnitArtistThrottling.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelUnitArtistThrottling.Location = new System.Drawing.Point(49, 25);
            this.labelUnitArtistThrottling.Name = "labelUnitArtistThrottling";
            this.labelUnitArtistThrottling.Size = new System.Drawing.Size(46, 19);
            this.labelUnitArtistThrottling.TabIndex = 7;
            this.labelUnitArtistThrottling.Text = "artists";
            // 
            // labelArtistThrottling
            // 
            this.labelArtistThrottling.AutoSize = true;
            this.labelArtistThrottling.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.labelArtistThrottling.Location = new System.Drawing.Point(113, 18);
            this.labelArtistThrottling.Name = "labelArtistThrottling";
            this.labelArtistThrottling.Size = new System.Drawing.Size(259, 38);
            this.labelArtistThrottling.TabIndex = 3;
            this.labelArtistThrottling.Text = "Sets the number of artists that is allowed\r\nin the queue.";
            // 
            // numericUpDownArtistThrottling
            // 
            this.numericUpDownArtistThrottling.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownArtistThrottling.Location = new System.Drawing.Point(6, 22);
            this.numericUpDownArtistThrottling.Name = "numericUpDownArtistThrottling";
            this.numericUpDownArtistThrottling.Size = new System.Drawing.Size(41, 25);
            this.numericUpDownArtistThrottling.TabIndex = 2;
            // 
            // tabPageSpotifySettings
            // 
            this.tabPageSpotifySettings.Controls.Add(this.groupBox2);
            this.tabPageSpotifySettings.Location = new System.Drawing.Point(4, 26);
            this.tabPageSpotifySettings.Name = "tabPageSpotifySettings";
            this.tabPageSpotifySettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpotifySettings.Size = new System.Drawing.Size(463, 307);
            this.tabPageSpotifySettings.TabIndex = 0;
            this.tabPageSpotifySettings.Text = "Spotify settings";
            this.tabPageSpotifySettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxSpotifyPassword);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxSpotifyUsername);
            this.groupBox2.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.groupBox2.Location = new System.Drawing.Point(32, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 134);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spotify account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe WP", 10F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Re-login requires restart of Jukebox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // textBoxSpotifyPassword
            // 
            this.textBoxSpotifyPassword.Location = new System.Drawing.Point(9, 66);
            this.textBoxSpotifyPassword.Name = "textBoxSpotifyPassword";
            this.textBoxSpotifyPassword.Size = new System.Drawing.Size(147, 25);
            this.textBoxSpotifyPassword.TabIndex = 2;
            this.textBoxSpotifyPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username/mail";
            // 
            // textBoxSpotifyUsername
            // 
            this.textBoxSpotifyUsername.Location = new System.Drawing.Point(9, 31);
            this.textBoxSpotifyUsername.Name = "textBoxSpotifyUsername";
            this.textBoxSpotifyUsername.Size = new System.Drawing.Size(147, 25);
            this.textBoxSpotifyUsername.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel2.Controls.Add(this.buttonSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 346);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(471, 40);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(393, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(317, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 27);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 389);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Font = new System.Drawing.Font("Segoe WP SemiLight", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBoxPasswordProtection.ResumeLayout(false);
            this.groupBoxPasswordProtection.PerformLayout();
            this.groupBoxQueSize.ResumeLayout(false);
            this.groupBoxQueSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueueSize)).EndInit();
            this.tabPagePlaylistManager.ResumeLayout(false);
            this.tabPagePlaylistManager.PerformLayout();
            this.groupBoxSongFrequency.ResumeLayout(false);
            this.groupBoxSongFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSongFrequency)).EndInit();
            this.groupBoxArtistThrottling.ResumeLayout(false);
            this.groupBoxArtistThrottling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArtistThrottling)).EndInit();
            this.tabPageSpotifySettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPageSpotifySettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSpotifyPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSpotifyUsername;
        private System.Windows.Forms.TabPage tabPagePlaylistManager;
        private System.Windows.Forms.GroupBox groupBoxSongFrequency;
        private System.Windows.Forms.Label labelSongFrequency;
        private System.Windows.Forms.NumericUpDown numericUpDownSongFrequency;
        private System.Windows.Forms.GroupBox groupBoxArtistThrottling;
        private System.Windows.Forms.Label labelArtistThrottling;
        private System.Windows.Forms.NumericUpDown numericUpDownArtistThrottling;
        private System.Windows.Forms.Label labelUnitSongFrequency;
        private System.Windows.Forms.Label labelUnitArtistThrottling;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.GroupBox groupBoxQueSize;
        private System.Windows.Forms.Label labelUnitQueueSize;
        private System.Windows.Forms.Label labelQueueSize;
        private System.Windows.Forms.NumericUpDown numericUpDownQueueSize;
        private System.Windows.Forms.GroupBox groupBoxPasswordProtection;
        private System.Windows.Forms.CheckBox checkBoxEnablePlaylistManager;
        private System.Windows.Forms.CheckBox checkBoxProtectWithPassword;
        private System.Windows.Forms.Label labelReenterSettingsPassword;
        private System.Windows.Forms.TextBox textBoxReenterPassword;
        private System.Windows.Forms.Label labelEnterSettingsPassword;
        private System.Windows.Forms.TextBox textBoxEnterSettingsPassword;
    }
}