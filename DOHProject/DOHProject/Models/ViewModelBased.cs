using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

namespace DOHProject.Models
{
    /// <summary>
    /// 交換資料集(ViewModel)基礎物件
    /// </summary>
    public class ViewModelBased : IViewModelBased
    {
        /// <summary>
        /// 節點代碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 父節點代碼
        /// </summary>
        public int PId { get; set; }
        /// <summary>
        /// 節點名稱
        /// </summary>
        public string Name { get; set; }
    }
}