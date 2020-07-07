using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 生活型態
    /// </summary>
    public class LifeStyleData:IContentMap<LifeStyleData>,IElementMap<LifeStyleData>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public LifeStyleData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public LifeStyleData(IPublishedContent content)
        {
            if(content != null && content.ContentType.Alias == PM.LifeStyleElement.ModelTypeAlias)
            {
                PM.LifeStyleElement item = new PM.LifeStyleElement(content);
                Diet = item.DietType;
            }
        }
        /// <summary>
        /// 飲食：1 葷食 2 素食
        /// </summary>
        public int Diet { get; set; }
        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public LifeStyleData Get(IPublishedContent content)
        {
           return  new LifeStyleData(content);
        }
        /// <summary>
        /// 設資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if(content != null && content.ContentType.Alias == PM.LifeStyleElement.ModelTypeAlias)
            {
                content.SetValue(PM.LifeStyleElement.GetModelPropertyType(f => f.DietType).Alias, Diet);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(LifeStyleData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object> {
                { PM.LifeStyleElement.GetModelPropertyType(f => f.DietType).Alias, Diet }
            };
            return local;
        }
    }
}