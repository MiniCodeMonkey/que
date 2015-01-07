using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using SpotiFire.SpotifyLib;

namespace Que.Server.Models
{
    public class Track
    {
        private static Dictionary<Guid, Track> tracks = new Dictionary<Guid, Track>();
        private static Dictionary<ITrack, Guid> trackIds = new Dictionary<ITrack, Guid>();

        public static Track GetById(Guid id)
        {
            return tracks[id];
        }

        public static Track Get(ITrack track)
        {
            if (trackIds.ContainsKey(track))
                return GetById(trackIds[track]);
            return new Track(track);
        }

        public Guid Id { get; private set; }

        public Track(ITrack track)
        {
            while (!track.IsLoaded)
            {
                System.Threading.Thread.Sleep(500);
            }

            Name = track.Name;
            Artists = track.Artists.Select(a => new Artist(a)).ToArray();
            Album = track.Album.Name;
            Length = track.Duration;
            IsAvailable = track.IsAvailable;
            Popularity = track.Popularity;
            IsStarred = track.IsStarred;
            AlbumCoverId = track.Album.CoverId;
            TrackObj = track;

            // Generate GUID
            if (!trackIds.ContainsKey(track))
            {
                Id = Guid.NewGuid();
                tracks.Add(Id, this);
                trackIds.Add(track, Id);
            }
            else
            {
                Id = trackIds[track];
            }
        }

        public string Name { get; set; }

        public Artist[] Artists { get; set; }

        public string Album { get; set; }

        public TimeSpan Length { get; set; }

        public bool IsAvailable { get; set; }

        public int Popularity { get; set; }

        public bool IsStarred { get; set; }

        public string AlbumCoverId { get; set; }

        public ITrack TrackObj { get; set; }
    }
}
