using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;
using Que.Server.Models;
using Que.Server.Audio;
using Que.Server.Properties;
using SpotiFire.SpotifyLib;

namespace Que.Server
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer updateProgressTimer;
        private LoggingInForm loggingInForm;

        public MainForm()
        {
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();

            AudioManager.Instance.Initialize();
            AudioManager.Instance.OnSearchCompleted += new AudioManager.OnSearchCompletedEventHandler(Instance_OnSearchCompleted);
            AudioManager.Instance.OnImageLoaded += new AudioManager.OnImageLoadedEventHandler(Instance_OnImageLoaded);
            AudioManager.Instance.OnNowPlayingUpdate += new AudioManager.OnNowPlayingUpdateEventHandler(Instance_OnNowPlayingUpdate);
            AudioManager.Instance.OnQueueUpdate += new AudioManager.OnQueueUpdateEventHandler(Instance_OnQueueUpdate);
            AudioManager.Instance.OnSeekUpdate += new AudioManager.OnSeekUpdateEventHandler(Instance_OnSeekUpdate);
            AudioManager.Instance.OnLogin += new AudioManager.OnLoginEventHandler(Instance_OnLogin);

            updateProgressTimer = new System.Windows.Forms.Timer();
            updateProgressTimer.Interval = 100;
            updateProgressTimer.Tick += new EventHandler(updateProgressTimer_Tick);
            updateProgressTimer.Start();
        }

        void Instance_OnLogin(bool success)
        {
            if (!success)
            {
                this.UIThread(delegate
                {
                    loggingInForm.Hide();
                    MessageBox.Show("Could not authenticate with the Spotify service", "Authentication error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
            else
            {
                Thread thread = new Thread(() =>
                {
                    // Pre-fetch all playlists
                    AudioManager.Instance.GetPlaylists();

                    this.UIThread(delegate
                    {
                        loggingInForm.Hide();
                    });

                });
                thread.Start();
            }
        }

        void Instance_OnSeekUpdate(int offset)
        {
            this.UIThread(delegate
            {
                progressBarPlayed.Value = offset;
            });
        }

        void Instance_OnQueueUpdate()
        {
            this.UIThread(delegate
            {
                listViewQueue.Items.Clear();
                int pos = 1;
                foreach (ITrack audioTrackWrapper in AudioManager.Instance.PlayQueue)
                {
                    Track audioTrack = new Track(audioTrackWrapper);

                    ListViewItem listViewItem = new ListViewItem(audioTrack.Artists[0].Name + " - " + audioTrack.Name);
                    listViewItem.ImageIndex = (pos > 9) ? 0 : pos;
                    listViewItem.Tag = audioTrack;
                    listViewQueue.Items.Add(listViewItem);
                    pos++;
                }
            });
        }

        void Instance_OnNowPlayingUpdate()
        {
            this.UIThread(delegate
            {
                if (AudioManager.Instance.CurrentTrack != null)
                {
                    // Update current track info
                    progressBarPlayed.Maximum = (int)AudioManager.Instance.CurrentTrack.Length.TotalMilliseconds;
                    progressBarPlayed.Value = (AudioManager.Instance.TrackElapsed < AudioManager.Instance.CurrentTrack.Length) ? (int)AudioManager.Instance.TrackElapsed.TotalMilliseconds : 0;
                    labelTrackName.Text = AudioManager.Instance.CurrentTrack.Name;
                    labelTrackAlbum.Text = AudioManager.Instance.CurrentTrack.Album;

                    AudioManager.Instance.GetImageAsync(AudioManager.Instance.CurrentTrack.AlbumCoverId);

                    Stream s = this.GetType().Assembly.GetManifestResourceStream("Que.Server.Resources.unknown_album_cover.png");
                    Bitmap albumImage = new Bitmap(s);
                    s.Close();

                    pictureBoxTrackAlbumCover.Image = albumImage;

                    String artists = String.Empty;
                    foreach (Artist artist in AudioManager.Instance.CurrentTrack.Artists)
                    {
                        artists += artist.Name.Replace("&", "\\&") + ", ";
                    }
                    artists = artists.Substring(0, artists.Length - 2);
                    labelTrackArtist.Text = artists;
                }
                else
                {
                    labelTrackName.Text = "";
                    labelTrackArtist.Text = "";
                    labelTrackAlbum.Text = "";
                }
            });
        }

        void Instance_OnSearchCompleted(ISearch result)
        {
            this.UIThread(delegate
            {
                listViewSearchResults.Items.Clear();

                foreach (ITrack audioTrackWrapper in result.Tracks)
                {
                    Track audioTrack = new Track(audioTrackWrapper);

                    ListViewItem listViewItem = new ListViewItem(audioTrack.Name);
                    listViewItem.SubItems.Add(audioTrack.Artists[0].Name);
                    listViewItem.SubItems.Add(audioTrack.Album);
                    listViewItem.Tag = audioTrack;
                    listViewSearchResults.Items.Add(listViewItem);
                }

                if (!panelFullSearch.Visible)
                {
                    panelSimpleSearch.Visible = false;
                    panelFullSearch.Visible = true;
                    textBoxSearch.Text = textBoxSearchFull.Text;
                }

                loadingCircleSearchFull.Visible = false;
                loadingCircleSearch.Visible = false;

                if (result.DidYouMean != null && result.DidYouMean.Length > 0)
                {
                    linkLabelDidYouMean.Text = "Did you mean '" + result.DidYouMean + "'?";
                    linkLabelDidYouMean.Tag = result.DidYouMean;
                    linkLabelDidYouMean.Visible = true;
                }
                else
                {
                    linkLabelDidYouMean.Text = "";
                    linkLabelDidYouMean.Tag = "";
                    linkLabelDidYouMean.Visible = false;
                }

                labelSearchResults.Text = result.TotalTracks + " results.";
            });
        }

        void Instance_OnImageLoaded(Bitmap image, string imageId)
        {
            Console.WriteLine("Got image: " + imageId);

            if (imageId.Length == 40 && imageId == AudioManager.Instance.CurrentTrack.AlbumCoverId)
            {
                this.UIThread(delegate
                {
                    pictureBoxTrackAlbumCover.Image = image;
                });
            }
        }

        void updateProgressTimer_Tick(object sender, EventArgs e)
        {
            if (AudioManager.Instance.IsPlaying)
            {
                if (progressBarPlayed.Value + 100 < progressBarPlayed.Maximum)
                {
                    progressBarPlayed.Value += 100;
                }
                else
                {
                    progressBarPlayed.Value = progressBarPlayed.Maximum;
                }

                TimeSpan elapsed = new TimeSpan(0, 0, progressBarPlayed.Value / 1000);
                labelTimeElapsed.Text = String.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);

                TimeSpan remaining = new TimeSpan(0, 0, (progressBarPlayed.Maximum - progressBarPlayed.Value) / 1000);
                labelTimeRemaining.Text = String.Format("-{0:00}:{1:00}", remaining.Minutes, remaining.Seconds);
            }
        }

        private void PerformSearch(String query)
        {
            AudioManager.Instance.Search(query);
            loadingCircleSearchFull.Visible = true;
            loadingCircleSearch.Visible = true;
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == (char)13) // Enter
            {
                if (!panelFullSearch.Visible)
                {
                    loadingCircleSearchFull.Visible = true;
                    loadingCircleSearch.Visible = true;
                }

                PerformSearch(textBox.Text);
            }
        }

        private void listViewSearchResults_DoubleClick(object sender, EventArgs e)
        {
            if (listViewSearchResults.SelectedItems.Count > 0)
            {
                Track audioTrack = (Track)listViewSearchResults.SelectedItems[0].Tag;

                try
                {
                    AudioManager.Instance.AddToQueue(audioTrack.TrackObj);
                }
                catch (PlaylistManagerNS.PlaylistManagerException ex)
                {
                    MessageBox.Show(ex.Message, "Could not enqueue song", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void listViewSearchResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && listViewSearchResults.SelectedItems.Count > 0)
            {
                Track audioTrack = (Track)listViewSearchResults.SelectedItems[0].Tag;
                
                try
                {
                    AudioManager.Instance.AddToQueue(audioTrack.TrackObj);
                }
                catch (PlaylistManagerNS.PlaylistManagerException ex)
                {
                    MessageBox.Show(ex.Message, "Could not enqueue song", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (AudioManager.Instance.IsPlaying)
            {
                Stream s = this.GetType().Assembly.GetManifestResourceStream("Que.Server.Resources.1313182641_button_black_play.png");
                Bitmap bitmap = new Bitmap(s);
                buttonPlay.Image = bitmap;
                s.Close();
            }
            else
            {
                Stream s = this.GetType().Assembly.GetManifestResourceStream("Que.Server.Resources.1313182671_button_black_pause.png");
                Bitmap bitmap = new Bitmap(s);
                buttonPlay.Image = bitmap;
                s.Close();
            }

            AudioManager.Instance.PlayPause();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Next();
            progressBarPlayed.Value = 0;
        }

        private void progressBarPlayed_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double percent = (double)e.X / (double)progressBarPlayed.Width;
                double offset = percent * (double)progressBarPlayed.Maximum;
                Console.WriteLine("Percent: " + percent + " offset: " + offset);
                AudioManager.Instance.Seek((int)offset);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearchFull.Text = "";
            textBoxSearch.Text = "";
            panelFullSearch.Visible = false;
            panelSimpleSearch.Visible = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewQueue_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listViewQueue_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listViewQueue_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem listViewItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                if (listViewQueue.Items.Contains(listViewItem))
                {
                    // From same (queue) listview, reorder
                    Point cp = listViewQueue.PointToClient(new Point(e.X, e.Y));
                    ListViewItem dragToItem = listViewQueue.GetItemAt(cp.X, cp.Y);

                    if (dragToItem != null && listViewQueue.SelectedItems.Count > 0)
                    {
                        int dropIndex = dragToItem.Index;
                        AudioManager.Instance.MoveInQueue(listViewQueue.SelectedItems[0].Index + 1, dropIndex + 1);
                    }
                }
                else
                {
                    try
                    {
                        // From search results list view
                        AudioManager.Instance.AddToQueue((ITrack)listViewItem.Tag);
                    }
                    catch (PlaylistManagerNS.PlaylistManagerException ex)
                    {
                        MessageBox.Show(ex.Message, "Could not enqueue song", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void listViewQueue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Delete" && listViewQueue.SelectedItems.Count > 0)
            {
                AudioManager.Instance.RemoveFromQueue(listViewQueue.SelectedItems[0].Index + 1);
            }
        }

        private void listViewSearchResults_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void playlistManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.PasswordProtected)
            {
                VerifyPassword password = new VerifyPassword();
                password.ShowDialog();
            }
            else
            {
                Preferences preferences = new Preferences();
                preferences.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void linkLabelDidYouMean_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel)sender;

            if (!panelFullSearch.Visible)
            {
                loadingCircleSearchFull.Visible = true;
                loadingCircleSearch.Visible = true;
            }

            textBoxSearch.Text = linkLabel.Tag.ToString();
            PerformSearch(linkLabel.Tag.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AudioManager.Instance.Login(Settings.Default.SpotifyUsername, Settings.Default.SpotifyPassword);

            loggingInForm = new LoggingInForm();
            loggingInForm.ShowDialog();
        }
    }

    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code"></param>
        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
            {
                @this.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }
    }
}
