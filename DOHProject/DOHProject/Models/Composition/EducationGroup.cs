using DOHProject.Models.DataType;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Composition
{
    /// <summary>
    /// 學歷資料
    /// </summary>
    public class EducationGroup :ViewModelBased, IContentMap<EducationGroup>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public EducationGroup() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public EducationGroup(PM.EducationControl content)
        {
            School = new SchoolData().Get((IPublishedContent)content.School);
            Degree = content.DegLevel;
            GraduationYear = content.DegYear;
        }

        /// <summary>
        /// 學校資料
        /// </summary>
        public SchoolData School { get; set; }
        /// <summary>
        /// 學位
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// 畢業年度
        /// </summary>
        public string GraduationYear { get; set; }
        /// <summary>
        /// 是否有畢業
        /// </summary>
        public bool IsGraduation { get; set; }

        /// <summary>
        /// 取得交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public EducationGroup Get(IPublishedContent content)
        {
            if (content != null && content.ContentType.Alias == PM.EducationControl.ModelTypeAlias)
            {
                return new EducationGroup((PM.EducationControl)content);
            }
            return new EducationGroup();
        }
        /// <summary>
        /// 設定資料元
        /// </summary>
        /// <param name="content"></param>
        public void Set(ref IContent content)
        {
            content.Name = content.Name;
            if (content != null && content.ContentType.Alias == PM.EducationControl.ModelTypeAlias)
            {
                content.SetValue(PM.EducationControl.GetModelPropertyType(f => f.DegYear).Alias, GraduationYear);
                content.SetValue(PM.EducationControl.GetModelPropertyType(f => f.DegLevel).Alias, Degree);
                //設定學校模組
                content.SetValue(PM.EducationControl.GetModelPropertyType(f => f.School).Alias, JsonConvert.SerializeObject(new SchoolData().Set(School)));
            }
        }
    }
}