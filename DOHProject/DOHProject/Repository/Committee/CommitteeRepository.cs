using DOHProject.App_Start;
using DOHProject.Models.Committee;
using DOHProject.Models.Composition;
using System;
using System.Linq;
using Umbraco.Core.Models;
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
        public override CommitteeViewModel Create(CommitteeViewModel model)
        {
            IContent parent = (model.PId != 0) ? GetNode(model.PId) : GetUnGroupNode(PM.CommitteeRoot.ModelTypeAlias, PM.Committee.ModelTypeAlias);
            var childNodes = GetChildNodes(parent.Id, PM.Committee.ModelTypeAlias).Where(x => x.GetValue<string>(PM.Committee.GetModelPropertyType(f => f.Identity.SID).Alias) == model.Committee.Identity.SID);
            if (childNodes != null && childNodes.Any()) throw new Exception(MESSAGE_ERROR_ADDNEW);
            IContent content = CreateNewNode(parent.Id, PM.Committee.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);
            #region 學歷紀錄
            //新增學歷紀錄 - Master
            IContent group1 = CreateNewNode(parent.Id, PM.CommitteeSubgroup.ModelTypeAlias, NodeName.NodeNameEducationHistory);
            model.Set(ref group1);
            SaveAndPublish(group1);
            //新增學歷紀錄 - Detail =>要看傳多少筆進來
            if(model.Committee.EducationHistory != null && model.Committee.EducationHistory.Any())
            {
                foreach(EducationGroup item in model.Committee.EducationHistory)
                {
                    IContent subItem = CreateNewNode(group1.Id, PM.EducationHistory.ModelTypeAlias, item.Name);
                    model.Set(ref subItem);
                    SaveAndPublish(subItem);
                }
            }
            #endregion
            #region 經歷紀錄
            //新增經歷紀錄 - Master
            IContent group2 = CreateNewNode(parent.Id, PM.CommitteeSubgroup.ModelTypeAlias, NodeName.NodeNameOccupationHistoy);
            model.Set(ref group2);
            SaveAndPublish(group2);
            //新增經歷紀錄 - Detail =>要看傳多少筆進來
            if (model.Committee.OccupationHistoy != null && model.Committee.OccupationHistoy.Any())
            {
                foreach (ExperimentGroup item in model.Committee.OccupationHistoy)
                {
                    IContent subItem = CreateNewNode(group1.Id, PM.ExperimentHistory.ModelTypeAlias, item.Name);
                    model.Set(ref subItem);
                    SaveAndPublish(subItem);
                }
            }
            #endregion
            #region 評鑑經驗紀錄
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
            #endregion

        }
    }
}