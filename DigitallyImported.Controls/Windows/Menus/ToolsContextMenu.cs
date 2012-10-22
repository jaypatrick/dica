using System.ComponentModel;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ToolsContextMenu : BaseContextMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolsContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public ToolsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}