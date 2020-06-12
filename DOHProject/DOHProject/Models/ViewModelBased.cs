using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

namespace DOHProject.Models
{
    public class ViewModelBased
    {
        /// <summary>
        /// 目前節點
        /// </summary>
        public int ContentId { get; set; }
        /// <summary>
        /// 父節點
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 回傳節點
        /// </summary>
        public int? ReturnId { get; set; }
        /// <summary>
        /// 多國語言時之主節點
        /// </summary>
        public int? SiteId { get; set; }
        /// <summary>
        /// 會員節點
        /// </summary>
        public int? MemberId { get; set; }
        /// <summary>
        /// 是否為根節點
        /// </summary>
        public bool IsRoot { get; set; }

        public EnumMaintainType MaintainType { get; set; }
         public virtual string IsRequired(string name, string className)
        {
            return (name != null) ? "<em class='" + className + "' title='必填欄位' aria-hidden='true'></em>" : string.Empty;
        }

    }
}