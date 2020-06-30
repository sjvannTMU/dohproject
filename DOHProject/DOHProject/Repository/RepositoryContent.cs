using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace DOHProject.Repository
{
    public class RepositoryContent : IRepositoryConten
    {
        protected readonly IContentService _service;


        public RepositoryContent(IContentService service)
        {
            this._service = service;
        }
        public RepositoryContent()
        {
            if (_service == null)
            {
                this._service = Umbraco.Web.Composing.Current.Services.ContentService;
            }
        }
        public IContent GetChildNode(int pid, string childContentTypeAlias, string childNodeName = null)
        {
            IContent childNode = (childNodeName == null) ?
                this.GetChildNodes(pid, childContentTypeAlias).FirstOrDefault() :
                this.GetChildNodes(pid, childContentTypeAlias).FirstOrDefault(x => x.Name == childNodeName);
            if(childNode == null)
            {
                childNode = _service.CreateAndSave(childNodeName ?? childContentTypeAlias, pid, childContentTypeAlias);
            }
            if(!childNode.Published)
            {
                _service.SaveAndPublish(childNode);
            }
            return childNode;
        }
       
        public IEnumerable<IContent> GetChildNodes(int pid, string childContentTypeAlias)
        {
            IEnumerable<IContent> childNodes = _service.GetPagedChildren(pid, 0, int.MaxValue, out _);
            return childNodes.Where(x => x.ContentType.Alias == childContentTypeAlias);

        }

        public IContent GetNode(int id)
        {
            return _service.GetById(id);
        }

        public IContent GetParentNode(int id)
        {
            int pid = GetNode(id).ParentId;
            return _service.GetById(pid);
        }

        public IContent GetRootNode(string contentTypeAlias, string nodeName = null)
        {
            IContent rootNode = (nodeName == null) ?
                  _service.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == contentTypeAlias) :
                  _service.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == contentTypeAlias && x.Name == nodeName);

            if (rootNode == null)
            {
                rootNode = _service.CreateAndSave(nodeName ?? contentTypeAlias, -1, contentTypeAlias);
            }
            if(!rootNode.Published)
            {
                _service.SaveAndPublish(rootNode);
            }
            return rootNode;
        }

        public IContent CreateNewNode(int pid, string childContentTypeAlias, string childNodeName = null)
        {
            IContent node= _service.Create(childNodeName ?? childContentTypeAlias, pid, childContentTypeAlias);
            _service.SaveAndPublish(node);
            return node;

        }

        public void Save(IContent content)
        {
            _service.Save(content);
        }

        public void SaveAndPublish(IContent content)
        {
            _service.SaveAndPublish(content);
        }

        public void Delete(IContent content)
        {
            _service.Delete(content);
        }

        public IEnumerable<IContent> GetDescendantList(int pid, string childContentTypeAlias)
        {
            IEnumerable<IContent> childNodes = _service.GetPagedDescendants(pid, 0, int.MaxValue, out _).Where(x=>x.ContentType.Alias == childContentTypeAlias);
            return childNodes;
        }

        public IContent GetUnGroupNode(string rootContentTypeAlias, string childContentTypeAlias, string childNodeName = "未分類")
        {
            IContent parent = GetRootNode(rootContentTypeAlias);
            return GetChildNode(parent.Id, childContentTypeAlias, childNodeName);
        }
    }
}