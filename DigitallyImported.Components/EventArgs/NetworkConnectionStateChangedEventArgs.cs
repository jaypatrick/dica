#region using declarations

using System;

#endregion

namespace DigitallyImported.Components.Services
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class NetworkConnectionStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// </summary>
        public ConnectionStatus NetworkStatus { get; set; }
    }
}