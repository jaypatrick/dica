#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    [Serializable]
    public abstract class ContentChangedEventArgs<T> : EventArgs
        where T : IContent
    {
        /// <summary>
        /// </summary>
        protected ContentChangedEventArgs()
            : this(default(T))
        {
        }


        /// <summary>
        /// </summary>
        /// <param name="refreshedContent"> </param>
        protected ContentChangedEventArgs(T refreshedContent)
        {
            RefreshedContent = refreshedContent;
        }

        /// <summary>
        /// </summary>
        public abstract T RefreshedContent { get; set; }
    }
}