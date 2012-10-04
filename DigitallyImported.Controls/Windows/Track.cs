using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    public partial class Track : UserControl, ITrack
    {
        private static int _counter = 1;

        /// <summary>
        /// 
        /// </summary>
        public Track()
        {
            InitializeComponent();

            _counter = 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this != null) // design time support
            {
                this.lblRecordLabel.Text = this.RecordLabel;
                
                this.lnkPostComments.Text = string.Format("Read and Post Comments {0}{1} {2}{3}", "(", this.CommentCount, "comments", ")");
                this.lnkPostComments.Links[0].LinkData = this.ForumUrl.AbsoluteUri as string;
                toolTipLinks.SetToolTip(this.lnkPostComments, this.ForumUrl.AbsoluteUri);

                toolTipLinks.SetToolTip(this.lnkTrackTitle, this.TrackTitle);
                this.lnkTrackTitle.Text = this.TrackTitle;
                
                this.lnkCounter.Text = _counter.ToString();

                //DateTime startTime = this.StartTime.AddMinutes(Settings.Default.TrackStartTimeOffset);
                //this.StartTimeLabel.Text = string.Format("{0}", startTime.ToShortTimeString());
            }

            base.OnLoad(e);

            _counter++;
        }

        # region ITrack Members

        private IChannel _channel;

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel ParentChannel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        private string _trackTitle;
        /// <summary>
        /// 
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


        private string _artistName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }


        private DateTime _startTime;

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual TimeZone PlaylistTimeZone
        {
            get
            {
                TimeZone tz = TimeZone.CurrentTimeZone;
                return tz;
            }
        }

        private string _trackName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string SongName
        {
            get { return _trackName; }
            set { _trackName = value; }
        }
        private Uri _artistUri;

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri ArtistUri
        {
            get { return _artistUri; }
            set { _artistUri = value; }
        }
        private Uri _forumUrl;

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri ForumUrl
        {
            get { return _forumUrl; }
            set { _forumUrl = value; }
        }
        private Uri _trackUrl;

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri TrackUrl
        {
            get { return _trackUrl; }
            set { _trackUrl = value; }
        }
        private string _recordLabel;

        /// <summary>
        /// 
        /// </summary>
        public virtual string RecordLabel
        {
            get { return _recordLabel; }
            set { _recordLabel = value; }
        }
        private int _commentCount = -1;

        /// <summary>
        /// 
        /// </summary>
        public virtual int CommentCount
        {
            get { return _commentCount; }
            set 
            {
                if (_commentCount >= 0 && _commentCount < value)
                {
                    Trace.WriteLine(string.Format("Comment count changed on channel {0}", this.ParentChannel.ChannelName), TraceCategories.ContentChangedEvents.ToString());
                    this.Onee(this, new eeEventArgs<ITrack>(this, value));
                    
                }

                _commentCount = value; 
            }
        }
        private bool _isPlaying = false;

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; }
        }

        # endregion

        # region IContent Members

        private string _name;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private PlaylistTypes _playlistType;

        /// <summary>
        /// 
        /// </summary>
        public virtual PlaylistTypes PlaylistType
        {
            get { return _playlistType; }
            set { _playlistType = value; }
        }
        private SubscriptionLevel _subscriptionLevel;   // this should be at the site level, not channel or content

        /// <summary>
        /// 
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel
        {
            get { return _subscriptionLevel; }
            set { _subscriptionLevel = value; }
        }
        private bool _isSelected;

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        # endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TrackTitle;
        }

        #region IEquatable<IContent> Members

        public bool Equals(IContent other)
        {
            return this.Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;

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
                        DigitallyImported.Components.Utilities.StartProcess(e.Link.LinkData as string);
                    //}
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void Onee(object sender, eeEventArgs<ITrack> e)
        {
            if (_ee != null)
            {
                _ee(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public event EventHandler<eeEventArgs<ITrack>> ee
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
        internal EventHandler<eeEventArgs<ITrack>> _ee;
        private readonly object _eeLock = new object();

    }
}
