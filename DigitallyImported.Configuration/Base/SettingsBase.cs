#region using declarations

using System.ComponentModel;
using System.Configuration;
using DigitallyImported.Configuration.Properties;

#endregion

namespace DigitallyImported.Configuration
{
    public class SettingsBase : Settings
    {
        public SettingsBase()
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            SettingChanging += SettingChangingEventHandler;
            //
            SettingsSaving += SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
            // Add code to handle the SettingChangingEvent event here.
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
            // Add code to handle the SettingsSaving event here.
        }
    }
}