using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    public interface ISiteView<T> : IContentView<T> where T: ISite
    {
        SiteCollection<T> GetView(bool BypassCache);
        SiteCollection<T> Sites { get; set; }

        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
    }
}
