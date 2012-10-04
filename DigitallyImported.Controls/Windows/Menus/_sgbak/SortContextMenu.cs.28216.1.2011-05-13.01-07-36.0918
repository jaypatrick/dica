using System;
using System.ComponentModel;
using System.Windows.Forms;

using DigitallyImported.Components;
using SortOrder = DigitallyImported.Components.SortOrder;

namespace DigitallyImported.Utilities
{
    public partial class SortContextMenu : BaseContextMenu
    {
        private bool sortFlip = false;


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

        private void SortContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            int i = 0;
            foreach (string option in Enum.GetNames(typeof(SortBy)))
            {
                Items.Add(DigitallyImported.Components.Utilities.CapitalizeFirstLetters(option));
                Items[i].Name = option;
                i++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SortBy SortBy
        {
            get { return this._sortBy; }
        }
        private SortBy _sortBy;

        /// <summary>
        /// 
        /// </summary>
        public SortOrder SortOrder
        {
            get { return this._sortOrder; }
        }
        private SortOrder _sortOrder;

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

            if (sortFlip)
            {
                _sortOrder = SortOrder.Descending;
            }
            else
            {
                _sortOrder = SortOrder.Ascending;
            }

            sortFlip = !sortFlip;
        }
    }
}
