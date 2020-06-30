using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOHProject.Models
{
    interface IViewModelBased
    {
        /// <summary>
        /// 目前節點
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// 父節點
        /// </summary>
        int PId { get; set; }
        /// <summary>
        /// 目前節點名稱
        /// </summary>
        string Name { get; set; }
    }
}
