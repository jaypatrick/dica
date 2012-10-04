using System;
using System.Drawing;
using System.Windows.Forms;

using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PlaylistList : ToolStripMenuItem, DigitallyImported.Components.IPlaylist
    {
        /// <summary>
        /// 
        /// </summary>
        public PlaylistList()
        {
            InitializeComponent();
            // this.Text = Name;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Image Image
        {
            get
            {
                return PlaylistIcon;
            }
        }

        #region ISite Members

        /// <summary>
        /// 
        /// </summary>
        public Uri SiteUri
        {
            get
            {
                return _siteUri;
            }
            set
            {
                _siteUri = value;
            }
        }
        private Uri _siteUri = null;

        /// <summary>
        /// 
        /// </summary>
        public Bitmap PlaylistIcon
        {
            get
            {
                return _siteIcon;
            }
            set
            {
                _siteIcon = value;
            }
        }
        private Bitmap _siteIcon;

        /// <summary>
        /// 
        /// </summary>
        public ChannelCollection<IChannel> SiteChannels
        {
            get
            {
                return _siteChannels;
            }
            set
            {
                _siteChannels = value;
            }
        }
        private ChannelCollection<IChannel> _siteChannels;

        /// <summary>
        /// 
        /// </summary>
        public EventCollection<IEvent> SiteEvents
        {
            get
            {
                return _siteEvents;
            }
            set
            {
                _siteEvents = value;
            }
        }
        private EventCollection<IEvent> _siteEvents;

        #endregion

        #region IContent Members

        /// <summary>
        /// 
        /// </summary>
        public PlaylistTypes PlaylistType
        {
            get
            {
                return _PlaylistType;
            }
            set
            {
                _PlaylistType = value;
            }
        }
        private PlaylistTypes _PlaylistType;

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
            }
        }
        private bool _isSelected;


        public SubscriptionLevel SubscriptionLevel
        {
            get
            {
                return this._subscriptionLevel;
            }
            set
            {
                this._subscriptionLevel = value;
            }
        }
        private SubscriptionLevel _subscriptionLevel;


        #endregion

        #region IEquatable<IContent> Members

        public bool Equals(IContent other)
        {
            return this.Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}
