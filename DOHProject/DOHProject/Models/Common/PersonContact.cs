using DOHProject.Models.DataType;

namespace DOHProject.Models.Common
{
    public struct PersonContact
    {
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        public NameData Name { get; set; }
        /// <summary>
        /// 聯絡人身份證號
        /// </summary>
        public Identify Identity {get; set;}
        /// <summary>
        /// 聯絡人地址
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// 聯絡人電話
        /// </summary>
        public TELData TELData { get; set; }
        /// <summary>
        /// 聯絡人職業
        /// </summary>
        public Occupation Occupation { get; set; }
        
    }
}