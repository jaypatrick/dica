#region using declarations

using System;
using System.Diagnostics;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Controls.Windows;

#endregion

namespace DigitallyImported.Client
{
    /// <summary>
    /// </summary>
    public class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // process command line args
                foreach (var arg in args)
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

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            try
            {
                if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
                {
                    Application.Run(new PlaylistForm<PremiumChannel, Track>());
                }
                else
                {
                    Application.Run(new PlaylistForm<Channel, Track>());
                }
            }
            catch (Exception exc)
            { 
                Trace.WriteLine(string.Format("{0} /r/n {1}", exc.StackTrace, exc.TargetSite));
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Trace.WriteLine(string.Format("{0} /r/n {1}", e.Exception.StackTrace, e.Exception.TargetSite));
        }
    }
}