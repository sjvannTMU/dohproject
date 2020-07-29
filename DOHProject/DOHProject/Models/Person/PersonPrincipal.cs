using DOHProject.Models.DataType;

namespace DOHProject.Models.Common
{
    /// <summary>
    /// 負責人
    /// </summary>
    public struct PersonPrincipal
    {
        /// <summary>
        /// 辨識資料
        /// </summary>
        public IdentifyData Identity { get; set; }
        /// <summary>
        /// 姓名資料
        /// </summary>
        public NameData Name { get; set; }
        /// <summary>
        /// 地址資料
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// 通訊資料
        /// </summary>
        public TelData TELData { get; set; }
        /// <summary>
        /// 是否為負責人
        /// </summary>
        public bool IsPartTime { get; set; }
    }
}