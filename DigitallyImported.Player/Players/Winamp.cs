#region using declarations

using System;
using System.Diagnostics;
using System.Drawing;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using Microsoft.Win32;
using P = DigitallyImported.Resources.Properties;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    public class Winamp : Player, IWinamp
    {
        private RegistryKey _winampKey;
        private string _winampPath = string.Empty;

        /// <summary>
        /// </summary>
        public Winamp()
            : base(PlayerType.Winamp)
        {
            // if (!IsInstalled) throw new PlayerNotInstalledException("Winamp Player is not installed");
        }

        #region IWinamp Members

        /// <summary>
        /// </summary>
        public override PlayerType PlayerType
        {
            get { return PlayerType.Winamp; }
        }

        /// <summary>
        /// </summary>
        public override Icon PlayerIcon
        {
            get { return P.Resources.icon_winamp; }
        }

        /// <summary>
        /// </summary>
        public override bool IsInstalled
        {
            get
            {
                _winampKey = Registry.LocalMachine.OpenSubKey(Settings.Default.WinampRegistryKeyWoW) ??
                             Registry.LocalMachine.OpenSubKey(Settings.Default.WinampRegistryKey); // 32 bit

                if (_winampKey != null)
                {
                    _winampPath = (string) _winampKey.GetValue(@"UninstallString");
                    _winampPath = _winampPath.Remove(_winampPath.LastIndexOf(@"\", StringComparison.Ordinal));
                    _winampPath += @"\winamp.exe";
                    _winampPath = _winampPath.Insert(_winampPath.Length, new string(new[] {'"'}));
                    return true;
                }

                return false;
            }
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        protected override void Play(IChannel channel)
        {
            Uri url = channel.CurrentTrack.TrackUrl;

            if (IsInstalled)
            {
                var info = new ProcessStartInfo
                    {Arguments = ParseStreamUri(url).AbsoluteUri, FileName = _winampPath, UseShellExecute = false};

                Components.Utilities.StartProcess(info);
            }
        }

        protected override Uri ParseStreamUri(Uri streamUri)
        {
            return streamUri;
        }
    }
}