using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DigitallyImported.Configuration.Properties;
using DigitallyImported.Resources.Properties;

using VbPowerPack;
using System.Diagnostics;
// using DigitallyImported.Data;

namespace DigitallyImported.Scripts
{
    public class Program
    {
        static string CRLF = "\n \r";

        static void Main(string[] args)
        {
            

            Console.WriteLine(string.Format("{0}{1}", "Please choose from the following options: ", CRLF));
            Console.WriteLine(string.Format("{0}{1}", "1: Reset Application Configuration Defaults ", CRLF));
            Console.WriteLine(string.Format("{0}{1}", "2: Test VBPowerPack Toast Module. ", CRLF));
            Console.Write("Numeric Choice: ");

            switch (Console.ReadLine().Trim())
            {
                case ("1"):
                    {
                        ResetConfigurationDefaults();
                        break;
                    }
                case ("2"):
                    {
                        NotificationWindow toast = new NotificationWindow();
                        toast.Click += new NotificationWindow.ClickEventHandler(toast_Click);
                        toast.TextIsHyperLink = true;
                        toast.ShowStyle = NotificationShowStyle.Slide;
                        // toast.CornerImage = Resources.Properties.Resources.DIIcon.ToBitmap();
                        toast.CloseButton = true;
                        toast.Notify("This is some C# toast! ", 10000);
                        Console.ReadLine();
                        break;
                    }
            }
        }

        static void toast_Click(object sender, EventArgs e)
        {
            Process.Start("http://jaysonknight.com/");
        }

        static void ResetConfigurationDefaults()
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            Console.WriteLine("Application configuration defaults reset. ");
        }
    }
}
