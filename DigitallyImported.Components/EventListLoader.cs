using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Xml;
using C = DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEvent"> </typeparam>
    public class EventListLoader<TEvent> : ContentLoader<TEvent>, IDisposable
        where TEvent : IEvent
    {
        private bool _disposed;
        private EventData _eventData;
        private XmlReader _reader;
        private XmlReaderSettings _readerSettings;

        private StackFrame sf;

        public EventListLoader()
            : this(C.Settings.Default.DIEventListXml)
        {
            // ContentLocation = Settings.Default.DIEventListXml;
        }

        public EventListLoader(string contentLocation)
            : base(contentLocation)
        {
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <returns></returns>
        public virtual DataSet LoadEventList()
        {
            return LoadEventList(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <returns></returns>
        public virtual DataSet LoadEventList(bool bypassCache)
        {
            _reader = GetItem(_reader);

            if ((bypassCache) || (_reader == null))
            {
                using (_reader)
                {
                    _reader = LoadContentFromXml();
                }
                base.InsertItem(_reader);
            }

            _eventData = GetItem(_eventData);

            if ((bypassCache) || (_eventData == null))
            {
                using (_eventData = new EventData())
                {
                    try
                    {
                        _eventData.ReadXml(_reader);

                        base.InsertItem(_eventData);
                    }
                    finally
                    {
                        _eventData.Dispose();
                    }
                }
            }

            return _eventData;
        }

        protected virtual void Dispose(bool disposing)
        {
            Trace.WriteLine("EventListLoader was disposed, disposing = {0}", disposing.ToString());

            if (!_disposed)
            {
                if (disposing)
                {
                    if (_eventData != null)
                    {
                        _eventData.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
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
                    transform.TransformContent(XmlReader.Create(C.Settings.Default.DIEventListXml, _readerSettings));
            }
            throw new WebException(Resources.Properties.Resources.NetworkConnectionError
                                   , WebExceptionStatus.ConnectFailure);
        }
    }
}