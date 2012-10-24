#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class ChannelList<T> : ChannelCollection<T> where T : IChannel
    {
    }
}