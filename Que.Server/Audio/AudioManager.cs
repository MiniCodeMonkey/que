using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Threading;
using System.Drawing;
using SpotiFire.SpotifyLib;
using Que.Server.Models;
using Que.Server.PlaylistManagerNS;

namespace Que.Server.Audio
{
    class AudioManager
    {
        private Player player = null;
        private Random random = new Random();
        private bool addedToHistory = false;

        #region Events
        public delegate void OnImageLoadedEventHandler(Bitmap image, string imageId);
        public event OnImageLoadedEventHandler OnImageLoaded;

        public delegate void OnSearchCompletedEventHandler(ISearch results);
        public event OnSearchCompletedEventHandler OnSearchCompleted;

        public delegate void OnQueueUpdateEventHandler();
        public event OnQueueUpdateEventHandler OnQueueUpdate;

        public delegate void OnNowPlayingUpdateEventHandler();
        public event OnNowPlayingUpdateEventHandler OnNowPlayingUpdate;

        public delegate void OnSeekUpdateEventHandler(int offset);
        public event OnSeekUpdateEventHandler OnSeekUpdate;

        public delegate void OnLoginEventHandler(bool success);
        public event OnLoginEventHandler OnLogin;
        #endregion

        #region Attributes
        private ISession spotify;
        private Queue<ITrack> playQueue;
        private AutoResetEvent loginComplete = new AutoResetEvent(false);
        private readonly object canLoginLock = new object();
        private ManualResetEvent waitHandle = new ManualResetEvent(false);

        private TimeSpan elapsedTime;
        private Track currentTrack = null;

        private bool playing = false;

        /// <summary>
        /// The single instance of the class, used with the singleton pattern
        /// </summary>
        static readonly AudioManager _instance = new AudioManager();

        /// <summary>
        /// The single instance of the class
        /// </summary>
        public static AudioManager Instance
        {
            get { return _instance; }
        }

        public Queue<ITrack> PlayQueue
        {
            get { return playQueue; }
        }

        public Track CurrentTrack
        {
            get { return currentTrack; }
        }
        #endregion

        /// <summary>
        /// Private constructor, use Instance instead
        /// </summary>
        private AudioManager()
        {

        }

