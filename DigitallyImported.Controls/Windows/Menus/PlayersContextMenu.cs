using System;
using System.ComponentModel;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Utilities.Windows.Menus
{
    public partial class PlayersContextMenu : BaseContextMenu
    {
        public PlayersContextMenu()
        {
            InitializeComponent();
        }

        public PlayersContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void PlayersContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            int i = 0;
            foreach (string option in Enum.GetNames(typeof(PlayerTypes)))
            {
                Items.Add(DigitallyImported.Components.Utilities.CapitalizeFirstLetters(option));
                Items[i].Name = option;
                i++;
            }
        }

        private void PlayersContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _playerType = Utilities.ParseEnum<PlayerTypes>(e.ClickedItem.Name);
            Settings.Default.PlayerType = _playerType.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerTypes PlayerType
        {
            get { return this._playerType; }
        }
        private PlayerTypes _playerType;

    }
}
