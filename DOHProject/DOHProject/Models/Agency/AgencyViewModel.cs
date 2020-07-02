
using DOHProject.Models.Common;
using System;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Agency
{
    /// <summary>
    /// 護產機構交換資料集
    /// </summary>
    public class AgencyViewModel : ViewModelBased, IContentMap<AgencyViewModel>
    {
        /// <summary>
        /// 機構群組代碼
        /// </summary>
        public int AgencyGroupId { get; set; }
        /// <summary>
        /// 機構主院區代碼
        /// </summary>
        public int MainAgencyId { get; set; }

        /// <summary>
        /// 機構基本資料集
        /// </summary>
        public AgencyItem Agency { get; set; }

        /// <summary>
        /// 取得交換資料集（來自資料源）
        /// </summary>
        /// <param name="content">資料源</param>
        /// <returns>護產機構資料交換集-AgencyViewModel</returns>
        public AgencyViewModel Get(IPublishedContent content)
        {
            AgencyViewModel model = new AgencyViewModel();
            if (content != null && content.ContentType.Alias == PM.Agency.ModelTypeAlias)
            {
                PM.Agency agency = new PM.Agency(content);
                model.AgencyGroupId = agency.Parent.Id;
                model.MainAgencyId = agency.Parent.Id;
                model.Agency = LocalMap(agency);
                model.Id = agency.Id;
                model.PId = agency.Parent.Id;
                model.Name = agency.Name;
            }
            
            return model;
        }

        /// <summary>
        /// 設定資料源內容（來自交換資料集） 
        /// </summary>
        /// <param name="content">(參照)資料源</param>
        public void Set(ref IContent content)
        {
            content.Name = Name;
           // content => agency
           if(content.ContentType.Alias == PM.Agency.ModelTypeAlias)
            {
     
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyID).Alias, Agency.AgencyId);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyName).Alias, Agency.AgencyName);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.IsHQ).Alias, Agency.IsHQ);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyAlias).Alias, Agency.AgencyAlias);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyStatus).Alias, Agency.AgencyStatus);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.StressAddress).Alias, Agency.Address.StreeLine);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AreaCode).Alias, Agency.Address.AreaId);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AreaName).Alias, Agency.Address.AreaName);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.ZipCode).Alias, Agency.Address.ZipCode);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.ZipName).Alias, Agency.Address.ZipName);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AccreditationType).Alias, Agency.AccreditationName);

            }
           if(content.ContentType.Alias == PM.Contacts.ModelTypeAlias)
            {
               
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.StressAddress).Alias, Agency.Contacts.Address.StreeLine);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.AreaCode).Alias, Agency.Contacts.Address.AreaId);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.AreaName).Alias, Agency.Contacts.Address.AreaName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.ZipCode).Alias, Agency.Contacts.Address.ZipCode);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.ZipName).Alias, Agency.Contacts.Address.ZipName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.TelephoneNumber).Alias, Agency.Contacts.TELData.TELOffice);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.CountryCode).Alias, Agency.Contacts.TELData.PhoneCountryCode);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PhoneAreaCode).Alias, Agency.Contacts.TELData.PhoneAreaCode);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.Extension).Alias, Agency.Contacts.TELData.TELOfficeExtension);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.Email).Alias, Agency.Contacts.TELData.EMail);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.FamilyName).Alias, Agency.Contacts.Name.FamilyName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.GivenName).Alias, Agency.Contacts.Name.GiveName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.NickName).Alias, Agency.Contacts.Name.NickName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.FullName).Alias, Agency.Contacts.Name.FullName);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.Department).Alias, Agency.Contacts.Occupation.Department);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.JobTitle).Alias, Agency.Contacts.Occupation.JobTitle);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.SID).Alias, Agency.Contacts.Identity.SID);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.Birthday).Alias, Agency.Contacts.Identity.Birthday);
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.Gender).Alias, Agency.Contacts.Identity.Gender);
            }
           if(content.ContentType.Alias == PM.Principal.ModelTypeAlias)
            {
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.StressAddress).Alias, Agency.Principal.Address.StreeLine);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.AreaCode).Alias, Agency.Principal.Address.AreaId);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.AreaName).Alias, Agency.Principal.Address.AreaName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.ZipCode).Alias, Agency.Principal.Address.ZipCode);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.ZipName).Alias, Agency.Principal.Address.ZipName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.TelephoneNumber).Alias, Agency.Principal.TELData.TELOffice);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.CountryCode).Alias, Agency.Principal.TELData.PhoneCountryCode);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.PhoneAreaCode).Alias, Agency.Principal.TELData.PhoneAreaCode);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.Extension).Alias, Agency.Principal.TELData.TELOfficeExtension);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.Email).Alias, Agency.Principal.TELData.EMail);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.FamilyName).Alias, Agency.Principal.Name.FamilyName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.GivenName).Alias, Agency.Principal.Name.GiveName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.NickName).Alias, Agency.Principal.Name.NickName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.FullName).Alias, Agency.Principal.Name.FullName);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.SID).Alias, Agency.Principal.Identity.SID);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.Birthday).Alias, Agency.Principal.Identity.Birthday);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.Gender).Alias, Agency.Principal.Identity.Gender);
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.IsPartTime).Alias, Agency.Principal.IsPartTime);
            }
        }
        private AgencyItem LocalMap(PM.Agency agency)
        {

            AgencyItem item = new AgencyItem();
            item.Address = new DataType.AddressData
            {
                AreaId = agency.AgencyID
                ,
                AreaName = agency.AreaName
                ,
                StreeLine = agency.StressAddress
                ,
                ZipCode = agency.ZipCode
                ,
                ZipName = agency.ZipName
            };
            item.AgencyAlias = agency.AgencyAlias;
            item.AgencyId = agency.AgencyID;
            item.AgencyName = agency.AgencyName;
            int temp = 0;
            int.TryParse(agency.AgencyStatus,out temp);
            item.AgencyStatus = temp;
            item.IsHQ = agency.IsHQ;
            PM.Contacts c = agency.Children<PM.Contacts>().FirstOrDefault(x => x.ContentType.Alias == PM.Contacts.ModelTypeAlias);
            item.Contacts = LocaMapForContacts(c);
            PM.Principal p = agency.Children<PM.Principal>().FirstOrDefault(x => x.ContentType.Alias == PM.Principal.ModelTypeAlias);
            item.Principal = LocalMapForPricipal(p);
            item.AccreditationName = agency.AccreditationType;
            return item;
        }

        private PersonPrincipal LocalMapForPricipal(Principal p)
        {
           return new Common.PersonPrincipal
            {
                Address = new DataType.AddressData
                {
                    AreaId = p.AreaCode
                   ,
                    AreaName = p.AreaName
                   ,
                    StreeLine = p.StressAddress
                   ,
                    ZipCode = p.ZipCode
                   ,
                    ZipName = p.ZipName
                }
               ,
                Identity = new DataType.Identify
                {
                    Birthday = p.Birthday
                   ,
                    Gender = p.Gender
                   ,
                    SID = p.SID
                }
               ,
                Name = new DataType.NameData
                {
                    FamilyName = p.FamilyName
                    ,
                    GiveName = p.GivenName
                    ,
                    FullName = p.FullName
                    ,
                    NickName = p.NickName
                }
               ,
                TELData = new DataType.TELData
                {
                    TELOffice = p.TelephoneNumber
                  ,
                    TELOfficeExtension = p.Extension
                  ,
                    Mobile = p.Mobile
                  ,
                    EMail = p.Email
                }
               ,
                IsPartTime = p.IsPartTime
            };
        }

        private PersonContact LocaMapForContacts(Contacts c)
        {
            return new Common.PersonContact
            {
                Address = new DataType.AddressData
                {
                    AreaId = c.AreaCode
                     ,
                    AreaName = c.AreaName
                     ,
                    StreeLine = c.StressAddress
                     ,
                    ZipCode = c.ZipCode
                     ,
                    ZipName = c.ZipName
                }
                 ,
                Identity = new DataType.Identify
                {
                    Birthday = c.Birthday
                     ,
                    Gender = c.Gender
                     ,
                    SID = c.SID
                }
                 ,
                Name = new DataType.NameData
                {
                    FamilyName = c.FamilyName
                      ,
                    GiveName = c.GivenName
                      ,
                    FullName = c.FullName
                      ,
                    NickName = c.NickName
                }
                 ,
                Occupation = new DataType.Occupation
                {
                    Department = c.Department,
                    JobTitle = c.JobTitle
                }
                 ,
                TELData = new DataType.TELData
                {
                    TELOffice = c.TelephoneNumber
                    ,
                    TELOfficeExtension = c.Extension
                    ,
                    Mobile = c.Mobile
                    ,
                    EMail = c.Email
                }
            };
        }

    }
}