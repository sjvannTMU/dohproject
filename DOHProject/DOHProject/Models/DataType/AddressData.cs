using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 地址模組
    /// </summary>
    public class AddressData
    {
        /// <summary>
        /// 縣市代碼
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 縣市名稱
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 郵遞區號代碼 - 鄉鎮市區代碼
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 鄉鎮市區名稱
        /// </summary>
        public string ZipName { get; set; }

        /// <summary>
        /// 街道名稱
        /// </summary>
        public string StreeLine { get; set; }
     }
}