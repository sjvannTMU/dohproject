
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{

    /// <summary>
    /// D006 職業相關
    /// </summary>
    public class OccupationData : IContentMap<OccupationData>, IElementMap<OccupationData>
    {
        #region 欄位區
        /// <summary>
        /// 機關/公司名稱
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 部門/單位名稱
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 職務名稱
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 專長名稱
        /// </summary>
        public string Expertise { get; set; }
        #endregion
        /// <summary>
        /// 建構元
        /// </summary>
        public OccupationData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="item"></param>
        public OccupationData(PM.OccupationElement item)
        {
            CompanyName = item.CompanyName;
            Department = item.Department;
            JobTitle = item.JobTitle;
            Expertise = item.Expertise;
        }
      
        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public OccupationData Get(IPublishedContent content)
        {
            return new OccupationData((PM.OccupationElement)content);
        }
        /// <summary>
        /// 設資料源
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if (content != null && content.ContentType.Alias == PM.OccupationElement.ModelTypeAlias)
            {
                content.SetValue(PM.OccupationElement.GetModelPropertyType(f => f.CompanyName).Alias, CompanyName);
                content.SetValue(PM.OccupationElement.GetModelPropertyType(f => f.Department).Alias, Department);
                content.SetValue(PM.OccupationElement.GetModelPropertyType(f => f.JobTitle).Alias, JobTitle);
                content.SetValue(PM.OccupationElement.GetModelPropertyType(f => f.Expertise).Alias, Expertise);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(OccupationData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object> {
                { PM.OccupationElement.GetModelPropertyType(f => f.CompanyName).Alias, CompanyName },
                { PM.OccupationElement.GetModelPropertyType(f => f.Department).Alias, Department},
                { PM.OccupationElement.GetModelPropertyType(f => f.JobTitle).Alias, JobTitle},
                { PM.OccupationElement.GetModelPropertyType(f => f.Expertise).Alias, Expertise}
        };
            return local;
        }
    }
}