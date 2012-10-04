using System;

namespace DigitallyImported.Components
{
    [Serializable]
    public abstract class ContentChangedEventArgs<T> : EventArgs where T: IContent
    {
        private T _refreshedContent = default(T);

        /// <summary>
        /// 
        /// </summary>
        protected ContentChangedEventArgs() 
            : this(default(T))
        { }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        protected ContentChangedEventArgs(T refreshedContent)
        {
            _refreshedContent = refreshedContent;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract T RefreshedContent { get; set; }
    }
}
