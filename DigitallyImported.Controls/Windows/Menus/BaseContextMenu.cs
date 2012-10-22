using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitallyImported.Utilities
{
    public partial class BaseContextMenu : ContextMenuStrip
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public BaseContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myItem = (ToolStripMenuItem) sender;

            var myStrip = (ContextMenuStrip) myItem.Owner;

            Control clickedControl = (myStrip.SourceControl);

            // Clipboard.SetText(clickedControl.Tag != null ? (string)clickedControl.Tag : string.Empty, TextDataFormat.Text);

            //if (clickedControl.Text != string.Empty || clickedControl.Text != null)
            //{
            //    Clipboard.SetDataObject(clickedControl.Text, true);
            //}
            if (clickedControl.Tag != null)
            {
                Clipboard.SetDataObject(clickedControl.Tag, true);
            }
        }

        private void BaseContextMenu_Opening(object sender, CancelEventArgs e)
        {
        }
    }
}