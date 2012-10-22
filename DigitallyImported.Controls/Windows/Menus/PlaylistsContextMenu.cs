using System.ComponentModel;
using System.Windows.Forms;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PlaylistsContextMenu : BaseContextMenu
    {
        private StationType _playlistType;

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
        public StationType PlaylistType
        {
            get { return _playlistType; }
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

        private void SitesContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _playlistType = ((PlaylistList) e.ClickedItem).PlaylistType;
        }
    }
}