using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Xml;
using DigitallyImported.Configuration.Properties;
using C = DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventListLoader<TEvent> : ContentLoader<TEvent>, IDisposable 
        where TEvent : IEvent
    {
        private XmlReader _reader = null;
        private XmlReaderSettings _readerSettings = null;
        private EventData _eventData = null;

        private StackFrame sf;

        public EventListLoader()
            : this(Settings.Default.DIEventListXml)
        {
            // ContentLocation = Settings.Default.DIEventListXml;
        }

        public EventListLoader(string contentLocation)
            : base(contentLocation)
        {
        }

        #region ILoader<T> Members

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
        /// <param name="contentType"></param>
        /// <returns></returns>
        public virtual DataSet LoadEventList(bool bypassCache)
        {
            _reader = GetItem(_reader);

            if ((bypassCache) || (_reader == null))
            {
                try
                {
                    using (_reader)
                    {
                        _reader = LoadContentFromXml();
                    }
                    base.InsertItem<XmlReader>(_reader);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    // _reader.Close();
                }
            }

            _eventData = GetItem(_eventData);

            if ((bypassCache) || (_eventData == null))
            {
                using (_eventData = new EventData())
                {
                    try
                    {
                        _eventData.ReadXml(_reader);

                        base.InsertItem<EventData>(_eventData);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        _eventData.Dispose();
                    }
                }
            }

            return _eventData;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            Trace.WriteLine("EventListLoader was disposed, disposing = {0}", disposing.ToString());

            if (!disposed)
            {
                if (disposing)
                {
                    if (_eventData != null)
                    {
                        _eventData.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Obsolete("Obsolete. Use LoadXmlData from base class instead. ", true)]
        protected internal XmlReader LoadXmlData()
        {
            _readerSettings = new XmlReaderSettings();

            _readerSettings.IgnoreComments = true;
            _readerSettings.IgnoreWhitespace = true;
            _readerSettings.DtdProcessing = DtdProcessing.Prohibit;

            // EDGE CASE PROCESSING GOES HERE
            ChannelTransforms transform = new ChannelTransforms();

            try
            {
                if (IsNetworkAvailable)
                {
                    return transform.TransformContent(XmlReader.Create(C.Settings.Default.DIEventListXml, _readerSettings));
                }
                else
                {
                    throw new WebException(DigitallyImported.Resources.Properties.Resources.NetworkConnectionError
                        , WebExceptionStatus.ConnectFailure);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
