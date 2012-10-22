using System.ComponentModel;
using System.Windows.Forms;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TChannel"></typeparam>
    public partial class ChannelsContextMenu<TChannel> : BaseContextMenu
        where TChannel : class, IChannel, new()
    {
        private ChannelCollection<TChannel> _channels;
        private IChannel _selectedChannel;

        /// <summary>
        /// 
        /// </summary>
        public ChannelsContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public ChannelsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public IChannel SelectedChannel
        {
            get { return _selectedChannel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ChannelCollection<TChannel> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public StationType PlaylistType { get; set; }

        private void ChannelsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear(); // SPLIT BUTTON

            if (_channels != null)
            {
                _channels.ForEach(channel => // cached channelCollection
                    {
                        int i = 0;
                        Items.Add(channel.ChannelName, channel.SiteIcon.ToBitmap());
                        Items[i].Name = channel.Name; // KEY EACH ITEM OFF OF NAME
                        ++i;
                    });
            }
        }

        private void ChannelsContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _selectedChannel = _channels[e.ClickedItem.Text.Replace(" ", "").ToLower().Trim()];
        }
    }
}