using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Que.Server.PlaylistManagerNS
{
    interface IDataBase 
    {
        Boolean TrackInHistory(string artist, DateTime afterTime);
        void InsertToHistory(string trackName, string trackArtist);
    }
}
