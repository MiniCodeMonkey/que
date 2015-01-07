using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Drawing;
using Que.Server.Models;
using Que.Server.Audio;
using SpotiFire.SpotifyLib;

namespace Que.Server.Network
{
    class ClientConnection
    {
        private HttpListenerContext context = null;
        private XmlDocument doc = new XmlDocument();
        private static List<Track> searchHistory = new List<Track>();

        public ClientConnection(HttpListenerContext httpListenerContext)
        {
            this.context = httpListenerContext;
        }

        public void ProcessRequest()
        {
            try
            {
                String result = null;

                Uri requestUrl = context.Request.Url;

                if (requestUrl.Segments.Length <= 1)
                {
                    result = RequestInfo();
                }
                else
                {
                    XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(dec);

                    String action = requestUrl.Segments[1].Replace("/", "");

                    if (action == "NowPlaying")
                    {
                        result = RequestNowPlaying();
                    }
                    else if (action == "Queue")
                    {
                        result = RequestQueue();
                    }
                    else if (action == "Playlists")
                    {
                        result = RequestPlaylists();
                    }
                    else if (action == "Search")
                    {
                        if (requestUrl.Segments.Length >= 3)
                        {
                            result = RequestSearch(requestUrl.Segments[2].Replace("/", ""));
                        }
                        else
                        {
                            result = RequestError("Invalid parametrs");
                        }
                    }
                    else if (action == "Enqueue")
                    {
                        if (requestUrl.Segments.Length >= 3)
                        {
                            result = RequestEnqueue(requestUrl.Segments[2].Replace("/", ""));
                        }
                        else
                        {
                            result = RequestError("Invalid parametrs");
                        }
                    }
                    else if (action == "Image")
                    {
                        if (requestUrl.Segments.Length >= 3)
                        {
                            Bitmap image = AudioManager.Instance.GetImageSync(requestUrl.Segments[2].Replace("/", ""));
                            if (image != null)
                            {
                                context.Response.ContentType = "image/jpeg";

                                MemoryStream ms = new MemoryStream();
                                // Save to memory using the Jpeg format
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                                // read to end
                                byte[] bmpBytes = ms.GetBuffer();
                                image.Dispose();
                                ms.Close();

                                context.Response.OutputStream.Write(bmpBytes, 0, bmpBytes.Length);
                            }
                        }
                        else
                        {
                            result = RequestError("Invalid parametrs");
                        }
                    }
                    else
                    {
                        result = RequestError("Action does not exist");
                    }
                }

                if (result != null)
                {
                    byte[] data = Encoding.UTF8.GetBytes(result);
                    context.Response.ContentLength64 = data.Length;
                    context.Response.OutputStream.Write(data, 0, data.Length);
                }
                context.Response.OutputStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private String RequestInfo()
        {
            // Fetch Info.htm which is embedded as a ressource
            return global::Que.Server.Properties.Resources.Info;
        }

        private String RequestNowPlaying()
        {
            Track currentTrack = AudioManager.Instance.CurrentTrack;

            XmlElement root = doc.CreateElement("NowPlaying");
            doc.AppendChild(root);


            XmlElement status = doc.CreateElement("Status");

            if (currentTrack == null)
            {
                status.SetAttribute("Playing", "false");
            }
            else
            {
                status.SetAttribute("Playing", "true");

                XmlElement trackElement = GenerateTrackElement(currentTrack);

                status.AppendChild(trackElement);
            }

            status.SetAttribute("Elapsed", ((int)AudioManager.Instance.TrackElapsed.TotalSeconds).ToString());
            
            root.AppendChild(status);

            return doc.OuterXml;
        }

        private String RequestQueue()
        {
            XmlElement root = doc.CreateElement("Queue");
            doc.AppendChild(root);

            XmlElement tracksElement = doc.CreateElement("Tracks");

            int queuePosition = 1;
            foreach (ITrack track in AudioManager.Instance.PlayQueue)
            {
                XmlElement trackElement = GenerateTrackElement(new Track(track));

                XmlElement queuePositionElement = doc.CreateElement("QueuePosition");
                queuePositionElement.InnerText = queuePosition.ToString();
                trackElement.AppendChild(queuePositionElement);

                tracksElement.AppendChild(trackElement);

                queuePosition++;
            }

            root.AppendChild(tracksElement);

            return doc.OuterXml;
        }

        private String RequestPlaylists()
        {
            List<Playlist> playlists = AudioManager.Instance.GetPlaylists();

            if (playlists == null)
                playlists = new List<Playlist>();

            XmlElement root = doc.CreateElement("Playlists");
            doc.AppendChild(root);

            XmlElement availablePlaylists = doc.CreateElement("AvailablePlaylists");
            availablePlaylists.SetAttribute("Count", playlists.Count.ToString());
            root.AppendChild(availablePlaylists);

            foreach (Playlist playlist in playlists)
            {
                XmlElement playlistElement = doc.CreateElement("Playlist");

                XmlElement name = doc.CreateElement("Name");
                name.InnerText = (playlist.Name.Length <= 0) ? "Favorites" : playlist.Name;
                playlistElement.AppendChild(name);

                XmlElement link = doc.CreateElement("Link");
                link.InnerText = playlist.Id.ToString();
                playlistElement.AppendChild(link);

                XmlElement tracks = doc.CreateElement("Tracks");
                int n = 0;
                foreach (Track track in AudioManager.Instance.GetPlaylistTracks(playlist.Id))
                {
                    tracks.AppendChild(GenerateTrackElement(track));
                    n++;
                }

                tracks.SetAttribute("Count", n.ToString());

                playlistElement.AppendChild(tracks);

                availablePlaylists.AppendChild(playlistElement);
            }

            return doc.OuterXml;
        }

        private String RequestSearch(String query)
        {
            query = Uri.UnescapeDataString(query);

            Console.WriteLine("Search: " + query);

            // Search synchronously (i.e. block the current thread while searching)
            ISearch search = AudioManager.Instance.SearchSync(query);

            XmlElement root = doc.CreateElement("SearchResults");
            doc.AppendChild(root);

            XmlElement results = doc.CreateElement("Results");
            results.SetAttribute("Count", search.TotalTracks.ToString());
            root.AppendChild(results);

            // Generate a Track XML element for each result
            foreach (ITrack trackWrapper in search.Tracks)
            {
                Track track = new Track(trackWrapper);

                if (track.IsAvailable)
                {
                    searchHistory.Add(track);
                    results.AppendChild(GenerateTrackElement(track));
                }
            }

            return doc.OuterXml;
        }

        private String RequestEnqueue(String trackLink)
        {
            try
            {
                Track track = Track.GetById(new Guid(trackLink));
                AudioManager.Instance.AddToQueue(track.TrackObj);
                return RequestOK();
            }
            catch (PlaylistManagerNS.PlaylistManagerException ex)
            {
                return RequestError(ex.Message);
            }
            catch (Exception)
            {
                return RequestError("Track not found");
            }
        }

        /// <summary>
        /// Returns a XML response with an error message
        /// </summary>
        /// <param name="error">Error message to be shown</param>
        /// <returns></returns>
        private String RequestError(String error)
        {
            XmlElement root = doc.CreateElement("Result");
            doc.AppendChild(root);

            XmlElement status = doc.CreateElement("Status");
            root.AppendChild(status);

            XmlElement message = doc.CreateElement("Message");
            message.InnerText = error;
            status.AppendChild(message);

            return doc.OuterXml;
        }

        /// <summary>
        /// Returns a XML response with an OK result
        /// </summary>
        /// <returns></returns>
        private String RequestOK()
        {
            XmlElement root = doc.CreateElement("Result");
            doc.AppendChild(root);

            XmlElement status = doc.CreateElement("Status");
            root.AppendChild(status);

            XmlElement message = doc.CreateElement("Message");
            message.InnerText = "OK";
            status.AppendChild(message);

            return doc.OuterXml;
        }

        /// <summary>
        /// Returns an XML element for a given track
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        private XmlElement GenerateTrackElement(Track track)
        {
            XmlElement trackElement = doc.CreateElement("Track");

            XmlElement title = doc.CreateElement("Title");
            title.InnerText = track.Name;
            trackElement.AppendChild(title);

            String artistsStr = String.Empty;
            foreach (Artist artist in track.Artists)
            {
                artistsStr += artist.Name + ", ";
            }
            artistsStr = artistsStr.Substring(0, artistsStr.Length - 2);

            XmlElement artists = doc.CreateElement("Artists");
            artists.InnerText = artistsStr;
            trackElement.AppendChild(artists);

            XmlElement album = doc.CreateElement("Album");
            album.InnerText = track.Album;
            trackElement.AppendChild(album);

            XmlElement duration = doc.CreateElement("Duration");
            duration.InnerText = ((int)track.Length.TotalSeconds).ToString();
            trackElement.AppendChild(duration);

            XmlElement popularity = doc.CreateElement("Popularity");
            popularity.InnerText = track.Popularity.ToString();
            trackElement.AppendChild(popularity);

            XmlElement link = doc.CreateElement("Link");
            link.InnerText = track.Id.ToString();
            trackElement.AppendChild(link);

            XmlElement albumCoverId = doc.CreateElement("AlbumCoverId");
            albumCoverId.InnerText = track.AlbumCoverId;
            trackElement.AppendChild(albumCoverId);

            return trackElement;
        }
    }
}
