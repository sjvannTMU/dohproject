using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;
namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 評鑑資料
    /// </summary>
    public class EvaluationData : IContentMap<EvaluationData>, IElementMap<EvaluationData>
    {
        #region 建構元
        /// <summary>
        /// 建構元
        /// </summary>
        public EvaluationData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public EvaluationData(IPublishedContent content)
        {
            if(content != null && content.ContentType.Alias == PM.EvaluationElement.ModelTypeAlias)
            {
               PM.EvaluationElement item = new PM.EvaluationElement(content);
                EvaluateYear = item.Year;
                Remark = item.Remark;
                Domain = item.Domain;  
            }
        }
        #endregion
        #region 資料區
        /// <summary>
        /// 評鑑年度 - 民國年
        /// </summary>
        public int EvaluateYear { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///領域
        /// </summary>
        public string Domain { get; set; }
        #endregion
        #region 對應區
        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public EvaluationData Get(IPublishedContent content)
        {
            return new EvaluationData(content);
        }
        /// <summary>
        /// 設資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
           if(content != null && content.ContentType.Alias == PM.EvaluationElement.ModelTypeAlias)
            {
                content.SetValue(PM.EvaluationElement.GetModelPropertyType(f => f.Year).Alias, EvaluateYear);
                content.SetValue(PM.EvaluationElement.GetModelPropertyType(f => f.Remark).Alias, Remark);
                content.SetValue(PM.EvaluationElement.GetModelPropertyType(f => f.Domain).Alias, Domain);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(EvaluationData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object>
            {
                {PM.EvaluationElement.GetModelPropertyType(f=>f.Year).Alias, EvaluateYear },
                {PM.EvaluationElement.GetModelPropertyType(f=>f.Remark).Alias, Remark },
                {PM.EvaluationElement.GetModelPropertyType(f=>f.Domain).Alias, Domain }
            };
            return local;
        }
        #endregion
    }
}