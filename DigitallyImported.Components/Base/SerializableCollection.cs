#region using declarations

using System;
using System.Collections.Generic;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class SerializableCollection<T> : Dictionary<string, Uri>
        where T : IContent
    {
    }
}