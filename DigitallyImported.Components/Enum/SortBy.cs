using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Flags]
    public enum SortBy
    {
        /// <summary>
        /// 
        /// </summary>
        ChannelName = 1,

        /// <summary>
        /// 
        /// </summary>
        SiteName = 2,

        /// <summary>
        /// 
        /// </summary>
        TrackTitle = 4,

        /// <summary>
        /// 
        /// </summary>
        StartTime = 8
    }
}