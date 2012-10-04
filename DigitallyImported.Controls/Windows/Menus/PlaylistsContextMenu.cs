using System.ComponentModel;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PlaylistsContextMenu : BaseContextMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public PlaylistsContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public PlaylistsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SitesContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();
            Items.AddRange(new PlaylistView<PlaylistList>().GetView(true).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        public PlaylistTypes PlaylistType
        {
            get { return this._playlistType; }
        }
        private PlaylistTypes _playlistType;

        private void SitesContextMenu_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            _playlistType = ((PlaylistList)e.ClickedItem).PlaylistType;
        }
    }
}
