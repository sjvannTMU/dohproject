using DOHProject.App_Start;
using DOHProject.Models.Common;
using DOHProject.Models.DataType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Committee
{
    /// <summary>
    /// 儲備委員交換資料集
    /// </summary>
    public class CommitteeViewModel:ViewModelBased, IContentMap<CommitteeViewModel>
    {
        #region 欄位區
        /// <summary>
        /// 委員
        /// </summary>
        public PersonCommittee Committee { get; set; }
        #endregion


        #region 建構元
        /// <summary>
        /// 建構元
        /// </summary>
        public CommitteeViewModel() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public CommitteeViewModel(IPublishedContent content)
        {  
            if(content != null && content.ContentType.Alias == PM.Committee.ModelTypeAlias)
            {
                PM.Committee committee = new PM.Committee(content);
                Committee = LocalMapForCommittee(committee);
            }
        }
        #endregion

        /// <summary>
        /// 取得交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public CommitteeViewModel Get(IPublishedContent content)
        {
            CommitteeViewModel model = new CommitteeViewModel();
            if(content != null && content.ContentType.Alias == PM.Committee.ModelTypeAlias)
            {
                PM.Committee committee = new PM.Committee(content);
                model.Id = content.Id;
                model.PId = content.Parent.Id;
                model.Name = content.Name;
                model.Committee = LocalMapForCommittee(committee);
            }
            return model;
        }
        /// <summary>
        /// 設定資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if (content == null) throw new ArgumentNullException(ErrorMessage.GotNull);
           // 主檔部份
            if (content.ContentType.Alias == PM.Committee.ModelTypeAlias)
            {
                //節點名稱
                content.Name = Name;
                //中文 - 姓名模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.ChineseName).Alias,JsonConvert.SerializeObject(new NameData().Set(Committee.ChineseName)));
                //英文 - 姓名模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.EnglishName).Alias, JsonConvert.SerializeObject(new NameData().Set(Committee.EnglishName)));
                //辨識模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.Identity).Alias, JsonConvert.SerializeObject(new IdentifyData().Set(Committee.Identity)));
                //住家 - 地址模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.HomeAddress).Alias, JsonConvert.SerializeObject(new AddressData().Set(Committee.HomeAddress)));
                //戶籍 - 地址模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.ResidentAddress).Alias, JsonConvert.SerializeObject(new AddressData().Set(Committee.ResidentAddress)));
                //辦公室 - 地址模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.OfficeAddress).Alias, JsonConvert.SerializeObject(new AddressData().Set(Committee.OfficeAddress)));
                //聯絡方式 - 通訊模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.TEldata).Alias, JsonConvert.SerializeObject(new TelData().Set(Committee.TELData)));
                //職業資訊 - 職業模組
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.Occupation).Alias, JsonConvert.SerializeObject(new OccupationData().Set(Committee.Occupation)));
                //迴避原因 
                content.SetValue(PM.Committee.GetModelPropertyType(f => f.AvoidReasons).Alias, Committee.AvoidReason);
            }
            //設定群組
            else if(content.ContentType.Alias == PM.CommitteeSubgroup.ModelTypeAlias)
            {
               //暫時無須執行任務
            }
            //學歷紀錄
            else if(content.ContentType.Alias == PM.EducationHistory.ModelTypeAlias)
            {
                //學校模組
                content.SetValue(PM.EducationHistory.GetModelPropertyType(f => f.School).Alias, JsonConvert.SerializeObject(new SchoolData().Set(Committee.EducationHistory[index].School)));
                
                content.SetValue(PM.EducationHistory.GetModelPropertyType(f => f.DegYear).Alias, Committee.EducationHistory[index].GraduationYear);
                content.SetValue(PM.EducationHistory.GetModelPropertyType(f => f.DegLevel).Alias, Committee.EducationHistory[index].Degree);
            }
            //經歷紀錄
            else if(content.ContentType.Alias == PM.ExperimentHistory.ModelTypeAlias)
            {
                content.SetValue(PM.ExperimentHistory.GetModelPropertyType(f => f.ExperimentItem).Alias, JsonConvert.SerializeObject(new OccupationData().Set(Committee.OccupationHistoy[index].Experiment)));
            }
            //評鑑經歷
            else if(content.ContentType.Alias == PM.EvaluationHistory.ModelTypeAlias)
            {
                content.SetValue(PM.EvaluationHistory.GetModelPropertyType(f => f.EvaluationItem).Alias, JsonConvert.SerializeObject(new EvaluationData().Set(Committee.EvaluationHistory[index].Evaluation)));
            }
        }


        #region Local Get
        /// <summary>
        ///  對應
        /// </summary>
        /// <param name="committee"></param>
        /// <returns></returns>
        private PersonCommittee LocalMapForCommittee(PM.Committee committee)
        {
            PersonCommittee item = new PersonCommittee
            {
                ChineseName = new DataType.NameData(committee.ChineseName),
                EnglishName = new DataType.NameData(committee.EnglishName),
                Identity = new DataType.IdentifyData(committee.Identity),
                HomeAddress = new DataType.AddressData(committee.HomeAddress),
                ResidentAddress = new DataType.AddressData(committee.ResidentAddress),
                OfficeAddress = new DataType.AddressData(committee.OfficeAddress),
                TELData = new DataType.TelData(committee.TEldata),
                Occupation = new DataType.OccupationData(committee.Occupation),
                AvoidReason = committee.AvoidReasons.ToArray()
            };
            //學歷紀錄
            var educationGroup = committee.FirstChild<PM.CommitteeSubgroup>(x => x.Name == NodeName.NodeNameEducationHistory);
            item.EducationHistory = LocalMapForEducationHistory(educationGroup).ToArray();
            //經歷紀錄
            var occupationGroup = committee.FirstChild<PM.CommitteeSubgroup>(x => x.Name == NodeName.NodeNameOccupationHistoy);
            item.OccupationHistoy = LocalMapForOccupationHistory(occupationGroup).ToArray();
            //評鑑經驗紀錄
            var evaluationGroup = committee.FirstChild<PM.CommitteeSubgroup>(x => x.Name == NodeName.NodeNameEvaluationHistory);
            item.EvaluationHistory = LocalMapForEvaluationHistory(evaluationGroup).ToArray();
                
            return item;
        }

        private IEnumerable<Composition.EvaluationGroup> LocalMapForEvaluationHistory(CommitteeSubgroup evaluationGroup)
        {
            IList<Composition.EvaluationGroup> rList = new List<Composition.EvaluationGroup>();
            if (evaluationGroup != null && evaluationGroup.Children<PM.EvaluationControl>().Any())
            {
                foreach (IPublishedContent c in evaluationGroup.Children<PM.EvaluationControl>())
                    rList.Add(new Composition.EvaluationGroup().Get(c));
            }
            return rList;
        }

        private IEnumerable<Composition.ExperimentGroup> LocalMapForOccupationHistory(PM.CommitteeSubgroup group)
        {
            IList<Composition.ExperimentGroup> rList = new List<Composition.ExperimentGroup>();
            if (group != null && group.Children<PM.ExperimentControl>().Any())
            {
                foreach (IPublishedContent c in group.Children<PM.ExperimentControl>())
                    rList.Add(new Composition.ExperimentGroup().Get(c));
            }
            return rList;
        }
        #endregion
        #region Local Set
  

        private IEnumerable<Composition.EducationGroup> LocalMapForEducationHistory(PM.CommitteeSubgroup group)
        {
            IList<Composition.EducationGroup> rList = new List<Composition.EducationGroup>();
            if(group != null &&　group.Children<PM.EducationHistory>().Any())
            {
                foreach (IPublishedContent c in group.Children<PM.EducationHistory>())
                    rList.Add(new Composition.EducationGroup().Get(c));
            }
            return rList;
        }
        #endregion
    }
}