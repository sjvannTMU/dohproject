using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 辨識模組
    /// </summary>
    public class IdentifyData : IContentMap<IdentifyData>, IElementMap<IdentifyData>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public IdentifyData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="item"></param>
        public IdentifyData(PM.IdentifyElement item)
        {
            SID = item.SID;
            Birthday = item.Birthday;
            Gender = item.Gender;
            ComType = item.ComType;
        }
        /// <summary>
        /// 身份證字號
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性別 1 男 2 女
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 委員代表之身份
        /// 1：學術、2：實務
        /// </summary>
        public int ComType { get; set; }
        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IdentifyData Get(IPublishedContent content)
        {
            return new IdentifyData((PM.IdentifyElement)content);
        }
        /// <summary>
        /// 設資料元
        /// </summary>
        /// <param name="content"></param>
        public void Set(ref IContent content)
        {
            if (content != null && content.ContentType.Alias == PM.IdentifyElement.ModelTypeAlias)
            {
                content.SetValue(PM.IdentifyElement.GetModelPropertyType(f => f.SID).Alias, SID);
                content.SetValue(PM.IdentifyElement.GetModelPropertyType(f => f.Birthday).Alias, Birthday);
                content.SetValue(PM.IdentifyElement.GetModelPropertyType(f => f.Gender).Alias, Gender);
                content.SetValue(PM.IdentifyElement.GetModelPropertyType(f => f.ComType).Alias, ComType);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(IdentifyData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object>() {
                {PM.IdentifyElement.GetModelPropertyType(f => f.SID).Alias, item.SID },
                {PM.IdentifyElement.GetModelPropertyType(f => f.Birthday).Alias, item.Birthday },
                {PM.IdentifyElement.GetModelPropertyType(f => f.Gender).Alias, item.Gender },
                {PM.IdentifyElement.GetModelPropertyType(f=>f.ComType).Alias, item.ComType }
            };
            return local;
        }
    }
}