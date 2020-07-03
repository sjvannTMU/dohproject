using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 評鑑資料
    /// </summary>
    public class EvaluationData
    {
        /// <summary>
        /// 評鑑年度 - 民國年
        /// </summary>
        public int EvaluateYear { get; set; }
        /// <summary>
        /// 評鑑申請開始時間
        /// </summary>
        public DateTime ApplyStartDate { get; set; }
        /// <summary>
        /// 評鑑申請結束時間
        /// </summary>
        public DateTime ApplyEndDate { get; set; }
    }
}