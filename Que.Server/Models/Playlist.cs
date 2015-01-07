using System;
using System.Collections.Generic;
using SpotiFire.SpotifyLib;

namespace Que.Server.Models
{
    public enum PlaylistType
    {
        Playlist,
        FolderStart,
        FolderEnd
    }

    public class Playlist
    {
        private static Dictionary<Guid, Playlist> playlists = new Dictionary<Guid, Playlist>();
        private static Dictionary<IPlaylist, Guid> playlistIds = new Dictionary<IPlaylist, Guid>();

        public static Playlist GetById(Guid id)
        {
            return playlists[id];
        }

        public static Playlist Get(IPlaylist playlist)
        {
            if (playlistIds.ContainsKey(playlist))
                return GetById(playlistIds[playlist]);
            return new Playlist(playlist);
        }

        internal IPlaylist playlist;

        private Playlist(IPlaylist playlist)
        {
            this.playlist = playlist;
            Id = Guid.NewGuid();
            playlists.Add(Id, this);
            playlistIds.Add(playlist, Id);
        }

        public Guid Id { get; private set; }

        public PlaylistType Type
        {
            get
            {
                if (playlist is IContainerPlaylist)
                    switch (((IContainerPlaylist)playlist).Type)
                    {
                        case sp_playlist_type.SP_PLAYLIST_TYPE_START_FOLDER:
                            return PlaylistType.FolderStart;
                        case sp_playlist_type.SP_PLAYLIST_TYPE_END_FOLDER:
                            return PlaylistType.FolderEnd;
                    }
                return PlaylistType.Playlist;
            }
            set { }
        }

        public string Name
        {
            get
            {
                return playlist.Name;
            }
            set { }
        }

        public string Description
        {
            get
            {
                return playlist.Description;
            }
            set { }
        }

        public bool IsColaberativ
        {
            get
            {
                return playlist.IsColaberativ;
            }
            set { }
        }

        public string ImageId
        {
            get
            {
                return playlist.ImageId;
            }
            set { }
        }
    }
}
