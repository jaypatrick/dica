#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    [Serializable]
    public class ViewChangedEventArgs<T> : EventArgs
        where T : IContentCollection<IChannel>
    {
        /// <summary>
        /// </summary>
        public ViewChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="changedContent"> </param>
        public ViewChangedEventArgs(T changedContent)
        {
            ChangedContent = changedContent;
        }

        public virtual T ChangedContent { get; private set; }
    }
}