
using DOHProject.Models.Common;
using DOHProject.Models.DataType;
using Newtonsoft.Json;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Agency
{
    /// <summary>
    /// 護產機構交換資料集
    /// </summary>
    public class AgencyViewModel : ViewModelBased, IContentMap<AgencyViewModel>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public AgencyViewModel() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public AgencyViewModel(IPublishedContent content)
        {

            if (content != null && content.ContentType.Alias == PM.Agency.ModelTypeAlias)
            {
                PM.Agency agency = new PM.Agency(content);
                AgencyGroupId = agency.Parent.Id;
                MainAgencyId = agency.Parent.Id;
                Agency = LocalMap(agency);
                Id = agency.Id;
                PId = agency.Parent.Id;
                Name = agency.Name;
            }
        }
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
            return new AgencyViewModel(content);
        }

        /// <summary>
        /// 設定資料源內容（來自交換資料集） 
        /// </summary>
        /// <param name="content">(參照)資料源</param>
        /// <param name="index">(參照)資料源為陣列</param>
        public void Set(ref IContent content, int index = 0)
        {
            content.Name = Name;

            // content => agency
            if (content.ContentType.Alias == PM.Agency.ModelTypeAlias)
            {
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyID).Alias, Agency.AgencyId);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyName).Alias, Agency.AgencyName);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.IsHQ).Alias, Agency.IsHQ);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyAlias).Alias, Agency.AgencyAlias);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AgencyStatus).Alias, Agency.AgencyStatus);
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.AccreditationType).Alias, Agency.AccreditationName);
                //設定地址模組
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.Address).Alias, JsonConvert.SerializeObject(new AddressData().Set(Agency.Address)));
                //設定通訊模組
                content.SetValue(PM.Agency.GetModelPropertyType(f => f.Address).Alias, JsonConvert.SerializeObject(new TELData().Set(Agency.Telephone)));

            }
            else if (content.ContentType.Alias == PM.Contacts.ModelTypeAlias)
            {
                //設定人員模組
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PersonName).Alias, JsonConvert.SerializeObject(new NameData().Set(Agency.Contacts.Name)));
                //設定辨識模組
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PersonIdentify).Alias, JsonConvert.SerializeObject(new IdentifyData().Set(Agency.Contacts.Identity)));
                //設定地址模組
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PersonAddress).Alias, JsonConvert.SerializeObject(new AddressData().Set(Agency.Contacts.Address)));
                //設定通訊模組
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PersonTel).Alias, JsonConvert.SerializeObject(new TELData().Set(Agency.Contacts.TELData)));
                //設定職業模組
                content.SetValue(PM.Contacts.GetModelPropertyType(f => f.PersonOccupation).Alias, JsonConvert.SerializeObject(new OccupationData().Set(Agency.Contacts.Occupation)));
            }
            else if (content.ContentType.Alias == PM.Principal.ModelTypeAlias)
            {
                //設定人員模組
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.PersonName).Alias, JsonConvert.SerializeObject(new NameData().Set(Agency.Principal.Name)));
                //設定辨識模組
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.PersonIdentify).Alias, JsonConvert.SerializeObject(new IdentifyData().Set(Agency.Principal.Identity)));
                //設定地址模組
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.PersonAddress).Alias, JsonConvert.SerializeObject(new AddressData().Set(Agency.Principal.Address)));
                //設定通訊模組
                content.SetValue(PM.Principal.GetModelPropertyType(f => f.PersonTel).Alias, JsonConvert.SerializeObject(new TELData().Set(Agency.Principal.TELData)));
            }
        }
        private AgencyItem LocalMap(PM.Agency agency)
        {
            AgencyItem item = new AgencyItem();
            item.AgencyAlias = agency.AgencyAlias;
            item.AgencyId = agency.AgencyID;
            item.AgencyName = agency.AgencyName;

            int temp = 0;
            int.TryParse(agency.AgencyStatus, out temp);
            item.AgencyStatus = temp;
            item.IsHQ = agency.IsHQ;
            item.Address = new DataType.AddressData(agency.Address);

            PM.Contacts c = agency.Children<PM.Contacts>().FirstOrDefault(x => x.ContentType.Alias == PM.Contacts.ModelTypeAlias);
            item.Contacts = LocalMapForContacts(c);
            PM.Principal p = agency.Children<PM.Principal>().FirstOrDefault(x => x.ContentType.Alias == PM.Principal.ModelTypeAlias);
            item.Principal = LocalMapForPricipal(p);
            item.AccreditationName = agency.AccreditationType;
            return item;
        }
        private PersonContact LocalMapForContacts(PM.Contacts c)
        {
            return new Common.PersonContact
            {
                Address = new DataType.AddressData(c.PersonAddress),
                Identity = new DataType.IdentifyData(c.PersonIdentify),
                Name = new DataType.NameData(c.PersonName),
                Occupation = new DataType.OccupationData(c.PersonOccupation),
                TELData = new DataType.TELData(c.PersonTel)
            };
        }
        private PersonPrincipal LocalMapForPricipal(PM.Principal p)
        {
            return new Common.PersonPrincipal
            {
                Address = new DataType.AddressData(p.PersonAddress),
                Identity = new DataType.IdentifyData(p.PersonIdentify),
                Name = new DataType.NameData(p.PersonName),
                TELData = new DataType.TELData(p.PersonTel),
                IsPartTime = p.IsPartTime
            };
        }
    }
}