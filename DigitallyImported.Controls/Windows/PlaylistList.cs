#region using declarations

using System;
using System.Drawing;
using System.Windows.Forms;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class PlaylistList : ToolStripMenuItem, IPlaylist
    {
        /// <summary>
        /// </summary>
        public PlaylistList()
        {
            InitializeComponent();
            // this.Text = Name;
        }

        /// <summary>
        /// </summary>
        public override string Text
        {
            get { return base.Name; }
        }

        /// <summary>
        /// </summary>
        public override Image Image
        {
            get { return PlaylistIcon; }
        }

        #region IPlaylist Members

        /// <summary>
        /// </summary>
        public Uri SiteUri { get; set; }

        /// <summary>
        /// </summary>
        public Bitmap PlaylistIcon { get; set; }

        /// <summary>
        /// </summary>
        public ChannelCollection<IChannel> SiteChannels { get; set; }

        /// <summary>
        /// </summary>
        public EventCollection<IEvent> SiteEvents { get; set; }

        /// <summary>
        /// </summary>
        public StationType PlaylistType { get; set; }

        /// <summary>
        /// </summary>
        public bool IsSelected { get; set; }


        /// <summary>
        /// </summary>
        public SubscriptionLevel SubscriptionLevel { get; set; }

        public bool Equals(IContent other)
        {
            return Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}