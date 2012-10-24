#region using declarations

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    public partial class Track : UserControl, ITrack
    {
        private static int _counter = 1;
        private readonly object _eeLock = new object();
        private int _commentCount = -1;
        internal EventHandler<CommentCountChangedEventArgs<ITrack>> _ee;
        private string _trackTitle;

        /// <summary>
        /// </summary>
        public Track()
        {
            InitializeComponent();

            _counter = 1;
        }

        /// <summary>
        /// </summary>
        public virtual TimeZone PlaylistTimeZone
        {
            get
            {
                TimeZone tz = TimeZone.CurrentTimeZone;
                return tz;
            }
        }

        #region ITrack Members

        /// <summary>
        /// </summary>
        public virtual IChannel ParentChannel { get; set; }

        /// <summary>
        /// </summary>
        public virtual string TrackTitle
        {
            get { return _trackTitle; }
            set
            {
                _trackTitle = value;
                Name = value.Replace(" ", "").ToLower();
            }
        }


        /// <summary>
        /// </summary>
        public virtual string ArtistName { get; set; }


        /// <summary>
        /// </summary>
        public virtual DateTime StartTime { get; set; }


        /// <summary>
        /// </summary>
        public virtual string SongName { get; set; }

        /// <summary>
        /// </summary>
        public virtual Uri ArtistUri { get; set; }

        /// <summary>
        /// </summary>
        public virtual Uri ForumUrl { get; set; }

        /// <summary>
        /// </summary>
        public virtual Uri TrackUrl { get; set; }

        /// <summary>
        /// </summary>
        public virtual string RecordLabel { get; set; }

        /// <summary>
        /// </summary>
        public virtual int CommentCount
        {
            get { return _commentCount; }
            set
            {
                if (_commentCount >= 0 && _commentCount < value)
                {
                    Trace.WriteLine(string.Format("Comment count changed on channel {0}", ParentChannel.ChannelName),
                                    TraceCategory.ContentChangedEvents.ToString());
                    Onee(this, new CommentCountChangedEventArgs<ITrack>(this, value));
                }

                _commentCount = value;
            }
        }

        /// <summary>
        /// </summary>
        public virtual bool IsPlaying { get; set; }

        /// <summary>
        /// </summary>
        public new virtual string Name { get; set; }

        /// <summary>
        /// </summary>
        public virtual StationType PlaylistType { get; set; }

        /// <summary>
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool IsSelected { get; set; }

        public bool Equals(IContent other)
        {
            return Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public event EventHandler<CommentCountChangedEventArgs<ITrack>> ee
        {
            add
            {
                lock (_eeLock)
                {
                    _ee += value;
                }
            }
            remove
            {
                lock (_eeLock)
                {
                    _ee -= value;
                }
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (this != null) // design time support
            {
                lblRecordLabel.Text = RecordLabel;

                lnkPostComments.Text = string.Format("Read and Post Comments {0}{1} {2}{3}", "(", CommentCount,
                                                     "comments", ")");
                lnkPostComments.Links[0].LinkData = ForumUrl.AbsoluteUri;
                toolTipLinks.SetToolTip(lnkPostComments, ForumUrl.AbsoluteUri);

                toolTipLinks.SetToolTip(lnkTrackTitle, TrackTitle);
                lnkTrackTitle.Text = TrackTitle;

                lnkCounter.Text = _counter.ToString();

                //DateTime startTime = this.StartTime.AddMinutes(Settings.Default.TrackStartTimeOffset);
                //this.StartTimeLabel.Text = string.Format("{0}", startTime.ToShortTimeString());
            }

            base.OnLoad(e);

            _counter++;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return TrackTitle;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = sender as LinkLabel;

            if (link != null)
            {
                link.Tag = e.Link.LinkData ?? link.Text;
                if (e.Button == MouseButtons.Left)
                {
                    //if (link.Name.Contains("lnkPlaylistHistory"))
                    //{
                    //    OnPlaylistHistoryClicked(this, EventArgs.Empty);
                    //}
                    //else
                    //{
                    Components.Utilities.StartProcess(e.Link.LinkData as string);
                    //}
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void Onee(object sender, CommentCountChangedEventArgs<ITrack> e)
        {
            if (_ee != null)
            {
                _ee(this, e);
            }
        }
    }
}