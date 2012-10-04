using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using DigitallyImported.Client.Diagnostics;
using DigitallyImported.Configuration.Properties;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Client
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BaseForm : Form
    {
        // protected bool IsFormClosing = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

#if (DEBUG)
            // debug mode

            DebugConsole.Instance.Init(true, true);
#else
    // release mode
       DebugConsole.Instance.Init(false,true);
#endif

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // events
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomainUnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            Icon = Resources.Properties.Resources.DIIconNew;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            this.BeginInvoke(new System.Threading.WaitCallback(UpdateNetworkStatus), e.IsAvailable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
#if !DEBUG
            Trace.WriteLine(e.ToString());
#else
            Debug.WriteLine(e.ToString());
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //foreach (IComponent component in this.)
            //{
            //    if (component is NotifyIcon)
            //    {
            //        ((NotifyIcon)component).Visible = (!(this.ShowInTaskbar = this.WindowState == FormWindowState.Minimized ? false : true));
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
#if !DEBUG
            {
                // Application.Exit();
                Trace.WriteLine(e.Exception.ToString());
            }
#else
            {
                Trace.WriteLine(e.Exception.ToString());

                DialogResult result = MessageBox.Show(e.Exception.Message + Environment.NewLine
                    + e.Exception.StackTrace, e.Exception.GetType().ToString()
                    , MessageBoxButtons.AbortRetryIgnore
                    , MessageBoxIcon.Error
                    , MessageBoxDefaultButton.Button3
                        );

                switch (result)
                {
                    case DialogResult.Abort:
                    {
                        Application.Exit();
                        break;
                    }
                    case DialogResult.Retry:
                    {
                        Application.Restart();
                        break;
                    }
                    case DialogResult.Ignore:
                    {
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Application_ApplicationExit(object sender, EventArgs e)
        {
            Settings.Default.Save();
            Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected virtual void UpdateNetworkStatus(object state)
        {
            if ((bool)state)
            {
                this.Text = P.Resources.NetworkAvailable;
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                this.Text = Resources.Properties.Resources.NetworkConnectionError;
                this.Enabled = false; // DON"T DISABLE THE ENTIRE F'ING THING...and do this from the base form class.
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
            }
        }
    }
}
