#region using declarations

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class PlayersContextMenu : BaseContextMenu
    {
        private PlayerType _playerType;

        /// <summary>
        /// </summary>
        public PlayersContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="container"> </param>
        public PlayersContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public PlayerType PlayerType
        {
            get { return _playerType; }
        }

        private void PlayersContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            int i = 0;
            foreach (string option in Enum.GetNames(typeof (PlayerType)))
            {
                Items.Add(Components.Utilities.CapitalizeFirstLetters(option));
                Items[i].Name = option;
                i++;
            }
        }

        private void PlayersContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _playerType = Utilities.ParseEnum<PlayerType>(e.ClickedItem.Name);
            Settings.Default.PlayerType = _playerType.ToString();
        }
    }
}