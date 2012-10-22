using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;
using DigitallyImported.Components.Caching;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContent"> </typeparam>
    public abstract class ContentLoader<TContent> : CacheItem<TContent>, IContentLoader<TContent>
        where TContent : IContent
    {
        /// <summary>
        /// 
        /// </summary>
        protected ContentLoader()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentLocation"></param>
        protected ContentLoader(string contentLocation)
        {
            ContentLocation = contentLocation;
        }

        protected virtual string ContentLocation { get; private set; //set { _contentLocation = value; }
        }

        //protected ContentLoader(ContentLoaderProvider<IContentLoader<TContent>, TContent> loaderFactory)
        //{

        //}

        #region IContentLoader<TContent> Members

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsNetworkAvailable
        {
            get { return NetworkInterface.GetIsNetworkAvailable(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public virtual XmlReader LoadContentFromXml(XmlReaderSettings settings)
        {
            int i = 0;

            if (string.IsNullOrEmpty(ContentLocation))
                throw new InvalidOperationException("Property ContentLocation must be set prior to retrieving channels.");

            var transforms = new ChannelTransforms();
            try
            {
                if (IsNetworkAvailable)
                {
                    return transforms.TransformContent(XmlReader.Create(ContentLocation, settings));
                }
                i++;
                throw new WebException(Resources.Properties.Resources.NetworkConnectionError
                                       , WebExceptionStatus.ConnectFailure);
            }

                // poor style, but these are recoverable exceptions. only throw after reattempting method call 3 times
            catch (XmlException exc)
            {
                Trace.WriteLine(string.Format("{0} {1} occurred in {2}", exc.GetType(), exc.Message, GetType()),
                                TraceCategory.Exception.ToString());

                if (i <= 3)
                {
                    Trace.WriteLine(string.Format("Attempt #{0} for loading {1}", i.ToString(), ContentLocation),
                                    TraceCategory.Exception.ToString());
                    return LoadContentFromXml(settings);
                }
                throw;
            }
            catch (Exception exc)
            {
                Trace.WriteLine(string.Format("{0} {1} occurred in {2}", exc.GetType(), exc.Message, GetType()),
                                TraceCategory.Exception.ToString());

                if (i <= 3)
                {
                    Trace.WriteLine(
                        string.Format("Attempt #{0} for loading {1}", i.ToString(CultureInfo.InvariantCulture),
                                      ContentLocation), TraceCategory.Exception.ToString());
                    return LoadContentFromXml(settings);
                }
                throw;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual XmlReader LoadContentFromXml()
        {
            var settings = new XmlReaderSettings
                {IgnoreComments = true, IgnoreWhitespace = true, DtdProcessing = DtdProcessing.Parse};

            return LoadContentFromXml(settings);
        }
    }
}