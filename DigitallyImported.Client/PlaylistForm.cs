#region using declarations

using System;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using DigitallyImported.Client.Controls;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

#endregion

namespace DigitallyImported.Client
{
    public partial class PlaylistForm<TChannel, TTrack> : BaseForm
        where TChannel : UserControl, IChannel, new()
        where TTrack : UserControl, ITrack, new()
    {
        protected ContentControl<TChannel, TTrack> PlaylistContainer;
        private Size _size;

        //Type _playlistContainer = typeof(ContentControl<,>);
        //Type _workingType;

        /// <summary>
        /// </summary>
        public PlaylistForm()
        {
            PlaylistContainer = new ContentControl<TChannel, TTrack>();

            Application.ThreadException += Application_ThreadException;

            // use reflection to create the correct ContentControl type

            //Type[] premiumArgs = 
            //    {
            //        typeof(PremiumChannel), typeof(Track)
            //    };
            //Type[] regularArgs = 
            //    {
            //        typeof(Channel), typeof(Track)
            //    };

            //if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
            //{
            //    _workingType = _playlistContainer.MakeGenericType(premiumArgs);
            //}
            //else
            //{
            //    _workingType = _playlistContainer.MakeGenericType(regularArgs);
            //}

            //object o = Activator.CreateInstance(_workingType);

            InitializeComponent();
        }

        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    if (args.Length > 0)
        //    {
        //        // process command line args
        //        foreach (string arg in args)
        //        {
        //            switch (arg.Trim().ToLower())
        //            {
        //                case "/r":
        //                {
        //                    Settings.Default.Reset();
        //                    break;
        //                }
        //                default:
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    // global exception handler
        //    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

        //    Application.EnableVisualStyles();

        //    if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
        //    {
        //        Application.Run(new PlaylistForm<PremiumChannel, Track>());
        //    }
        //    else
        //    {
        //        Application.Run(new PlaylistForm<Channel, Track>());
        //    }
        //}

        private new static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var dirInfo = new DirectoryInfo(Application.ExecutablePath);
            var fileInfo =
                new FileInfo(string.Format("{0} {1}.{2}", "StackTrace", DateTime.Now.ToShortDateString(), ".txt"));
            TextWriter writer = fileInfo.CreateText();
            writer.WriteLine(e.Exception.StackTrace);
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged;
            UpdateNetworkStatus(NetworkInterface.GetIsNetworkAvailable());

            Location = Settings.Default.MainFormLocation;
            Text = Resources.Properties.Resources.ApplicationTitle;
            Icon = Resources.Properties.Resources.DIIconNew;

            foreach (Control control in Controls)
            {
                if (control is ContentControl<TChannel, TTrack>)
                {
                    _size = control.Size;
                    _size.Height += 55;
                    _size.Width += 8;
                    break;
                }
            }

            Size = _size;
            // this.ShowInTaskbar = true;
            KeyPreview = true;
            // this.Focus();
        }

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // ShowInTaskbar = this.WindowState == FormWindowState.Minimized ? false : true;
        }

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // PlayerLoader.Save(); // CHANGE THIS CLASS!
            Settings.Default.MainFormLocation = Location;
        }
    }
}