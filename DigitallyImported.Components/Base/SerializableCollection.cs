using System;
using System.Collections.Generic;

namespace DigitallyImported.Components
{
    public class SerializableCollection<T> : Dictionary<string, Uri>
        where T : IContent
    {
    }
}