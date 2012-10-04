using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace DigitallyImported.Components
{
    public abstract class ContentLoaderProvider<T, U> : ProviderBase
        where T: IContent
        where U: IContent
    {
        protected ContentLoaderProvider()
        {}
    }
}
