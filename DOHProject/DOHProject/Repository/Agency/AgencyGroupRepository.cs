using DOHProject.App_Start;
using DOHProject.Models.Agency;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Repository.Agency
{
    /// <summary>
    /// 護產機構分類儲存庫
    /// </summary>
    public class AgencyGroupRepository : RepositoryBased<AgencyGroupViewModel>
    {
        private readonly UmbracoHelper _helper;

        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="service">服務</param>
        /// <param name="helper">輔助</param>
        public AgencyGroupRepository(IContentService service, UmbracoHelper helper):base(service)
        {
            this._helper = helper;
        }
        /// <summary>
        /// 新增分類
        /// </summary>
        /// <param name="model">分類交換集</param>
        /// <returns>分類交換集</returns>
        public override AgencyGroupViewModel Create(AgencyGroupViewModel model)
        {
            IContent p = model.PId != 0 ? GetNode(model.PId) : GetUnGroupNode(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias);
            IContent content = CreateNewNode(p.Id, PM.AgencyGroup.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);

            return model.Get(_helper.Content(content));
        }
        /// <summary>
        /// 新增分類
        /// </summary>
        /// <param name="pid">護產機構根目錄</param>
        /// <param name="model">交換集</param>
        /// <returns></returns>
        public override AgencyGroupViewModel Create(int pid, AgencyGroupViewModel model)
        {
            IContent content = CreateNewNode(pid, PM.Agency.ModelTypeAlias, model.Name);
            model.Set(ref content);
            return model.Get(_helper.Content(content));
        }
        /// <summary>
        /// 取得特定分類
        /// </summary>
        /// <param name="id">分類代碼</param>
        /// <returns></returns>
        public override AgencyGroupViewModel GetById(int id)
        {
            return new AgencyGroupViewModel().Get(_helper.Content(id));
        }
        /// <summary>
        /// 取得所有分類
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public override IQueryable<AgencyGroupViewModel> GetAll(int pid = 0)
        {
            IList<AgencyGroupViewModel> rList = new List<AgencyGroupViewModel>();
            IEnumerable<IContent> childNodes = SetupNodes(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias, pid);
            if(childNodes != null && childNodes.Any())
            {
                foreach(IContent item in childNodes)
                {
                    var cc = _helper.Content(item.Id);
                    var ag = new AgencyGroupViewModel().Get(cc);
                    rList.Add(ag);
                }
            }
            return rList.AsQueryable();
        }
        /// <summary>
        /// 更新分類
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override AgencyGroupViewModel Update(AgencyGroupViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model), ErrorMessage.UpdateNull);
            var content = model.Id != 0 ? GetNode(model.Id) : null;
            if(content == null)
            {
                return model;
            }
            else
            {
                model.Set(ref content);
                SaveAndPublish(content);
                return model.Get(_helper.Content(content));
            }
           
        }

    }
}