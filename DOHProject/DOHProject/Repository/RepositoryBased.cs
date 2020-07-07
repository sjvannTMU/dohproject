using Examine.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace DOHProject.Repository
{
    /// <summary>
    /// 儲存庫基礎類別
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class RepositoryBased<T> : RepositoryContent, IRepositoryOperation<T> where T : class
    {
        
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="contentService"></param>
        public RepositoryBased(IContentService contentService) : base(contentService)
        {
        }

        /// <summary>
        ///  新增資料 - 從根節點建立節點
        /// </summary>
        /// <param name="model">交換元</param>
        /// <returns>新增後交換元</returns>
        public virtual T Create(T model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  新增資料 - 從父節點建立節點
        /// </summary>
        /// <param name="pid">父節點代碼</param>
        /// <param name="model">交換元</param>
        /// <returns>新增後交換元</returns>
        public virtual T Create(int pid, T model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">刪除對象代碼</param>
        /// <returns>成功與否</returns>
        public bool Delete(int id)
        {
            var content = GetNode(id);
            if (content != null)
            {
                Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="pid">父節點（0 =>從根節點）</param>
        /// <returns>資料清單</returns>
        public virtual IQueryable<T> GetAll(int pid = 0)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 以條件式查詢資料
        /// </summary>
        /// <param name="expression">查詢條件</param>
        /// <param name="pid">父節點（0 =>從根節點）</param>
        /// <returns>資料清單</returns>
        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression, int pid = 0)
        {
            return this.GetAll().Where(expression);
        }
        /// <summary>
        /// 以代碼取得資料
        /// </summary>
        /// <param name="id">特定資料之代碼</param>
        /// <returns>特定資料</returns>
        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="model">更新來源</param>
        /// <returns>更新後資料元</returns>
        public virtual T Update(T model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 設定節點
        /// </summary>
        /// <param name="rootNodeAlias">根節點代名</param>
        /// <param name="childNodeAlias">子節點代名</param>
        /// <param name="pid">父節點代碼(0=>根節點)</param>
        /// <returns></returns>
        protected IEnumerable<IContent> SetupNodes(string rootNodeAlias, string childNodeAlias, int pid =0)
        {
            IEnumerable<IContent> childNodes;
            if(pid == 0)
            {
                IContent parentNode = GetRootNode(rootNodeAlias);
                childNodes = GetDescendantList(parentNode.Id, childNodeAlias);
            }
            else
            {
                IContent parentNode = GetNode(pid);
                childNodes = GetChildNodes(parentNode.Id, childNodeAlias);
            }
            return childNodes;
        }
    }
}