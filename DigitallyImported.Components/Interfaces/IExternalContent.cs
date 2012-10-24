#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    public interface IExternalContent : IContent
    {
        Uri Location { get; set; }
    }
}