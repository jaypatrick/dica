#region using declarations

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class PlayerList : ToolStripMenuItem
    {
        /// <summary>
        /// </summary>
        public PlayerList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="container"> </param>
        public PlayerList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}