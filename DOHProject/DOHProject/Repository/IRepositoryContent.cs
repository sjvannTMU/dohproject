using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace DOHProject.Repository
{
    interface IRepositoryConten
    {
        
        #region 取得目前節點
        IContent GetNode(int id);
        // T GetNode<T>(int id) where T : PublishedContentModel;
        #endregion
        #region 取得父節點
        IContent GetParentNode(int id);
        //T GetParentNode<T>(int id) where T : PublishedContentModel;
        #endregion

        #region 取特定子節點
        IContent GetChildNode(int pid, string childContentTypeAlias, string childNodeName = null);
        //T GetChildNode<T>(int pid, string childContentTypeAlias, string childNodeName = null) where T : PublishedContentModel;
        IContent GetUnGroupNode(string rootContentTypeAlias, string childContentTypeAlias, string childNodeName = "未分類");

        #endregion

        #region 取子節點清單
        IEnumerable<IContent> GetChildNodes(int pid, string childContentTypeAlias);
        IEnumerable<IContent> GetDescendantList(int pid, string childContentTypeAlias);
        //IEnumerable<T> GetChildNodes<T>(int pid, string childContentTypeAlias) where T:PublishedContentModel;
        #endregion

        #region 取根節點
        IContent GetRootNode(string contentTypeAlias, string nodeName = null);
        //T GetRootNode<T>(string contentTypeAlias, string nodeName = null) where T : PublishedContentModel;
        #endregion

        #region 節點操作
        IContent CreateNewNode(int pid, string childContentTypeAlias, string childNodeName = null);
        void Save(IContent content);
        void SaveAndPublish(IContent content);
        void Delete(IContent content);
        #endregion
        
    }
}
