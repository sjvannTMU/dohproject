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
    /// <summary>
    /// 資料集內容
    /// </summary>
    public class RepositoryContent : IRepositoryConten
    {
        /// <summary>
        /// 存取資料服務
        /// </summary>
        protected readonly IContentService _service;

        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="service"></param>
        public RepositoryContent(IContentService service)
        {
            this._service = service;
        }
        /// <summary>
        /// 建構元
        /// </summary>
        public RepositoryContent()
        {
            if (_service == null)
            {
                this._service = Umbraco.Web.Composing.Current.Services.ContentService;
            }
        }
        /// <summary>
        /// 取得特定子節點
        /// </summary>
        /// <param name="pid">父節點代碼</param>
        /// <param name="childContentTypeAlias">子節點代名</param>
        /// <param name="childNodeName">子節點名稱</param>
        /// <returns></returns>
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
       /// <summary>
       /// 取得子節點清單
       /// </summary>
       /// <param name="pid">父節點代碼</param>
       /// <param name="childContentTypeAlias">子節點代名</param>
       /// <returns>所有子節點</returns>
        public IEnumerable<IContent> GetChildNodes(int pid, string childContentTypeAlias)
        {
            IEnumerable<IContent> childNodes = _service.GetPagedChildren(pid, 0, int.MaxValue, out _);
            return childNodes.Where(x => x.ContentType.Alias == childContentTypeAlias);

        }
        /// <summary>
        /// 取得特定節點
        /// </summary>
        /// <param name="id">節點代碼</param>
        /// <returns>節點</returns>
        public IContent GetNode(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// 取得父節點
        /// </summary>
        /// <param name="id">子節點代碼</param>
        /// <returns>節點</returns>
        public IContent GetParentNode(int id)
        {
            int pid = GetNode(id).ParentId;
            return _service.GetById(pid);
        }
        /// <summary>
        /// 取得根節點
        /// </summary>
        /// <param name="contentTypeAlias">根節點代名</param>
        /// <param name="nodeName">根節點名稱</param>
        /// <returns>節點</returns>
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
        /// <summary>
        /// 新增節點
        /// </summary>
        /// <param name="pid">父節點</param>
        /// <param name="childContentTypeAlias">子節點代名</param>
        /// <param name="childNodeName">子節點名稱</param>
        /// <returns>節點</returns>
        public IContent CreateNewNode(int pid, string childContentTypeAlias, string childNodeName = null)
        {
            IContent node= _service.Create(childNodeName ?? childContentTypeAlias, pid, childContentTypeAlias);
            _service.SaveAndPublish(node);
            return node;

        }
        /// <summary>
        /// 儲存節點
        /// </summary>
        /// <param name="content">節點</param>
        public void Save(IContent content)
        {
            _service.Save(content);
        }
        /// <summary>
        /// 儲存節點並發布
        /// </summary>
        /// <param name="content">節點</param>
        public void SaveAndPublish(IContent content)
        {
            _service.SaveAndPublish(content);
        }
        /// <summary>
        /// 刪除節點
        /// </summary>
        /// <param name="content">節點</param>
        public void Delete(IContent content)
        {
            _service.Delete(content);
        }
        /// <summary>
        /// 取得所有後代節點
        /// </summary>
        /// <param name="pid">父節點</param>
        /// <param name="childContentTypeAlias">子節點代名</param>
        /// <returns>節點清單</returns>
        public IEnumerable<IContent> GetDescendantList(int pid, string childContentTypeAlias)
        {
            IEnumerable<IContent> childNodes = _service.GetPagedDescendants(pid, 0, int.MaxValue, out _).Where(x=>x.ContentType.Alias == childContentTypeAlias);
            return childNodes;
        }
        /// <summary>
        /// 取得未分類節點
        /// </summary>
        /// <param name="rootContentTypeAlias">根節點</param>
        /// <param name="childContentTypeAlias">子節點代名</param>
        /// <param name="childNodeName">子節點名稱</param>
        /// <returns>節點</returns>

        public IContent GetUnGroupNode(string rootContentTypeAlias, string childContentTypeAlias, string childNodeName = "未分類")
        {
            IContent parent = GetRootNode(rootContentTypeAlias);
            return GetChildNode(parent.Id, childContentTypeAlias, childNodeName);
        }
    }
}