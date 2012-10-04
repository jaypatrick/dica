using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    [Serializable()]
    public class StreamCollection<T> : ContentCollection<T> where T: IStream
    {
        /// <summary>
        /// 
        /// </summary>
        public StreamCollection()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public StreamCollection(IChannel channel)
        {
            // 

            Channel = channel;    // channel that this collection is attached to
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel Channel
        {
            get;
            set;
        }
    }
}