        public void Initialize()
		{			
			#region key
			
			// This key is not mine. It was found on a public website. Please don't misuse.
						
			byte[] key = new Byte[]
			{
	            0x01, 0x5E, 0xE3, 0x33, 0x75, 0x20, 0xCB, 0x1F, 0x59, 0x01, 0x81, 0x4B, 0x25, 0xB4, 0x9C, 0x53,
	            0x9B, 0x10, 0xD7, 0xD3, 0x58, 0x9B, 0xBF, 0x32, 0x23, 0x5C, 0x38, 0xEA, 0x64, 0x3D, 0x2D, 0xD6,
	            0x97, 0x56, 0xAE, 0xF4, 0x7D, 0x82, 0x71, 0x38, 0x2F, 0x72, 0xF6, 0x40, 0xA1, 0xFA, 0x19, 0xA7,
	            0xAC, 0x50, 0xFB, 0xB9, 0x64, 0x26, 0x3E, 0x55, 0x05, 0x15, 0x3A, 0x19, 0xD3, 0xF8, 0x26, 0xC2,
	            0x8E, 0x1B, 0xAB, 0xC0, 0x51, 0xB5, 0xAE, 0x82, 0xD3, 0x94, 0xB4, 0xE7, 0x89, 0x70, 0xF1, 0x4F,
	            0xF4, 0xA3, 0x2B, 0xD8, 0x1B, 0x64, 0x69, 0x7A, 0x66, 0xB0, 0x12, 0x0D, 0xEE, 0xE8, 0x3A, 0x80,
	            0xD8, 0x4B, 0xAF, 0xD5, 0xD9, 0xC6, 0xD5, 0xF5, 0xB4, 0x5D, 0xCC, 0x69, 0xDD, 0x9C, 0xF9, 0x0F,
	            0xEA, 0xEB, 0x5E, 0x21, 0x26, 0x71, 0x38, 0x23, 0x22, 0xCB, 0xDC, 0x89, 0x18, 0x63, 0x9A, 0xC8,
	            0xA6, 0x7C, 0x18, 0x32, 0x8D, 0xCE, 0x3D, 0xFE, 0xFF, 0x3A, 0xD0, 0x11, 0xF5, 0xE6, 0x13, 0xCF,
	            0x3C, 0x96, 0xB7, 0xBE, 0x95, 0x00, 0x96, 0x38, 0x6B, 0xE1, 0xDE, 0xA9, 0x24, 0x57, 0xAB, 0xDC,
	            0x85, 0x28, 0x8D, 0xAB, 0x08, 0x8A, 0xE2, 0x6A, 0x44, 0x36, 0x35, 0x4C, 0x81, 0x69, 0xC4, 0x54,
	            0x96, 0x8B, 0x2F, 0xDC, 0x3B, 0xA7, 0xE7, 0xE4, 0x56, 0x49, 0xFD, 0x07, 0x14, 0xEF, 0x68, 0xA3,
	            0xF6, 0x3F, 0x7D, 0x68, 0x62, 0x6B, 0x3F, 0xA5, 0x3D, 0x88, 0x3F, 0xB1, 0xD3, 0xA6, 0xC3, 0x8D,
	            0xDB, 0xC6, 0xAF, 0x4C, 0x12, 0x48, 0x52, 0x05, 0x3C, 0x78, 0xD6, 0xA1, 0x1F, 0x1E, 0x44, 0x60,
	            0x5A, 0xED, 0xB9, 0x90, 0x77, 0x2A, 0xA5, 0x2A, 0xD4, 0xFB, 0xC9, 0x1C, 0x04, 0x18, 0xFF, 0xB9,
	            0x64, 0x55, 0xB4, 0xD9, 0x79, 0x24, 0xFE, 0x72, 0xF5, 0x7E, 0xCF, 0xCE, 0x63, 0x4C, 0xF5, 0x2E,
	            0xA1, 0x4B, 0x95, 0x95, 0xCB, 0x59, 0x95, 0xE0, 0xB2, 0xF5, 0x63, 0xC2, 0x1A, 0x99, 0x33, 0xF1,
	            0x39, 0xAF, 0xA6, 0x19, 0xD9, 0x1C, 0x86, 0xF9, 0x9E, 0x7F, 0xCA, 0x34, 0x26, 0x0A, 0x99, 0xDE,
	            0x89, 0x7C, 0xDC, 0xB4, 0xFC, 0x06, 0x6B, 0x9C, 0xC3, 0x8D, 0x06, 0x10, 0x87, 0x6C, 0x2F, 0x7D,
	            0x76, 0x55, 0x97, 0x74, 0x62, 0x75, 0xFD, 0x99, 0x24, 0xDB, 0x2C, 0xB6, 0x78, 0xFF, 0xBA, 0x9F,
	            0x9E
			};
			
			#endregion
            
            string cacheLocation;
            string settingsLocation;
            string userAgent = "SpotiFire";

            cacheLocation = settingsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpotiFire", "libspotify");
            try
            {
                if (!Directory.Exists(cacheLocation))
                    Directory.CreateDirectory(cacheLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

			AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

            this.spotify = Spotify.CreateSession(key, cacheLocation, settingsLocation, userAgent);
            this.spotify.SetPrefferedBitrate(sp_bitrate.BITRATE_320k);

            this.spotify.LoginComplete += new SessionEventHandler(spotify_LoginComplete);
            this.spotify.LogoutComplete += new SessionEventHandler(spotify_LogoutComplete);
            this.spotify.MusicDeliver += new MusicDeliveryEventHandler(spotify_MusicDeliver);
            this.spotify.EndOfTrack += new SessionEventHandler(spotify_EndOfTrack);

            this.spotify.StartPlayback += new SessionEventHandler(spotify_StartPlayback);
            this.spotify.StopPlayback += new SessionEventHandler(spotify_StopPlayback);

            this.spotify.ConnectionError += new SessionEventHandler(spotify_ConnectionError);
            this.spotify.Exception += new SessionEventHandler(spotify_Exception);
            this.spotify.LogMessage += new SessionEventHandler(spotify_LogMessage);
            this.spotify.PlayTokenLost += new SessionEventHandler(spotify_PlayTokenLost);
            this.spotify.StreamingError += new SessionEventHandler(spotify_StreamingError);

            this.playQueue = new Queue<ITrack>();

            player = new BASSPlayer();

            // Enable progress timer
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Start();
		}

        void spotify_StreamingError(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Streaming error: " + e.Message + " (" + e.Status + ")");
        }

        void spotify_PlayTokenLost(ISession sender, SessionEventArgs e)
        {
            playing = false;
            Console.WriteLine("Play token lost: " + e.Message + " (" + e.Status + ")");
            System.Windows.Forms.MessageBox.Show("Play token lost! Somebody else probably logged in on the Spotify account.");
        }

        void spotify_LogMessage(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Log: " + e.Message + " ("+ e.Status +")");
        }

        void spotify_Exception(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Exception: " + e.Status);
            Console.WriteLine(e.Message);
        }

        void spotify_ConnectionError(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Connection error: " + e.Message + " (" + e.Status + ")");

            System.Windows.Forms.MessageBox.Show("Connection error: " + e.Message);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsPlaying)
            {
                elapsedTime = elapsedTime.Add(TimeSpan.FromMilliseconds(105));

                if (CurrentTrack !=null &&
                    (elapsedTime.TotalSeconds / CurrentTrack.Length.TotalSeconds) > 0.6 && 
                    addedToHistory == false)
                {
                    addedToHistory = true;
                    IDataBase db = DataBase.GetInstance();
                    db.InsertToHistory(CurrentTrack.Name, CurrentTrack.Artists[0].Name);
                }
            }
        }

        void spotify_StopPlayback(ISession sender, SessionEventArgs e)
        {
            /*Console.WriteLine("StopPlayback called");

            playing = false;*/
        }

        void spotify_StartPlayback(ISession sender, SessionEventArgs e)
        {
            playing = true;

            /*Console.WriteLine("StartPlayback called");

            elapsedTime = TimeSpan.FromSeconds(0);
            playing = true;
            OnNowPlayingUpdate();*/
        }

        void spotify_EndOfTrack(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Track ended");

            if (playQueue.Count > 0)
            {
                currentTrack = new Track(playQueue.Dequeue());
            }
            else
            {
                PickRandomTrack();
            }

            spotify.PlayerLoad(currentTrack.TrackObj);
            spotify.PlayerPlay();
            elapsedTime = TimeSpan.FromSeconds(0);
            addedToHistory = false;

            OnNowPlayingUpdate();
            OnQueueUpdate();
        }

        void spotify_MusicDeliver(ISession sender, MusicDeliveryEventArgs e)
        {
            if (e.Samples.Length > 0)
            {
                e.ConsumedFrames = player.EnqueueSamples(e.Channels, e.Rate, e.Samples, e.Frames);
            }
            else
            {
                e.ConsumedFrames = 0;
            }
        }

        void spotify_LogoutComplete(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Logout complete");
        }

        void spotify_LoginComplete(ISession sender, SessionEventArgs e)
        {
            Console.WriteLine("Login complete: " + e.Status + " - " + e.Message);

            OnLogin(e.Status == sp_error.OK);
        }

        public void GetImageAsync(string imageId)
        {
            if (imageId.Length != 40)
            {
                // TODO: Some error handling here, yes?
            }
            else
            {
                IImage image = spotify.GetImageFromId(imageId);
                image.Loaded += new ImageEventHandler(image_Loaded);
            }
        }

        public Bitmap GetImageSync(string imageId)
        {
            if (imageId.Length != 40)
            {
                // TODO: Some error handling here, yes?
                return null;
            }
            else
            {
                IImage image = spotify.GetImageFromId(imageId);

                while (!image.IsLoaded)
                {
                    System.Threading.Thread.Sleep(100);
                }

                return new Bitmap(image.GetImage());
            }
        }

        void image_Loaded(IImage sender, EventArgs e)
        {
            OnImageLoaded(new Bitmap(sender.GetImage()), sender.ImageId);
        }

        public void Login(string username, string password)
        {
            lock (canLoginLock)
            {
                if (spotify.ConnectionState == sp_connectionstate.LOGGED_OUT)
                {
                    spotify.Login(username, password, false);
                }
            }
        }

        public void Exit()
        {
            spotify.PlayerUnload();
        }

        public List<Playlist> GetPlaylists()
        {
            while (!spotify.PlaylistContainer.IsLoaded)
            {
                Thread.Sleep(TimeSpan.FromSeconds(.5));
            }

            List<Playlist> playlists = new List<Playlist>();

            playlists.Add(Playlist.Get(spotify.Starred));

            foreach (var p in spotify.PlaylistContainer.Playlists)
                playlists.Add(Playlist.Get(p));

            return playlists;
        }

        public IEnumerable<Track> GetPlaylistTracks(Guid id)
        {
            Playlist playlist = Playlist.GetById(id);
            return playlist.playlist.Tracks.Select(t => new Track(t)).ToArray();
        }

        public void PlayPause()
        {
            playing = !playing;

            if (!playing)
            {
                spotify.PlayerPause();
            }
            else
            {
                if (currentTrack == null)
                {
                    if (playQueue.Count > 0)
                    {
                        currentTrack = new Track(playQueue.Dequeue());
                    }
                    else
                    {
                        PickRandomTrack();
                    }

                    if (currentTrack == null)
                        return;

                    spotify.PlayerLoad(currentTrack.TrackObj);

                    OnNowPlayingUpdate();
                    OnQueueUpdate();
                }

                spotify.PlayerPlay();
                elapsedTime = TimeSpan.FromSeconds(0);
                addedToHistory = false;
            }
        }

        public void Search(String query)
        {
            ISearch searchResults = spotify.Search(query, 0, 500, 0, 0, 0, 0);
            searchResults.Complete += new SearchEventHandler(searchResults_Complete);
        }

        public ISearch SearchSync(String query)
        {
            ISearch searchResults = spotify.Search(query, 0, 50, 0, 0, 0, 0);

            while (!searchResults.IsComplete)
            {
                System.Threading.Thread.Sleep(100);
            }

            return searchResults;
        }

        void searchResults_Complete(ISearch sender, SearchEventArgs e)
        {
            OnSearchCompleted(e.Result);
        }

        private void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled exception: " + e.ExceptionObject.ToString());
        }

