using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 學校資料
    /// </summary>
    public class SchoolData : IContentMap<SchoolData>, IElementMap<SchoolData>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public SchoolData() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public SchoolData(IPublishedContent content)
        {
            if(content != null && content.ContentType.Alias == PM.SchoolElement.ModelTypeAlias)
            {
                PM.SchoolElement item = new PM.SchoolElement(content);
                SchoolCode = item.SchoolCode;
                SchoolName = item.SchoolName;
                Department = item.Department;
            }
        }
        /// <summary>
        /// 學校代碼
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 系所名稱
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public SchoolData Get(IPublishedContent content)
        {
            return new SchoolData(content);
        }
        /// <summary>
        /// 設資料源
        /// </summary>
        /// <param name="content">(參照)資料源 School</param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            if(content != null && content.ContentType.Alias == PM.SchoolElement.ModelTypeAlias)
            {
                content.SetValue(PM.SchoolElement.GetModelPropertyType(f => f.SchoolCode).Alias, SchoolCode);
                content.SetValue(PM.SchoolElement.GetModelPropertyType(f => f.SchoolName).Alias, SchoolName);
                content.SetValue(PM.SchoolElement.GetModelPropertyType(f => f.Department).Alias, Department);
            }
        }
        /// <summary>
        /// 取得交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(SchoolData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object> {
                { PM.SchoolElement.GetModelPropertyType(f => f.SchoolCode).Alias, SchoolCode },
                { PM.SchoolElement.GetModelPropertyType(f => f.SchoolName).Alias, SchoolName },
                { PM.SchoolElement.GetModelPropertyType(f => f.Department).Alias, Department }
        };
            return local;
        }
    }
}