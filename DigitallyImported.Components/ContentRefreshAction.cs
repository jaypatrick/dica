using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

using DigitallyImported.Resources.Properties;
using DigitallyImported.Data;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components
{
    // [Serializable]
    internal class XmlPlaylistRefreshAction : ICacheItemRefreshAction
    {
        #region ICacheItemRefreshAction Members

        private ChannelData _channelData            = new ChannelData();
        private XmlReaderSettings _readerSettings   = new XmlReaderSettings();

        //DEBUG
        StackFrame sf;

        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            CacheManager xmlPlaylistCache = CacheFactory.GetCacheManager();

            xmlPlaylistCache.Add(removedKey, LoadXmlPlaylist(), CacheItemPriority.Normal, null
                , null /* new AbsoluteTime(DateTime.Now.AddMilliseconds(Settings.Default.PlaylistRefreshInterval))*/);
            
        }

        internal XmlReader LoadXmlPlaylist()
        {
            sf = new StackFrame();
            Debug.Write(sf.GetMethod().Name + Environment.NewLine);

            _readerSettings.IgnoreComments = true;
            _readerSettings.IgnoreWhitespace = true;
            _readerSettings.ProhibitDtd = false;
            
            return XmlReader.Create(Resources.Properties.Resources.DIPlaylistXml, _readerSettings);
            // testing, move to cached channelCollection handler
            
        }

        #endregion
    }


    // [Serializable]
    internal class ChannelListRefreshAction : ICacheItemRefreshAction
    {
        StackFrame sf;

        #region ICacheItemRefreshAction Members

        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            CacheManager channelListCache = CacheFactory.GetCacheManager();

            channelListCache.Add(removedKey, GetChannels(), CacheItemPriority.Normal, null
                , null /*new AbsoluteTime(DateTime.Now.AddMilliseconds(Settings.Default.PlaylistRefreshInterval/2))*/);
        }

        internal ChannelCollection<IChannel> GetChannels()
        {
            sf = new StackFrame();
            Debug.Write(sf.GetMethod().Name + Environment.NewLine);

            return ChannelLoader<IChannel>.LoadChannels(true);
        }

        #endregion
    }
}
