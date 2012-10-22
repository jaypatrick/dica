using System;

namespace DigitallyImported.Components.Services
{
    [Serializable]
    public class NetworkConnectionStateChangedEventArgs : EventArgs
    {
        private ConnectionStatus _networkStatus;

        public ConnectionStatus NetworkStatus
        {
            get { return _networkStatus; }
            set { _networkStatus = value; }
        }
    }
}