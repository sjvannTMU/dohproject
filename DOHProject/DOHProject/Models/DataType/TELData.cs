using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 通訊模組
    /// </summary>
    public class TELData : IContentMap<TELData>, IElementMap<TELData>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public TELData()
        {

        }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="item">資料源</param>
        public TELData(PM.TelElement item)
        {
            TELOffice = item.TelephoneNumber;
            TELOfficeExtension = item.Extension;
            FaxOffice = item.Fax;
            Mobile = item.Mobile;
            EMail = item.Email;
            PhoneAreaCode = item.PhoneAreaCode;
            PhoneCountryCode = item.CountryCode;
        }
        /*
        /// <summary>
        /// 電話-住家
        /// </summary>
        //public string TELHome { get; set; }
        */
        /// <summary>
        /// 電話-辦公室
        /// </summary>
        public string TELOffice { get; set; }
        /// <summary>
        /// 電話分機-辦公室
        /// </summary>
        public string TELOfficeExtension { get; set; }
        /// <summary>
        /// 傳真 - 辦公室
        /// </summary>
        public string FaxOffice { get; set; }
        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 電子郵件
        /// 
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 電話國碼
        /// </summary>
        public string PhoneCountryCode { get; set; }
        /// <summary>
        /// 電話區域碼
        /// </summary>
        public string PhoneAreaCode { get; set; }

        /// <summary>
        /// 取交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public TELData Get(IPublishedContent content)
        {
            return new TELData((PM.TelElement)content);
        }
        /// <summary>
        /// 設資料源
        /// </summary>
        /// <param name="content"></param>
        public void Set(ref IContent content, int index= 0)
        {
            if (content != null && content.ContentType.Alias == PM.TelElement.ModelTypeAlias)
            {
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.TelephoneNumber).Alias, TELOffice);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.CountryCode).Alias, PhoneCountryCode);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.Extension).Alias, TELOfficeExtension);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.Fax).Alias, FaxOffice);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.Mobile).Alias, Mobile);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.Email).Alias, EMail);
                content.SetValue(PM.TelElement.GetModelPropertyType(f => f.PhoneAreaCode).Alias, PhoneAreaCode);
            }
        }
        /// <summary>
        /// 取交換元序列
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> Set(TELData item)
        {
            Dictionary<string, object> local = new Dictionary<string, object>
            {
                { PM.TelElement.GetModelPropertyType(f => f.TelephoneNumber).Alias, TELOffice },
                { PM.TelElement.GetModelPropertyType(f => f.CountryCode).Alias, PhoneCountryCode},
                { PM.TelElement.GetModelPropertyType(f => f.Extension).Alias, TELOfficeExtension},
                { PM.TelElement.GetModelPropertyType(f => f.Fax).Alias, FaxOffice },
                { PM.TelElement.GetModelPropertyType(f => f.Mobile).Alias, Mobile},
                { PM.TelElement.GetModelPropertyType(f => f.Email).Alias, EMail},
                { PM.TelElement.GetModelPropertyType(f => f.PhoneAreaCode).Alias, PhoneAreaCode}
            };
            return local;
        }
    }
}