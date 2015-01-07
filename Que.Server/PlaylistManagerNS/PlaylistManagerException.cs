using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Que.Server.PlaylistManagerNS
{
    class PlaylistManagerException : Exception
    {
        public PlaylistManagerException()
        { }

        public PlaylistManagerException(String message) 
            : base(message)
        {            
        }

        public PlaylistManagerException(String message, Exception innerException)
            : base(message, innerException)
        {         
        }
    }
}
