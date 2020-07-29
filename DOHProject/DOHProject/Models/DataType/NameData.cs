using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;
namespace DOHProject.Models.DataType
{
    /// <summary>
    /// D003 人員模組
    /// </summary>
    public class NameData : IContentMap<NameData>, IElementMap<NameData>
    {
        #region 欄位區
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 姓 -  Last Name
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// 名 - First Name
        /// </summary>
        public string GivenName { get; set; }
        /// <summary>
        /// 暱稱
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }

        #endregion
        /// <summary>
        /// 建構元
        /// </summary>
        public NameData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="item"></param>
        public NameData(PM.NameElement item)
        {
            FullName = item.FullName ?? (item.FamilyName + item.GivenName);
            GivenName = item.GivenName;
            FamilyName = item.FamilyName;
            NickName = item.NickName;
        }
        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public NameData Get(IPublishedContent content)
        {
            return new NameData((PM.NameElement)content);
        }
        /// <summary>
        /// 取資料源
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if (content != null && content.ContentType.Alias == PM.NameElement.ModelTypeAlias)
            {
                content.SetValue(PM.NameElement.GetModelPropertyType(f => f.FullName).Alias, FullName);
                content.SetValue(PM.NameElement.GetModelPropertyType(f => f.FamilyName).Alias, FamilyName);
                content.SetValue(PM.NameElement.GetModelPropertyType(f => f.GivenName).Alias, GivenName);
                //content.SetValue(PM.NameElement.GetModelPropertyType(f => f.NickName).Alias, NickName);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(NameData data)
        {
            Dictionary<string, object> local = new Dictionary<string, object>
            {
                { PM.NameElement.GetModelPropertyType(f => f.FullName).Alias, data.FullName },
                { PM.NameElement.GetModelPropertyType(f => f.FamilyName).Alias, data.FamilyName },
                { PM.NameElement.GetModelPropertyType(f => f.GivenName).Alias, data.GivenName }
            };
            return local;
        }
    }
}