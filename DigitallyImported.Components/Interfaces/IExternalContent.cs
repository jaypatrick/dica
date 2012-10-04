using System;

namespace DigitallyImported.Components
{
    public interface IExternalContent : IContent
    {
        Uri Location { get; set; }
    }
}
