using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Que.Server.Audio;
using Que.Server.Properties;
using Que.Server.Models;

namespace Que.Server
{
    public partial class Preferences : Form
    {
        //private List<Playlist> currentPlaylists;

        public Preferences()
        {            
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            /*currentPlaylists = AudioManager.Instance.GetPlaylists();

            // Set eventual default values
            if (Settings.Default.PickFromPlaylists == (string)Settings.Default.Properties["PickFromPlaylists"].DefaultValue)
            {
                String playlistsStr = "";
                foreach (Playlist playlist in currentPlaylists)
                {
                    playlistsStr += playlist.Id + ",";
                }

                Settings.Default.PickFromPlaylists = playlistsStr;
                Settings.Default.Save();
            }

            Console.WriteLine("PickFromPlaylists:" + Settings.Default.PickFromPlaylists);

            // Load from settings
            String[] selectedPlaylists = Settings.Default.PickFromPlaylists.Split(',');
            foreach (Playlist playlist in currentPlaylists)
            {
                checkedListBoxPlaylists.Items.Add(playlist.Name, selectedPlaylists.Contains<string>(playlist.Id.ToString()));
            }*/
            this.numericUpDownQueueSize.Value = Settings.Default.QueueSize;
            this.numericUpDownArtistThrottling.Value = Settings.Default.MaxNumberOfArtistInQueue;
            this.numericUpDownSongFrequency.Value = (decimal)Settings.Default.SongFrequencyMinutes.TotalMinutes;
            this.textBoxSpotifyUsername.Text = Settings.Default.SpotifyUsername;
            this.textBoxSpotifyPassword.Text = Settings.Default.SpotifyPassword;

            if (Settings.Default.PasswordProtected)
            {
                this.groupBoxPasswordProtection.Enabled = true;
                this.checkBoxProtectWithPassword.Checked = true;
                this.textBoxEnterSettingsPassword.Text = Settings.Default.SettingsPassword;
                this.textBoxReenterPassword.Text = Settings.Default.SettingsPassword;
            }
            else
            {
                this.groupBoxPasswordProtection.Enabled = false;
            }

            if (Settings.Default.PlaylistManagerEnabled)
            {
                this.checkBoxEnablePlaylistManager.Checked = true;
                this.groupBoxSongFrequency.Enabled = true;
                this.groupBoxArtistThrottling.Enabled = true;
            }
            else
            {
                this.checkBoxEnablePlaylistManager.Checked = false;
                this.groupBoxSongFrequency.Enabled = false;
                this.groupBoxArtistThrottling.Enabled = false;
            }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Save "pick from" playlists
            /*String playlistsStr = "";

            for (int i = 0; i < currentPlaylists.Count; i++)
            {
                if (checkedListBoxPlaylists.GetItemChecked(i))
                {
                    playlistsStr += currentPlaylists[i].Id + ",";
                }
            }
            Settings.Default.PickFromPlaylists = playlistsStr;*/

            // Save spotify account
            Settings.Default.SpotifyUsername = textBoxSpotifyUsername.Text;
            Settings.Default.SpotifyPassword = textBoxSpotifyPassword.Text;
            Settings.Default.QueueSize = Convert.ToInt16(this.numericUpDownQueueSize.Value);
            Settings.Default.MaxNumberOfArtistInQueue = Convert.ToInt16(this.numericUpDownArtistThrottling.Value);
            Settings.Default.SongFrequencyMinutes = TimeSpan.FromMinutes((double)this.numericUpDownSongFrequency.Value);

            if (checkBoxProtectWithPassword.Checked)
            {
                if (VerifyTwoPasswords(textBoxEnterSettingsPassword.Text, textBoxReenterPassword.Text) &&
                    (textBoxEnterSettingsPassword.Text != "" && textBoxReenterPassword.Text != ""))
                {
                    Settings.Default.SettingsPassword = textBoxReenterPassword.Text;
                    Settings.Default.PasswordProtected = true;
                }
                else
                {
                    MessageBox.Show("The two entered passwords do not match or are empty!");
                    return;
                }
            }
            else
            {
                Settings.Default.PasswordProtected = false;
            }
            
            // Important! Save the settings
            Settings.Default.Save();

            this.Close();
        }

        private bool VerifyTwoPasswords(string password1, string password2)
        {
            if (password1.Equals(password2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxProtectWithPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProtectWithPassword.Checked)
            {
                groupBoxPasswordProtection.Enabled = true;
            }
            else
            {
                groupBoxPasswordProtection.Enabled = false;
            }
        }

        private void checkBoxEnablePlaylistManager_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnablePlaylistManager.Checked)
            {
                groupBoxSongFrequency.Enabled = true;
                groupBoxArtistThrottling.Enabled = true;
                Settings.Default.PlaylistManagerEnabled = true;
            }
            else
            {
                groupBoxSongFrequency.Enabled = false;
                groupBoxArtistThrottling.Enabled = false;
                Settings.Default.PlaylistManagerEnabled = false;
            }
        }
    }
}
