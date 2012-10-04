using System;

namespace DigitallyImported.Components.Services
{
    [Serializable]
    public class NetworkConnectionStateChangedEventArgs : System.EventArgs
    {
        public ConnectionStatus NetworkStatus
        {
            get { return this._networkStatus; }
            set { this._networkStatus = value; }
        }
        private ConnectionStatus _networkStatus;
    }
}
