using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;

using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components.Caching
{
    internal sealed class CacheSweeper
    {
        static CacheSweeper()
        {
            // monitor the size of the cache, and clear it out when necessary

            Settings.Default.SettingsSaving += new System.Configuration.SettingsSavingEventHandler(Default_SettingsSaving);
            InitializeTimer();
        }

        // if settings change, reset the timer
        static void Default_SettingsSaving(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InitializeTimer();
        }

        private static void InitializeTimer()
        {
            Timer timer = new Timer(Settings.Default.PlaylistRefreshInterval.TotalMilliseconds * 5);  // dump cache every 5 refreshes
            timer.AutoReset = true;

            timer.Stop();
            timer.Start();

            timer.Elapsed += delegate(object sender, ElapsedEventArgs e)
            {
                Trace.WriteLine(string.Format("Cache has {0} items: Sweeping cache.", Cache<string, object>.Count), TraceCategories.Caching.ToString());
                Cache<string, object>.Clear();
                Trace.WriteLine(string.Format("Cache sweeping complete: cache contains {0} items.", Cache<string, object>.Count), TraceCategories.Caching.ToString());
            };
        }
    }
}
