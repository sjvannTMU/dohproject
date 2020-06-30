using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace DOHProject.Models
{
    interface IContentMap<out T> where T : class
    {
        T Get(IPublishedContent content);
        void Set(ref IContent content);

    }
}
