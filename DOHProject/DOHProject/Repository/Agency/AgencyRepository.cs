using DOHProject.App_Start;
using DOHProject.Models.Agency;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Repository.Agency
{
    /// <summary>
    /// 護產機構儲存庫
    /// </summary>
    public class AgencyRepository : RepositoryBased<AgencyViewModel>
    {
        /// <summary>
        /// 資料處理輔助
        /// </summary>
        private UmbracoHelper _helper;
        
        /// <summary>
        /// 建構元 
        /// </summary>
        /// <param name="service">服務</param>
        /// <param name="helper">輔助</param>
        public AgencyRepository(IContentService service, UmbracoHelper helper):base(service)
        {
            this._helper = helper;
        }
        /// <summary>
        /// 新增護產機構
        /// </summary>
        /// <param name="model">護產交換集</param>
        /// <returns>護產交換集新增後</returns>
        public override AgencyViewModel Create(AgencyViewModel model)
        {
            IContent p = (model.PId != 0) ? GetNode(model.PId) : GetUnGroupNode(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias);
            var childNodes = GetChildNodes(p.Id, PM.Agency.ModelTypeAlias).Where(x => x.GetValue<string>(PM.Agency.GetModelPropertyType(f => f.AgencyID).Alias) == model.Agency.AgencyId);
            if (childNodes != null || childNodes.Any()) throw new Exception(ErrorMessage.AddDuplicate);
            
            IContent content = CreateNewNode(p.Id, PM.Agency.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);

            //新增聯絡人子節點
            IContent contacts = CreateNewNode(content.Id, PM.Contacts.ModelTypeAlias, NodeName.NodeNameContracts);
            model.Set(ref contacts);
            SaveAndPublish(contacts);
            //新增負責人子節點
            IContent principal = CreateNewNode(content.Id, PM.Principal.ModelTypeAlias, NodeName.NodeNamePricipal);
            model.Set(ref principal);
            SaveAndPublish(principal);

            return model.Get(_helper.Content(content));
        }
        /// <summary>
        /// 取得特定護產機構
        /// </summary>
        /// <param name="id">護產機構代碼(系統產生的)</param>
        /// <returns>護產交換集</returns>
        public override AgencyViewModel GetById(int id)
        {
            return new AgencyViewModel().Get(_helper.Content(id));
        }
        /// <summary>
        /// 取得所有護產機構
        /// </summary>
        /// <param name="pid">護產機構分類群組代碼</param>
        /// <returns>護產機構清單</returns>
        public override IQueryable<AgencyViewModel> GetAll(int pid = 0)
        {
            IList<AgencyViewModel> rList = new List<AgencyViewModel>();
            IEnumerable<IContent> childNodes = SetupNodes(PM.AgencyRoot.ModelTypeAlias, PM.Agency.ModelTypeAlias, pid);
            if(childNodes != null && childNodes.Any())
            {
                foreach(IContent item in childNodes)
                {
                    var cc = _helper.Content(item.Id);
                    var aa = new AgencyViewModel().Get(cc);

                    rList.Add(aa);
                }
            }
            return rList.AsQueryable();
        }
        /// <summary>
        /// 更新護產機構
        /// </summary>
        /// <param name="model">護產機構資料集</param>
        /// <returns>護產機構交換集</returns>
        public override AgencyViewModel Update(AgencyViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model),ErrorMessage.UpdateNull);
            var content = GetNode(model.Id);
            if(content == null)
            {
                return model;
            }
            else
            {
                model.Set(ref content);
                SaveAndPublish(content);
                IContent contacts = GetChildNode(content.Id, PM.Contacts.ModelTypeAlias, NodeName.NodeNameContracts);
                model.Set(ref contacts);
                SaveAndPublish(contacts);
                IContent principal = GetChildNode(content.Id, PM.Principal.ModelTypeAlias, NodeName.NodeNamePricipal);
                model.Set(ref principal);
                SaveAndPublish(principal);

                return model.Get(_helper.Content(content));
            }
        }

    }
}