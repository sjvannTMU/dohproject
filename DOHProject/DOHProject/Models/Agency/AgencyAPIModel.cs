using DOHProject.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.Agency
{
    public class AgencyApiModel
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
        public string ContactId { get; set; }
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        public string ContactName { get; set; }

        public string ContactTitle { get; set; }
        public string ContactDepartment { get; set; }
        public string ContactTelOffice { get; set; }
        public string ContactTelOfficeExt { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        /// <summary>
        /// 評鑑類別名稱
        /// </summary>
        public string AccreditationName { get; set; }
        public string AreaCode { get; set; }
    }
}