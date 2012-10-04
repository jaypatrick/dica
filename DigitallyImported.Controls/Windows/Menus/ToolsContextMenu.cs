using System.ComponentModel;

namespace DigitallyImported.Utilities
{
    public partial class ToolsContextMenu : BaseContextMenu
    {
        public ToolsContextMenu()
        {
            InitializeComponent();
        }

        public ToolsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
