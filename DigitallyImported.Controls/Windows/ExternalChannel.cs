using System;
using DigitallyImported.Components;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Utilities.Windows
{
    public partial class ExternalChannel : DigitallyImported.Utilities.Channel, IExternalContent
    {
        public ExternalChannel()
        {
            // InitializeComponent();

            // LoadImages();
        }

        protected internal override void LoadImages()
        {
            this.picPlay.Image = P.Resources.icon_play;
        }

        #region IExternalContent Members

        public new Uri Location
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}

