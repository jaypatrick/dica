#region using declarations

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using P = DigitallyImported.Resources.Properties;

#endregion

namespace DigitallyImported.Client
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            Text = String.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
            Icon = P.Resources.DIIconNew;
        }


        private void labelCompanyName_Click(object sender, EventArgs e)
        {
            Components.Utilities.StartProcess(
                string.Format("{0}{1}{2}", Uri.UriSchemeHttp, Uri.SchemeDelimiter, labelCompanyName.Text).Trim().ToLower
                    ());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Assembly Attibute Accessors

        /// <summary>
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != string.Empty)
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                return attributes.Length == 0
                           ? string.Empty
                           : ((AssemblyDescriptionAttribute) attributes[0]).Description;
                // If there is a Description attribute, return its value
            }
        }

        /// <summary>
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute) attributes[0]).Product;
                // If there is a Product attribute, return its value
            }
        }

        /// <summary>
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                return attributes.Length == 0 ? string.Empty : ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
                // If there is a Copyright attribute, return its value
            }
        }

        /// <summary>
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                return attributes.Length == 0 ? string.Empty : ((AssemblyCompanyAttribute) attributes[0]).Company;
                // If there is a Company attribute, return its value
            }
        }

        #endregion
    }
}