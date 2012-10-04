using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;
using DigitallyImported.Components.Caching;
using DigitallyImported.Components;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is typeof IContent</typeparam>
    public abstract class ContentLoader<TContent> : CacheItem<TContent>, IContentLoader<TContent> 
        where TContent : IContent
    {
        /// <summary>
        /// 
        /// </summary>
        protected ContentLoader()
            : this(string.Empty)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentLocation"></param>
        protected ContentLoader(string contentLocation)
        {
            ContentLocation = contentLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loaderFactory"></param>
        //protected ContentLoader(ContentLoaderProvider<IContentLoader<TContent>, TContent> loaderFactory)
        //{
            
        //}

        #region ILoader<T> Members

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
        /// <param name="contentLocation"></param>
        /// <returns></returns>
        public virtual XmlReader LoadContentFromXml()
        {
            var settings = new XmlReaderSettings();

            settings.IgnoreComments     = true;
            settings.IgnoreWhitespace   = true;
            settings.DtdProcessing      = DtdProcessing.Parse;

            return LoadContentFromXml(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="contentLocation"></param>
        /// <returns></returns>
        public virtual XmlReader LoadContentFromXml(XmlReaderSettings settings)
        {
            var i = 0;

            if (string.IsNullOrEmpty(ContentLocation)) throw new InvalidOperationException("Property ContentLocation must be set prior to retrieving channels.");

            ChannelTransforms transforms = new ChannelTransforms();
            try
            {
                if (IsNetworkAvailable)
                {
                    return transforms.TransformContent(XmlReader.Create(ContentLocation, settings));
                }
                else
                {
                    i++;
                    throw new WebException(DigitallyImported.Resources.Properties.Resources.NetworkConnectionError
                        , WebExceptionStatus.ConnectFailure);
                }
            }

            // poor style, but these are recoverable exceptions. only throw after reattempting method call 3 times
            catch (XmlException exc)
            {
                Trace.WriteLine(string.Format("{0} {1} occurred in {2}", exc.GetType().ToString(), exc.Message, this.GetType().ToString()), TraceCategories.Exception.ToString());

                if (i <= 3)
                {
                    Trace.WriteLine(string.Format("Attempt #{0} for loading {1}", i.ToString(), ContentLocation), TraceCategories.Exception.ToString());
                    return LoadContentFromXml(settings);
                }
                else
                    throw;
            }
            catch (Exception exc)
            {
                Trace.WriteLine(string.Format("{0} {1} occurred in {2}", exc.GetType().ToString(), exc.Message, this.GetType().ToString()), TraceCategories.Exception.ToString());

                if (i <= 3)
                {
                    Trace.WriteLine(string.Format("Attempt #{0} for loading {1}", i.ToString(), ContentLocation), TraceCategories.Exception.ToString());
                    return LoadContentFromXml(settings);
                }
                else
                    throw;
            }
        }

        protected virtual string ContentLocation
        {
            get; private set;
            //set { _contentLocation = value; }
        }

        #endregion
    }
}
