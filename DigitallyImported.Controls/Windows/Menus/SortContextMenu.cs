using System;
using System.ComponentModel;
using System.Windows.Forms;
using DigitallyImported.Components;
using SortOrder = DigitallyImported.Components.SortOrder;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SortContextMenu : BaseContextMenu
    {
        private SortBy _sortBy;
        private bool _sortFlip;
        private SortOrder _sortOrder;


        /// <summary>
        /// 
        /// </summary>
        public SortContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public SortContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public SortBy SortBy
        {
            get { return _sortBy; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        private void SortContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            int i = 0;
            foreach (string option in Enum.GetNames(typeof (SortBy)))
            {
                Items.Add(Components.Utilities.CapitalizeFirstLetters(option));
                Items[i].Name = option;
                i++;
            }
        }

        private void SortContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _sortBy = Utilities.ParseEnum<SortBy>(e.ClickedItem.Name);
        }

        private void SortContextMenu_Click(object sender, EventArgs e)
        {
            //if ((_channelView.SortOrder & SortOrder.Ascending) == SortOrder.Ascending)
            //{
            //    _sortOrder = SortOrder.Descending;
            //    return;
            //}

            //if ((_channelView.SortOrder & SortOrder.Descending) == SortOrder.Descending)
            //{
            //    _sortOrder = SortOrder.Ascending;
            //    return;
            //}

            _sortOrder = _sortFlip ? SortOrder.Descending : SortOrder.Ascending;

            _sortFlip = !_sortFlip;
        }
    }
}