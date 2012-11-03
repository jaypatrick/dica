#region using declarations

using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Xml;
using DigitallyImported.Data;
using C = DigitallyImported.Configuration.Properties;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    public class ChannelListLoader<TChannel> : ContentLoader<TChannel>, IDisposable
        where TChannel : IChannel
    {
        private ChannelData _channelData;
        private bool _disposed;
        private XmlReader _reader;
        private XmlReaderSettings _readerSettings;

        /// <summary>
        ///   Default constructor. Uses default playlist URL specified in app configuration.
        /// </summary>
        public ChannelListLoader()
            : this(C.Settings.Default.DIPlaylistXml)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelsLocation"></param>
        public ChannelListLoader(string channelsLocation)
            : base(channelsLocation)
        {
            // ContentLocation = channelsLocation;
        }

        #region IDisposable Members

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="bypassCache"> </param>
        /// <returns> </returns>
        public virtual DataSet LoadPlaylist(bool bypassCache)
        {
            return LoadPlaylist(bypassCache, C.Settings.Default.DIPlaylistXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <param name="contentLocation"></param>
        /// <returns></returns>
        public virtual DataSet LoadPlaylist(bool bypassCache, string contentLocation)
        {
            _reader = GetItem(_reader);

            if ((bypassCache) || (_reader == null))
            {
                using (_reader)
                {
                    _reader = LoadContentFromXml(); // XmlReader.Create(Resources.DIPlaylistXml, _readerSettings);
                }

                base.InsertItem(_reader);
            }

            _channelData = GetItem(_channelData);

            if ((bypassCache) || (_channelData == null))
            {
                using (_channelData = new ChannelData())
                {
                    try
                    {
                        _channelData.ReadXml(_reader);

                        base.InsertItem(_channelData);
                    }
                    finally
                    {
                        _channelData.Dispose();
                    }
                }
            }

            return _channelData;
        }

        /// <summary>
        /// </summary>
        /// <param name="disposing"> </param>
        protected virtual void Dispose(bool disposing)
        {
            Trace.WriteLine("EventListLoader was disposed, disposing = {0}", disposing.ToString());

            if (_disposed) return;
            if (disposing && _channelData != null)
            {
                _channelData.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <returns> </returns>
        [Obsolete("Obsolete. Use LoadXmlData from base class instead. ", true)]
        protected internal XmlReader LoadXmlData()
        {
            _readerSettings = new XmlReaderSettings
                {IgnoreComments = true, IgnoreWhitespace = true, DtdProcessing = DtdProcessing.Prohibit};

            // EDGE CASE PROCESSING GOES HERE
            var transform = new ChannelTransforms();

            if (IsNetworkAvailable)
            {
                return
                    transform.TransformContent(XmlReader.Create(C.Settings.Default.DIPlaylistXml, _readerSettings));
            }
            throw new WebException(Resources.Properties.Resources.NetworkConnectionError
                                   , WebExceptionStatus.ConnectFailure);
        }
    }
}