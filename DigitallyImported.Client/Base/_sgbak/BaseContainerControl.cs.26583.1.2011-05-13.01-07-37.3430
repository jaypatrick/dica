using System;
using System.Windows.Forms;

namespace DigitallyImported.Client.Controls
{
    public partial class BaseContainerControl : UserControl
    {
        public BaseContainerControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ParentForm.Text = Resources.Properties.Resources.ApplicationTitle;
            this.ParentForm.Icon = Resources.Properties.Resources.DIIconNew;
        }
    }
}
