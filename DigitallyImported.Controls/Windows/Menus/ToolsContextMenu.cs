#region using declarations

using System.ComponentModel;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class ToolsContextMenu : BaseContextMenu
    {
        /// <summary>
        /// </summary>
        public ToolsContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="container"> </param>
        public ToolsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}