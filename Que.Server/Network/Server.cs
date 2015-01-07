using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Mono.Zeroconf;

namespace Que.Server.Network
{
    class Server
    {
        public Server()
        {
        
        }

        public void Start()
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://*:7879/");

            try
            {
                httpListener.Start();
            }
            catch (HttpListenerException)
            {
                // This probably happened because permission was denied, we need to
                // rerun as administrator

                // Find current exe name (do not pick .vshost exe file if we are debugging)
                String appName = Process.GetCurrentProcess().ProcessName;
                appName = appName.Replace(".vshost", "") + ".exe";

                var startInfo = new ProcessStartInfo(appName) { Verb = "runas" };
                Process.Start(startInfo);
                Environment.Exit(0);
            }

            Timer timer = new Timer(new TimerCallback(AnnounceTimerCallback), null, 0, 60000 * 15);

            while (true)
            {
                HttpListenerContext httpListenerContext = httpListener.GetContext();
                new Thread(new ClientConnection(httpListenerContext).ProcessRequest).Start();
            }
        }

        private void AnnounceTimerCallback(Object stateObject)
        {
            // Announce service using zeroconf
            RegisterService service = new RegisterService();
            service.Name = "Que Jukebox";
            service.RegType = "_que._tcp";
            service.ReplyDomain = "local.";
            service.Port = 7879;
            service.Register();
            Console.WriteLine("Announced server via bonjour");
        }
    }
}
