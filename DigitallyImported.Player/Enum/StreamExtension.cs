using System;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    [Flags] // need to figure out which streams can be combined into each player
    public enum StreamExtension
    {
        asx,
        asf,
        wma, // WMA
        pls, // winamp native
        m3u, // m3u, winamp?
        ram // realplayer, bleh
    }
}