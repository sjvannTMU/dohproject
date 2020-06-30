using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 職業相關
    /// </summary>
    public class Occupation
    {
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 職務名稱
        /// </summary>
        public string JobTitle { get; set; }
    }
}