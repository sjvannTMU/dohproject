using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 人員模組
    /// </summary>
    public class NameData
    {
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 姓 -  Last Name
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// 名 - First Name
        /// </summary>
        public string GiveName { get; set; }
        /// <summary>
        /// 暱稱
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }
    }
}