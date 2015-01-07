using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Que.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (OutToFile redir = new OutToFile("log.txt"))
            {
                // Start HTTP REST service
                // This allows client to connect to the jukebox to send request
                // and receive information about queue, now playing, etc.
                new Thread(new Network.Server().Start).Start();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
