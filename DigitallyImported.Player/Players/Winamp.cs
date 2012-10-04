using System;
using System.Diagnostics;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using Microsoft.Win32;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class Winamp : Player, IWinamp, IPlayerFactory
    {
        private RegistryKey _winampKey;
        private string _winampPath = string.Empty;

        public Winamp()
            : base(PlayerTypes.Winamp)
        {

            // if (!IsInstalled) throw new PlayerNotInstalledException("Winamp Player is not installed");
        }

        #region IPlayer Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected override void Play(DigitallyImported.Components.IChannel channel)
        {
            var url = channel.CurrentTrack.TrackUrl;

            try
            {
                if (IsInstalled)
                {
                    ProcessStartInfo info = new ProcessStartInfo();

                    info.Arguments = ParseStreamUri(url).AbsoluteUri;

                    info.FileName = _winampPath;
                    info.UseShellExecute = false;

                    Components.Utilities.StartProcess(info);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override PlayerTypes PlayerType
        {
            get { return PlayerTypes.Winamp; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Icon PlayerIcon
        {
            get
            {
                return P.Resources.icon_winamp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsInstalled
        {
            get
            {
                _winampKey = Registry.LocalMachine.OpenSubKey(Settings.Default.WinampRegistryKeyWoW) == null
                    ? Registry.LocalMachine.OpenSubKey(Settings.Default.WinampRegistryKey)   // 64 bit
                    : Registry.LocalMachine.OpenSubKey(Settings.Default.WinampRegistryKeyWoW);     // 32 bit

                if (_winampKey != null)
                {
                    _winampPath = (string)_winampKey.GetValue(@"UninstallString");
                    _winampPath = _winampPath.Remove(_winampPath.LastIndexOf(@"\"));
                    _winampPath += @"\winamp.exe";
                    _winampPath = _winampPath.Insert(_winampPath.Length, new string(new char[] {'"'}));
                    return true;
                }

                else
                    return false;
            }
        }

        #endregion

        protected override Uri ParseStreamUri(Uri streamUri)
        {
            return streamUri;
        }
    }
}