        private bool IsWindows()
        {
            return Environment.OSVersion.ToString().ToLower().Contains("windows");
        }

        private void PickRandomTrack()
        {
            /*String[] selectedPlaylists = (Properties.Settings.Default.PickFromPlaylists == (string)Properties.Settings.Default.Properties["PickFromPlaylists"].DefaultValue) ?
                        null : Properties.Settings.Default.PickFromPlaylists.Split(',');*/

            Console.WriteLine("Picking random track");
            List<Track> possibleTracks = new List<Track>();

            foreach (Playlist playlist in this.GetPlaylists())
            {
                /*if (selectedPlaylists != null && !selectedPlaylists.Contains<string>(playlist.Id.ToString()))
                {
                    Console.WriteLine("Skipping playlist " + playlist.Name);
                    continue;
                }*/

                foreach (Track track in this.GetPlaylistTracks(playlist.Id))
                {
                    if (track.IsAvailable)
                        possibleTracks.Add(track);
                }
            }

            if (possibleTracks.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Please add some playlists to the Spotify account", "Could not play", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            else
            {
                currentTrack = possibleTracks[random.Next(possibleTracks.Count - 1)];

                Console.WriteLine("Playing " + currentTrack.Name + " from a playlist");
            }
        }

        public void Seek(int offset)
        {
            sp_error error = spotify.PlayerSeek(offset);

            Console.WriteLine("Seeking for " + offset);

            if (error != sp_error.OK && error != sp_error.BAD_API_VERSION)
            {
                Console.WriteLine("Could not seek, error: " + error);
            }
            else
            {
                elapsedTime = TimeSpan.FromMilliseconds(offset);
                OnSeekUpdate(offset);
            }
        }
        
        public void Next()
        {
            spotify.PlayerUnload();
            spotify_EndOfTrack(spotify, null);
        }

        public void AddToQueue(ITrack audioTrack)
        {
            PlaylistManager.CanEnqueue(new Track(audioTrack));
            
            playQueue.Enqueue(audioTrack);
            OnQueueUpdate();
        }

        public void MoveInQueue(int beforePosition, int newPosition)
        {
            // Convert to list
            List<Object> oldQueue = new List<Object>(playQueue.ToArray());
            Object trackToMove = oldQueue[beforePosition - 1];
            oldQueue.Remove(trackToMove);
            oldQueue.Insert(newPosition - 1, trackToMove);

            playQueue.Clear();
            foreach (Object obj in oldQueue)
            {
                playQueue.Enqueue((ITrack)obj);
            }

            // Tells subscribers that we have updated the queue
            OnQueueUpdate();
        }

        public void RemoveFromQueue(int position)
        {
            try
            {
                // Convert to list
                List<Object> oldQueue = new List<Object>(playQueue.ToArray());
                Object trackToRemove = oldQueue[position - 1];
                oldQueue.Remove(trackToRemove);

                playQueue.Clear();
                foreach (Object obj in oldQueue)
                {
                    playQueue.Enqueue((ITrack)obj);
                }
            }
            catch (IndexOutOfRangeException)
            {
                // Silently fail
            }
            OnQueueUpdate();
        }

        public bool IsPlaying
        {
            get
            {
                return playing;
            }
        }

        public TimeSpan TrackElapsed
        {
            get
            {
                return elapsedTime;
            }
        }
	}
}