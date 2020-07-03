using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace DOHProject.Models
{
    interface IElementMap<T> where T:class
    {
        Dictionary<string, object> Set(T item);
    }
}
