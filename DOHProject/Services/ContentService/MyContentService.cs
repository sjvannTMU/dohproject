using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Services.ContentService
{
    class MyContentService : IMyContentService
    {
        private IContentService _service;
        public MyContentService(IContentService service)
        {
            this._service = service;
        }

        public IContent GetChildNode(int pid, string childContentTypeAlias, string childNodeName = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContent> GetChildNodes(int pid, string childContentTypeAlias)
        {
            throw new NotImplementedException();
        }

        public IContent GetNode(int id)
        {
            return _service.GetById(id);
        }

        public IContent GetParentNode(int id)
        {
            throw new NotImplementedException();
        }

        public IContent GetRootNode(string contentTypeAlias, string nodeName = null)
        {
            throw new NotImplementedException();
        }
    }
}
