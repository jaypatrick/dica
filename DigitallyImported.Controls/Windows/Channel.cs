#region using declarations

using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    ///   Summary description for ChannelSection.
    /// </summary>
    [Serializable]
    [XmlRoot("RegularChannel")]
    public partial class Channel : UserControl, IChannel
    {
        internal static EventHandler<EventArgs> _elementMouseHover;
        private static readonly object _elementHoverLock = new object();
        internal static EventHandler<ChannelChangedEventArgs<IChannel>> _channelChanged;
        private static readonly object _channelChangedLock = new object();
        private readonly object _channelRefreshedLock = new object();
        private readonly object _historyClickedLock = new object();
        private readonly object _trackChangedLock = new object();
        internal EventHandler<TrackChangedEventArgs<ITrack>> _channelRefreshed;
        internal EventHandler<EventArgs> _historyClicked;
        internal EventHandler<TrackChangedEventArgs<ITrack>> _trackChanged;
        private Uri channelInfoUrl;
        private string channelName = string.Empty;
        private ITrack currentTrack;
        private bool isAlternating;
        private bool isSelected;
        private Uri playListHistoryUrl;
        private IPlaylist playlist;
        private StationType playlistType;
        private Icon siteIcon;
        private string siteName = string.Empty;
        private StreamType streamType;
        private StreamCollection<IStream> streams;
        private SubscriptionLevel subscriptionLevel;
        private TrackCollection<ITrack> tracks;

        /// <summary>
        /// </summary>
        public Channel()
            : this(StationType.Custom)
        {
        }


        /// <summary>
        /// </summary>
        /// <param name="PlaylistTypes"> </param>
        public Channel(StationType PlaylistTypes)
            // : base(PlaylistTypes)
        {
            InitializeComponent();
            PlaylistType = PlaylistTypes;
            LoadImages();

            // events
            Settings.Default.SettingChanging += ChannelSection_SettingChanging;
        }

        /// <summary>
        /// </summary>
        /// <param name="track"> </param>
        /// <returns> </returns>
        public virtual IChannel this[ITrack track]
        {
            get { return tracks[track.Name].ParentChannel; }
        }

        /// <summary>
        /// </summary>
        /// <param name="index"> </param>
        /// <returns> </returns>
        public virtual IChannel this[int index]
        {
            get { return tracks[index].ParentChannel; }
        }

        #region IChannel Members

        /// <summary>
        ///   Property to get/set the channel name
        /// </summary>
        [XmlAttribute("ChannelName")]
        public virtual string ChannelName
        {
            get { return channelName; }
            set
            {
                base.Name = value.Replace(" ", "").ToLower(); // unique key for control

                channelName = value;
                if (InvokeRequired)
                {
                    Invoke((Action) delegate
                        {
                            foreach (Control c in Controls)
                            {
                                c.Name += value.Replace(" ", "").ToLower();
                            }

                            toolTipLinks.SetToolTip(lblChannelName, value);
                            lblChannelName.Text = value;
                        });
                }
                else
                {
                    foreach (Control c in Controls)
                    {
                        c.Name += value.Replace(" ", "").ToLower();
                    }

                    toolTipLinks.SetToolTip(lblChannelName, value);
                    lblChannelName.Text = value;
                }
            }
        }

        /// <summary>
        /// </summary>
        [XmlElement("ChannelInfoUrl")]
        public virtual Uri ChannelInfoUrl
        {
            get { return channelInfoUrl; }
            set
            {
                channelInfoUrl = value;

                if (InvokeRequired)
                {
                    Invoke((Action) delegate
                        {
                            toolTipLinks.SetToolTip(lnkChannelInfo, value.AbsoluteUri);
                            lnkChannelInfo.Links[0].LinkData = value.AbsoluteUri;
                        });
                }
                else
                {
                    toolTipLinks.SetToolTip(lnkChannelInfo, value.AbsoluteUri);
                    lnkChannelInfo.Links[0].LinkData = value.AbsoluteUri;
                }
            }
        }

        /// <summary>
        /// </summary>
        [XmlElement("SiteName")]
        public virtual string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }

        /// <summary>
        /// </summary>
        [XmlElement("PlaylistHistoryUrl")]
        public virtual Uri PlaylistHistoryUrl
        {
            get { return playListHistoryUrl; }
            set
            {
                playListHistoryUrl = value;
                if (InvokeRequired)
                {
                    Invoke((Action) delegate
                        {
                            lnkPlaylistHistory.Links[0].LinkData = value.AbsoluteUri;
                            toolTipLinks.SetToolTip(lnkPlaylistHistory, value.AbsoluteUri);
                        });
                }
                else
                {
                    lnkPlaylistHistory.Links[0].LinkData = value.AbsoluteUri;
                    toolTipLinks.SetToolTip(lnkPlaylistHistory, value.AbsoluteUri);
                }
            }
        }

        /// <summary>
        /// </summary>
        [XmlElement("SiteIcon")]
        public virtual Icon SiteIcon
        {
            get { return siteIcon; }
            set
            {
                if (InvokeRequired)
                {
                    Invoke((Action) delegate { picSiteIcon.Image = value.ToBitmap(); });
                }
                else
                {
                    picSiteIcon.Image = value.ToBitmap();
                }
                siteIcon = value;
            }
        }

        /// <summary>
        /// </summary>
        [XmlElement("PlaylistType")]
        public virtual StationType PlaylistType
        {
            get { return playlistType; }
            set { playlistType = value; }
        }

        /// <summary>
        /// </summary>
        [XmlElement("SubscriptionLevel")]
        public virtual SubscriptionLevel SubscriptionLevel
        {
            get { return subscriptionLevel; }
            set { subscriptionLevel = value; }
        }

        /// <summary>
        /// </summary>
        [XmlElement("StreamType")]
        public virtual StreamType StreamType
        {
            get { return streamType; }
            set { streamType = value; }
        }

        /// <summary>
        /// </summary>
        [XmlArray("Streams")]
        public virtual StreamCollection<IStream> Streams
        {
            get { return streams; }
            set { streams = value; }
        }

        /// <summary>
        /// </summary>
        [XmlElement("Playlist")]
        public virtual IPlaylist Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }

        /// <summary>
        /// </summary>
        [XmlArray("Tracks")]
        public virtual TrackCollection<ITrack> Tracks
        {
            get { return tracks; }
            set
            {
                if (tracks != null)
                {
                    if (!currentTrack.TrackTitle.Equals(value[0].TrackTitle))
                    {
                        Trace.WriteLine(string.Format("Track changed on channel {0}", ChannelName),
                                        TraceCategory.ContentChangedEvents.ToString());
                        OnTrackChanged(this, new TrackChangedEventArgs<ITrack>(value[0]));
                    }
                }

                tracks = value;
                currentTrack = tracks[0];
                // update GUI...not very expensive

                if (InvokeRequired)
                {
                    Invoke((Action) SetValues);
                }
                else
                {
                    SetValues();
                }
            }
        }

        /// <summary>
        /// </summary>
        [XmlIgnore]
        public virtual ITrack CurrentTrack
        {
            get { return currentTrack; // CHANGE THIS PLEASE! should be the track marked as IsPlaying!
            }
        }

        /// <summary>
        /// </summary>
        [XmlIgnore]
        public virtual bool IsAlternating
        {
            get { return isAlternating; }
            set
            {
                isAlternating = value;
                if (InvokeRequired)
                {
                    Invoke(
                        (Action)
                        delegate
                            {
                                BackColor = value
                                                ? Settings.Default.AlternatingChannelBackground
                                                : Settings.Default.ChannelBackground;
                            });
                }
                else
                {
                    BackColor = value
                                    ? Settings.Default.AlternatingChannelBackground
                                    : Settings.Default.ChannelBackground;
                }
            }
        }

        /// <summary>
        /// </summary>
        [XmlElement("SelectedChannel")]
        public virtual bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                if (InvokeRequired)
                {
                    Invoke((Action) delegate
                        {
                            if (value)
                            {
                                BackColor = Settings.Default.SelectedChannelBackground;
                                Focus();
                            }
                            else
                            {
                                BackColor = isAlternating
                                                ? Settings.Default.AlternatingChannelBackground
                                                : Settings.Default.ChannelBackground;
                            }
                        });
                }
                else
                {
                    if (value)
                    {
                        BackColor = Settings.Default.SelectedChannelBackground;
                        Focus();
                    }
                    else
                    {
                        BackColor = isAlternating
                                        ? Settings.Default.AlternatingChannelBackground
                                        : Settings.Default.ChannelBackground;
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public event EventHandler<TrackChangedEventArgs<ITrack>> TrackChanged
        {
            add
            {
                lock (_trackChangedLock)
                {
                    {
                        _trackChanged += value;
                    }
                }
            }
            remove
            {
                lock (_trackChangedLock)
                {
                    _trackChanged -= value;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="other"> </param>
        /// <returns> </returns>
        public bool Equals(IContent other)
        {
            return Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion

        /// <summary>
        ///   Method to initialize the image controls.
        /// </summary>
        protected internal virtual void LoadImages()
        {
            pic24k.Image = Resources.Properties.Resources.blue_24k;
            pic32k.Image = Resources.Properties.Resources.blue_32k;
            pic96k.Image = Resources.Properties.Resources.blue_96k;
            picAacPlus.Image = Resources.Properties.Resources.icon_trans_aacplus;
            picMp3.Image = Resources.Properties.Resources.icon_mp3;
            picWmp.Image = Resources.Properties.Resources.icon_wm;
        }

        /// <summary>
        ///   Event to set the mouse cursor to hand upon entering a picture box
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> EventArgs </param>
        protected internal virtual void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

            var c = (Control) sender;
            string name = c.Name.ToLower();

            //switch (c.Name.ToLower().Substring(0, c.Name.Length - this.channelName.Replace(" ", "").Length))
            //{
            if (name.Contains("picmp3"))
            {
                toolTipLinks.SetToolTip(c, string.Format(siteName, Resources.Properties.Resources.MediaTypeMp3About));
                //break;
            }
            if (name.Contains("picwmp"))
            {
                toolTipLinks.SetToolTip(c, string.Format(siteName, Resources.Properties.Resources.MediaTypeWmaAbout));
                //break;
            }
            if (name.Contains("picaacplus"))
            {
                toolTipLinks.SetToolTip(c, string.Format(siteName, Resources.Properties.Resources.MediaTypeAacPlusAbout));
                //break;
            }

            // testing, delete and refactor
            if (name.Contains("pic24k"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetChannelUri(StreamType.AacPlus,
                                                                              siteName, channelName).AbsoluteUri);
                //break;
            }
            if (name.Contains("pic32k"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetChannelUri(StreamType.Wma,
                                                                              siteName, channelName).AbsoluteUri);
                //break;
            }
            if (name.Contains("pic96k"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetChannelUri(StreamType.Mp3,
                                                                              siteName, channelName).AbsoluteUri);
                //break;
            }
            // end testing

            //}
        }

        /// <summary>
        ///   Event to set the mouse cursor to arrow upon leaving a picture box
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> EventArgs </param>
        protected internal virtual void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
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
                    if (link.Name.Contains("lnkPlaylistHistory"))
                    {
                        OnPlaylistHistoryClicked(this, EventArgs.Empty);
                    }
                    else
                    {
                        Components.Utilities.StartProcess(e.Link.LinkData as string);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void ChannelSection_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            switch (e.SettingName)
            {
                case ("AlternatingChannelBackground"):
                    {
                        // this.IsAlternating = true;
                        break;
                    }
                case ("SelectedChannelBackground"):
                    {
                        // this.IsSelected = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void OnChannelChanged(object sender, ChannelChangedEventArgs<IChannel> e)
        {
            if (_channelChanged != null)
            {
                _channelChanged(sender, e);
            }
        }

        /// <summary>
        ///   Event to refresh the main page's playlist
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> EventArgs </param>
        protected internal virtual void OnChannelRefreshed(object sender, TrackChangedEventArgs<ITrack> e)
        {
            if (_channelRefreshed != null)
            {
                _channelRefreshed(this, e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> EventArgs </param>
        protected internal virtual void OnTrackChanged(object sender, TrackChangedEventArgs<ITrack> e)
        {
            if (_trackChanged != null)
            {
                _trackChanged(this, e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void OnPlaylistHistoryClicked(object sender, EventArgs e)
        {
            if (_historyClicked != null)
            {
                _historyClicked(this, e);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected internal virtual void Onee(object sender, CommentCountChangedEventArgs<IChannel> e)
        //{
        //    if (_ee != null)
        //    {
        //        _ee(this, e);
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void OnElementHover(object sender, PopupEventArgs e)
        {
            // TODO omplement
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return channelName;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void StreamType_MouseClick(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            // refactor into property -- TODO, break all inks into Uri's and use Uri methods to extract/build string
            Uri linkUri = null;
            // MediaType mediaType = MediaType.None;
            var c = (Control) sender;
            string name = c.Name.ToLower();

            //switch (c.Name.ToLower().Substring(0, c.Name.Length - this.channelName.Replace(" ", "").Length))
            //{
            if (name.Contains("pic24k"))
            {
                linkUri = Components.Utilities.GetChannelUri(StreamType.AacPlus, siteName, channelName);
                streamType = StreamType.AacPlus;
                //break;
            }
            if (name.Contains("pic32k"))
            {
                linkUri = Components.Utilities.GetChannelUri(StreamType.Wma, siteName, channelName);
                streamType = StreamType.Wma;
                //break;
            }
            if (name.Contains("pic96k"))
            {
                linkUri = Components.Utilities.GetChannelUri(StreamType.Mp3, siteName, channelName);
                streamType = StreamType.Mp3;
                //break;
            }
            if (name.Contains("picmp3"))
            {
                Components.Utilities.StartProcess(string.Format(siteName,
                                                                Resources.Properties.Resources.MediaTypeMp3About));
                //break;
            }
            if (name.Contains("picwmp"))
            {
                Components.Utilities.StartProcess(string.Format(siteName,
                                                                Resources.Properties.Resources.MediaTypeWmaAbout));
                //break;
            }
            if (name.Contains("picaac"))
            {
                Components.Utilities.StartProcess(string.Format(siteName,
                                                                Resources.Properties.Resources.MediaTypeAacPlusAbout));
                //break;
            }
            //}
            // testing
            currentTrack.TrackUrl = linkUri; // NEED TO SET THIS VALUE EARLIER
            c.Tag = linkUri != null ? linkUri.AbsoluteUri : string.Empty;

            if (e.Button == MouseButtons.Left)
                OnChannelChanged(this, new ChannelChangedEventArgs<IChannel>(this));
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public event EventHandler<TrackChangedEventArgs<ITrack>> ChannelRefreshed
        {
            add
            {
                lock (_channelRefreshedLock)
                {
                    {
                        _channelRefreshed += value;
                    }
                }
            }
            remove
            {
                lock (_channelRefreshedLock)
                {
                    _channelRefreshed -= value;
                }
            }
        }


        /// <summary>
        /// </summary>
        // todo refactor this out into it's own EventArgs class, pass link as e.Message
        [Browsable(true)]
        public static event EventHandler<EventArgs> ElementMouseHover
        {
            add
            {
                lock (_elementHoverLock)
                {
                    _elementMouseHover += value;
                }
            }
            remove
            {
                lock (_elementHoverLock)
                {
                    _elementMouseHover -= value;
                }
            }
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public static event EventHandler<ChannelChangedEventArgs<IChannel>> ChannelChanged
        {
            add
            {
                lock (_channelChangedLock)
                {
                    _channelChanged += value;
                }
            }
            remove
            {
                lock (_channelChangedLock)
                {
                    _channelChanged -= value;
                }
            }
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public event EventHandler<EventArgs> PlaylistHistoryClicked
        {
            add
            {
                lock (_historyClickedLock)
                {
                    _historyClicked += value;
                }
            }
            remove
            {
                lock (_historyClickedLock)
                {
                    _historyClicked -= value;
                }
            }
        }

        /// <summary>
        /// </summary>
        public virtual void LoadUI()
        {
            if (currentTrack == null)
                throw new InvalidOperationException("Channel control must have a valid Track collection");

            if (currentTrack != null)
            {
                if (InvokeRequired)
                {
                    Invoke((Action) SetValues);
                }
                else
                {
                    SetValues();
                }
            }

            // base.OnLoad(e);
        }

        private void SetValues()
        {
            ITrack track = CurrentTrack;

            // track title
            toolTipLinks.SetToolTip(lnkTrackTitle, track.TrackTitle);
            lnkTrackTitle.Text = track.TrackTitle;

            // comment count
            lnkPostComments.Text = string.Format("Read and Post Comments {0}{1} {2}{3}", "(", track.CommentCount,
                                                 "comments", ")");

            // forum url
            if (track.ForumUrl != null)
            {
                lnkPostComments.Links[0].LinkData = track.ForumUrl.AbsoluteUri;
                toolTipLinks.SetToolTip(lnkPostComments, track.ForumUrl.AbsoluteUri);
            }

            // artist homepage link
            if (track.ArtistUri != null)
            {
                lnkTrackTitle.Links[0].LinkData = track.ArtistUri.AbsoluteUri;
                lnkTrackTitle.LinkBehavior = LinkBehavior.AlwaysUnderline;
                lnkTrackTitle.LinkColor = Color.RoyalBlue;
                toolTipLinks.SetToolTip(lnkTrackTitle, track.ArtistUri.AbsoluteUri);
            }

            // record label
            if (track.RecordLabel != null)
                lblRecordLabel.Text = track.RecordLabel;

            // the url to the track (what is this?)
            Uri trackUrl;
            if (track.TrackUrl != null)
                trackUrl = track.TrackUrl;

            // time the track started
            DateTime startTime = track.StartTime.AddMinutes(Settings.Default.TrackStartTimeOffset);
            StartTimeLabel.Text = string.Format("{0} {1}", "Started at", startTime.ToShortTimeString());
        }
    }
}