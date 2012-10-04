using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    [Serializable]
    public class ChannelCollection<T>: ContentCollection<T> where T: IChannel
    {
        private string _channelName;

        public ChannelCollection() 
            : base()
        {
        }

        public ChannelCollection(int capacity)
            : base(capacity)
        {
        }

        // TESTING
        public static T GetChannel(string channelName)
        {
           // _channelName = channelName.ToLower().Trim();
            return default(T);
        }

        /// <summary>
        /// Initializes the Channel Collection for viewing by setting sort parameters
        /// </summary>
        /// <param name="viewer"></param>
        public void View(ChannelViewer<T> viewer)
        {
            //Channel channel = T;
            //if (channel.SortBy) // YADA YADA YADA, encapsulates it into this classs
            //{

            //}
        }

        // predicate
        private bool TESTING(T t)
        {
            if (t.Name == _channelName)
                return true;
            else
                return false;
        }
    }
}
