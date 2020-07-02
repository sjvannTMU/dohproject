using DOHProject.Models.Common;
using DOHProject.Models.DataType;

namespace DOHProject.Models.Agency
{
    /// <summary>
    /// 護產機構資料欄位
    /// </summary>
    public struct AgencyItem
    {
        /// <summary>
        /// 醫事機構代碼
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 機構名稱
        /// </summary>
        public string AgencyName { get; set; }
        /// <summary>
        /// 機構簡稱
        /// </summary>
        public string AgencyAlias { get; set; }
        /// <summary>
        /// 是否為本院
        /// </summary>
        public bool IsHQ { get; set; }
        /// <summary>
        /// 開業狀態 -> 待補
        /// </summary>
        public int AgencyStatus { get; set; }
        /// <summary>
        /// 機構地址
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// 機構電話
        /// </summary>
        public TELData Telephone { get; set; }
        /// <summary>
        /// 聯絡人
        /// </summary>
        public PersonContact Contacts { get; set; }
        /// <summary>
        /// 負責人
        /// </summary>
        public PersonPrincipal Principal { get; set; }
        /// <summary>
        /// 評鑑類別名稱
        /// </summary>
        public string AccreditationName { get; set; }
    }
}