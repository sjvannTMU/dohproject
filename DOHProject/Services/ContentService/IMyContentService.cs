using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Services.ContentService
{
    interface IMyContentService
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
        #endregion

        #region 取子節點清單
        IEnumerable<IContent> GetChildNodes(int pid, string childContentTypeAlias);
        //IEnumerable<T> GetChildNodes<T>(int pid, string childContentTypeAlias) where T:PublishedContentModel;
        #endregion

        #region 取根節點
        IContent GetRootNode(string contentTypeAlias, string nodeName = null);
        //T GetRootNode<T>(string contentTypeAlias, string nodeName = null) where T : PublishedContentModel;
        #endregion
    }
}
