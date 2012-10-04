using System.ComponentModel;
using System.Windows.Forms;

namespace DigitallyImported.Utilities
{
    public partial class PlayerList : ToolStripMenuItem
    {
        public PlayerList()
        {
            InitializeComponent();
        }

        public PlayerList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
