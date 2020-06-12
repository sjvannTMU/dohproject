using DOHProject.Models.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.Common
{
    public class ContactPerson
    {
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 聯絡人身份證號
        /// </summary>
        public String ContactId {get; set;}
        /// <summary>
        /// 聯絡人地址
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// 聯絡人電話
        /// </summary>
        public TELData TELData { get; set; }
        
    }
}