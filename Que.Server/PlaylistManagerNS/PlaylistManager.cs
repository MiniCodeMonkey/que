using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotiFire.SpotifyLib;
using Que.Server.Models;
using Que.Server.Properties;

namespace Que.Server.PlaylistManagerNS
{
    public class PlaylistManager
    {
        public static void CanEnqueue(Track track)
        {
            CheckQueueSize();

            if (Settings.Default.PlaylistManagerEnabled)
            {                
                CheckArtistThrottling(track);
                CheckSongFrequency(track);
            }
        }

         private static void CheckSongFrequency(Track track)
         {
            DateTime afterTime = DateTime.Now.Subtract(Settings.Default.SongFrequencyMinutes);
            IDataBase db = DataBase.GetInstance();
            if (!db.TrackInHistory(track.Name, afterTime))
            {
                throw new PlaylistManagerException("You cannot enqueue the song because it has been \n" +
                    "played within the last " + GetTime());
            }
         }

         private static String GetTime()
         {
             String time = String.Empty;

             if (Settings.Default.SongFrequencyMinutes.Hours == 0)
             {
                 time = Settings.Default.SongFrequencyMinutes.TotalMinutes + " min.";
             }
             else if (Settings.Default.SongFrequencyMinutes.Minutes == 0)
             {
                 time = Settings.Default.SongFrequencyMinutes.Hours + " hour";

                 if (Settings.Default.SongFrequencyMinutes.Hours == 1)
                     time += ".";
                 else
                     time += "s.";
             }
             else
             {
                 time = Settings.Default.SongFrequencyMinutes.Hours + " hours and " + Settings.Default.SongFrequencyMinutes.Minutes + " min.";
             }

             return time;
         }

         private static void CheckArtistThrottling(Track compareTrack)
         {
             int numberOfArtistInQueue = 0;
             int maxNumberOfArtistInQueue = Settings.Default.MaxNumberOfArtistInQueue;

                 foreach (ITrack track in Audio.AudioManager.Instance.PlayQueue)
                 {
                     if (track.Artists[0].Name.ToLower().Contains(compareTrack.Artists[0].Name.ToLower()) ||
                         compareTrack.Artists[0].Name.ToLower().Contains(track.Artists[0].Name.ToLower()))
                     {
                         numberOfArtistInQueue++;
                     }
                 }



                 if (maxNumberOfArtistInQueue <= numberOfArtistInQueue)
                 {
                     String s = " ";

                     if (numberOfArtistInQueue != 1)
                     {
                         s = "s ";
                     }

                     throw new PlaylistManagerException("The queue already contain" + s + numberOfArtistInQueue + " song" + s + "by " + compareTrack.Artists[0].Name);
                 }
                 else
                 {
                     return;
                 }
         }

        private static void CheckQueueSize()
        {
           int QueueSize = Settings.Default.QueueSize;
           int TracksInQueue = Audio.AudioManager.Instance.PlayQueue.Count;

           if (TracksInQueue < QueueSize)
           {
               return;
           }
           else
           {
               throw new PlaylistManagerException("The queue is full. Please try again later.");
           }
        }

        
    }
}
