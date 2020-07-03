using DOHProject.Models.Common;
using DOHProject.Models.Composition;
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
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
        public void Set(ref IContent content)
        {
            throw new NotImplementedException();
        }
        #region Local Map
        /// <summary>
        ///  對應
        /// </summary>
        /// <param name="committee"></param>
        /// <returns></returns>
        private PersonCommittee LocalMapForCommittee(PM.Committee committee)
        {
            PersonCommittee item = new PersonCommittee();
            item.ChineseName = new DataType.NameData(committee.ChineseName);
            item.EnglishName = new DataType.NameData(committee.EnglishName);
            item.Identity = new DataType.IdentifyData(committee.Identity);
            item.HomeAddress = new DataType.AddressData(committee.HomeAddress);
            item.ResidentAddress = new DataType.AddressData(committee.ResidentAddress);
            item.OfficeAddress = new DataType.AddressData(committee.OfficeAddress);
            item.TELData = new DataType.TELData(committee.TEldata);
            item.Occupation = new DataType.OccupationData(committee.Occupation);
            item.AvoidReason = committee.AvoidReasons;

            item.EducationHistory = LocalMapForEducationHistory();

            return item;
        }
        #endregion
        #region Local Set
        private IEnumerable<EducationControl> LocalMapForEducationHistory()
        {
            IList<EducationControl> rList = new List<EducationControl>();

            return rList;
        }
        #endregion
    }
}