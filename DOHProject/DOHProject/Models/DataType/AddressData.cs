using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 地址模組
    /// </summary>
    public class AddressData : IContentMap<AddressData>, IElementMap<AddressData>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public AddressData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="item"></param>
        public AddressData(PM.AddressElement item)
        {
            AreaId = item.AreaCode;
            AreaName = item.AreaName;
            ZipCode = item.ZipCode;
            ZipName = item.ZipName;
            StreeLine = item.StressAddress;
            AddresstType = item.AddressType.Name;
        }
        /// <summary>
        /// 縣市代碼
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 縣市名稱
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 郵遞區號代碼 - 鄉鎮市區代碼
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 鄉鎮市區名稱
        /// </summary>
        public string ZipName { get; set; }

        /// <summary>
        /// 街道名稱
        /// </summary>
        public string StreeLine { get; set; }
        /// <summary>
        /// 地址類別
        /// </summary>
        public string AddresstType { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 設交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public AddressData Get(IPublishedContent content)
        {
            return new AddressData((PM.AddressElement)content);
        }
        /// <summary>
        /// 取交換元序列
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(AddressData data)
        {
            Dictionary<string, object> local = new Dictionary<string, object>
            {
                { PM.AddressElement.GetModelPropertyType(f => f.AreaCode).Alias, data.AreaId },
                { PM.AddressElement.GetModelPropertyType(f => f.AreaName).Alias, data.AreaName },
                { PM.AddressElement.GetModelPropertyType(f => f.ZipCode).Alias, data.ZipCode },
                { PM.AddressElement.GetModelPropertyType(f => f.ZipName).Alias, data.ZipName },
                { PM.AddressElement.GetModelPropertyType(f => f.StressAddress).Alias, data.StreeLine },
                { PM.AddressElement.GetModelPropertyType(f => f.AddressType).Alias, data.AddresstType },
                { PM.AddressElement.GetModelPropertyType(f => f.WebSite).Alias, data.Website }
            };
            return local;
        }
        /// <summary>
        /// 取資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if (content != null && content.ContentType.Alias == PM.AddressElement.ModelTypeAlias)
            {
                content.SetValue(PM.AddressElement.GetModelPropertyType(f => f.AreaCode).Alias, AreaId);
                content.SetValue(PM.AddressElement.GetModelPropertyType(f => f.AreaName).Alias, AreaName);
                content.SetValue(PM.AddressElement.GetModelPropertyType(f => f.ZipCode).Alias, ZipCode);
                content.SetValue(PM.AddressElement.GetModelPropertyType(f => f.ZipName).Alias, ZipName);
                content.SetValue(PM.AddressElement.GetModelPropertyType(f => f.StressAddress).Alias, StreeLine);
            }
        }
    }
}