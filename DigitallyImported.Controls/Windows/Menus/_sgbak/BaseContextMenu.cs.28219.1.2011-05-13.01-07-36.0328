using System.ComponentModel;
using System.Windows.Forms;

namespace DigitallyImported.Utilities
{
    public partial class BaseContextMenu : ContextMenuStrip
    {
        public BaseContextMenu()
        {
            InitializeComponent();
        }

        public BaseContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        void copyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem myItem = (ToolStripMenuItem)sender;

            ContextMenuStrip myStrip = (ContextMenuStrip)myItem.Owner;

            Control clickedControl = (Control)(myStrip.SourceControl);

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
