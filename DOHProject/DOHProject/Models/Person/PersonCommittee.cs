using DOHProject.Models.CodeTable;
using DOHProject.Models.Composition;
using DOHProject.Models.DataType;
using System.Collections.Generic;


namespace DOHProject.Models.Common
{
    /// <summary>
    /// 委員資料
    /// </summary>
    public class PersonCommittee
    {
        /// <summary>
        /// 委員中文姓名
        /// </summary>
        public NameData ChineseName { get; set; }
        /// <summary>
        /// 委員英文名稱
        /// </summary>
        public NameData EnglishName { get; set; }
        /// <summary>
        /// 委員身份辨識
        /// </summary>
        public IdentifyData Identity { get; set; }
        /// <summary>
        /// 委員住家地址
        /// </summary>
        public AddressData HomeAddress { get; set; }
        /// <summary>
        /// 委員戶籍地址
        /// </summary>
        public AddressData ResidentAddress { get; set; }
        /// <summary>
        /// 委員機關地址
        /// </summary>
        public AddressData OfficeAddress { get; set; }
        /// <summary>
        /// 委員聯絡方式
        /// </summary>
        public TelData TELData { get; set; }
        /// <summary>
        /// 聯絡人職業資訊
        /// </summary>
        public OccupationData Occupation { get; set; }
        /// <summary>
        /// 委員生活習慣 - 飲食
        /// </summary>
        public LifeStyleData LifeStyle { get; set; }
        /// <summary>
        /// 學歷
        /// </summary>
        public EducationGroup[] EducationHistory { get; set; }
        /// <summary>
        /// 經歷
        /// </summary>
        public ExperimentGroup[] OccupationHistoy { get; set; }
        /// <summary>
        /// 評鑑經歷
        /// </summary>
        public EvaluationGroup[] EvaluationHistory { get; set; }
        /// <summary>
        /// 迴避原因
        /// </summary>
        public string[] AvoidReason { get; set; }
        /// <summary>
        /// 領域別
        /// </summary>
        public TableCodeItem[] DomainList { get; set; }
    }
}