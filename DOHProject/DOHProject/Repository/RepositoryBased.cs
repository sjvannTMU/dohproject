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
    public partial class RepositoryBased<T> : RepositoryContent, IRepositoryOperation<T> where T : class
    {
        protected const string UPDATE_NULL_ERROR_MESSAGE = "更新時ViewModel不可為Null";
public RepositoryBased(IContentService contentService) : base(contentService)
        {
        }

        public virtual T Create(T model)
        {
            throw new NotImplementedException();
        }
        public virtual T Create(int pid, T model)
        {
            throw new NotImplementedException();
        }

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

        public virtual IQueryable<T> GetAll(int pid = 0)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression, int pid = 0)
        {
            return this.GetAll().Where(expression);
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T model)
        {
            throw new NotImplementedException();
        }
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