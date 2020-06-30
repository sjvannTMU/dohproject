using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    public class TELData
    {
        /// <summary>
        /// 電話-住家
        /// </summary>
        //public string TELHome { get; set; }
        /// <summary>
        /// 電話-辦公室
        /// </summary>
        public string TELOffice { get; set; }
        /// <summary>
        /// 電話分機-辦公室
        /// </summary>
        public string TELOfficeExtension { get; set; }
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
    }
}