﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

namespace DOHProject.Models.CodeTable
{
    /// <summary>
    /// 參照表-項目
    /// </summary>
    public class TableCodeItem
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string CodeItemID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string CodeItemName { get; set; }
    }
}