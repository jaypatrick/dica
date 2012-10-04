using System;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Utilities;

namespace DigitallyImported.Client
{


    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // process command line args
                foreach (string arg in args)
                {
                    switch (arg.Trim().ToLower())
                    {
                        case "/r":
                            {
                                Settings.Default.Reset();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }

            // global exception handler
            // Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();

            if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
            {
                Application.Run(new PlaylistForm<PremiumChannel, Track>());
            }
            else
            {
                Application.Run(new PlaylistForm<Channel, Track>());
            }
        }
    }
}
