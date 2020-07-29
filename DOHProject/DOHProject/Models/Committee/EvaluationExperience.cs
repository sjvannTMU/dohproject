using DOHProject.Models.CodeTable;

namespace DOHProject.Models.DataType
{
    /// <summary>
    /// 評鑑經歷
    /// </summary>
    public class EvaluationExperience
    {
        /// <summary>
        /// 參與評鑑年度
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 本次評鑑參與的領域
        /// </summary>
        public TableCodeItem Domain { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
    }
}