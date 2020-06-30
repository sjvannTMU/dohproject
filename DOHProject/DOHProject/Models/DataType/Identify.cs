using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    public class Identify
    {
        /// <summary>
        /// 身份證字號
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性別 1 男 2 女
        /// </summary>
        public int Gender { get; set; }
    }
}