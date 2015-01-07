using SpotiFire.SpotifyLib;

namespace Que.Server.Models
{
    public class Artist
    {
        public Artist(IArtist artist)
        {
            this.Name = artist.Name;
            this.Link = artist.CreateLink().ToString();
        }

        public string Name { get; set; }

        public string Link { get; set; }
    }
}
