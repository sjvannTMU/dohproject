using DOHProject.App_Start;
using DOHProject.Models.Committee;
using DOHProject.Models.Composition;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Repository.Committee
{
    /// <summary>
    /// 儲備委員管理
    /// </summary>
    public class CommitteeRepository : RepositoryBased<CommitteeViewModel>
    {
        private readonly UmbracoHelper _helper;
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="service">資料元服務</param>
        /// <param name="helper">轉換輔助</param>
        public CommitteeRepository(IContentService service, UmbracoHelper helper):base(service)
        {
            this._helper = helper;
        }
        /// <summary>
        /// 新增儲備委員
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override CommitteeViewModel Create(CommitteeViewModel model)
        {
            IContent parent = (model.PId != 0) ? GetNode(model.PId) : GetUnGroupNode(PM.CommitteeRoot.ModelTypeAlias, PM.Committee.ModelTypeAlias);
            var childNodes = GetChildNodes(parent.Id, PM.Committee.ModelTypeAlias).Where(x => x.GetValue<string>(PM.Committee.GetModelPropertyType(f => f.Identity.SID).Alias) == model.Committee.Identity.SID);
            if (childNodes != null && childNodes.Any()) throw new Exception(ErrorMessage.AddDuplicate);
            IContent content = CreateNewNode(parent.Id, PM.Committee.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);
            
            //新增學歷紀錄 - Master
            IContent group1 = CreateNewNode(parent.Id, PM.CommitteeSubgroup.ModelTypeAlias, NodeName.NodeNameEducationHistory);
            model.Set(ref group1);
            SaveAndPublish(group1);
            //新增學歷紀錄 - Detail =>要看傳多少筆進來
            if(model.Committee.EducationHistory != null && model.Committee.EducationHistory.Any())
            {
                int index = 0;
                foreach(EducationGroup item in model.Committee.EducationHistory)
                {
                    IContent subItem = CreateNewNode(group1.Id, PM.EducationHistory.ModelTypeAlias, item.Name);
                    model.Set(ref subItem, index);
                    SaveAndPublish(subItem);
                    index++;
                }
            }
            //新增經歷紀錄 - Master
            IContent group2 = CreateNewNode(parent.Id, PM.CommitteeSubgroup.ModelTypeAlias, NodeName.NodeNameOccupationHistoy);
            model.Set(ref group2);
            SaveAndPublish(group2);
            //新增經歷紀錄 - Detail =>要看傳多少筆進來
            if (model.Committee.OccupationHistoy != null && model.Committee.OccupationHistoy.Any())
            {
                int index = 0;
                foreach (ExperimentGroup item in model.Committee.OccupationHistoy.ToArray())
                {  
                    IContent subItem = CreateNewNode(group1.Id, PM.ExperimentHistory.ModelTypeAlias, item.Name);
                    model.Set(ref subItem, index);
                    SaveAndPublish(subItem);
                    index++;
                }
            }
            //新增評鑑經驗紀錄 - Master
            IContent group3 = CreateNewNode(parent.Id, PM.CommitteeSubgroup.ModelTypeAlias, NodeName.NodeNameEvaluationHistory);
            model.Set(ref group3);
            SaveAndPublish(group3);
            //新增評鑑經驗紀錄  - Detail =>要看傳多少筆進來
            if (model.Committee.EvaluationHistory != null && model.Committee.EvaluationHistory.Any())
            {
                foreach (EvaluationGroup item in model.Committee.EvaluationHistory)
                {
                    IContent subItem = CreateNewNode(group1.Id, PM.EvaluationHistory.ModelTypeAlias, item.Name);
                    model.Set(ref subItem);
                    SaveAndPublish(subItem);
                }
            }
            
            return model.Get(_helper.Content(content));

        }
        /// <summary>
        /// 取得特定儲備委員
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override CommitteeViewModel GetById(int id)
        {
            return new CommitteeViewModel().Get(_helper.Content(id));
        }
        /// <summary>
        /// 取得所有儲備委員
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public override IQueryable<CommitteeViewModel> GetAll(int pid = 0)
        {
            IList<CommitteeViewModel> rList = new List<CommitteeViewModel>();
            IEnumerable<IContent> childNodes = SetupNodes(PM.CommitteeRoot.ModelTypeAlias, PM.Committee.ModelTypeAlias, pid);
            if(childNodes != null && childNodes.Any())
            {
                foreach(IContent item in childNodes)
                {
                    var cc = _helper.Content(item);
                    var aa = new CommitteeViewModel().Get(cc);

                    rList.Add(aa);
                }
            }
            return rList.AsQueryable();
        }
        /// <summary>
        /// 更新儲備委員
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override CommitteeViewModel Update(CommitteeViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model), ErrorMessage.UpdateNull);

            var content = GetNode(model.Id);
            if(content == null)
            {
                return model;
            }
            else
            {
                model.Set(ref content);
                SaveAndPublish(content);
                //學歷紀錄
                LocalSetup(model, content.Id, NodeName.NodeNameEducationHistory, PM.EducationHistory.ModelTypeAlias);
                //經歷紀錄
                LocalSetup(model, content.Id, NodeName.NodeNameOccupationHistoy, PM.ExperimentHistory.ModelTypeAlias);
                //評鑑紀錄
                LocalSetup(model, content.Id, NodeName.NodeNameEvaluationHistory, PM.EvaluationHistory.ModelTypeAlias);
                return model.Get(_helper.Content(content));
            }         

        }
        #region 私有函數
        private void LocalSetup(CommitteeViewModel model,int pId, string groupNodeName, string childNodeName)
        {
            IContent group = GetChildNode(pId, PM.CommitteeSubgroup.ModelTypeAlias, groupNodeName);
            IEnumerable<IContent> groupChildNodes = (group != null) ? GetChildNodes(group.Id, childNodeName) : null;
            if (groupChildNodes != null && groupChildNodes.Any())
            {
                int index = 0;
                foreach (IContent item in groupChildNodes)
                {
                    IContent node = item;
                    model.Set(ref node, index);
                    SaveAndPublish(node);
                    index++;
                }
            }
        }
        #endregion
    }
}