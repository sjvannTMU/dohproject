using DOHProject.Models.DataType;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Composition
{
    /// <summary>
    /// 評鑑經驗資料
    /// </summary>
    public class EvaluationGroup : ViewModelBased, IContentMap<EvaluationGroup>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public EvaluationGroup() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public EvaluationGroup(PM.EvaluationControl content)
        {
            Evaluation = new EvaluationData().Get((IPublishedContent)content.EvaluationItem);
          
        }
        /// <summary>
        /// 評鑑資料
        /// </summary>
        public EvaluationData Evaluation { get; set; }

        /// <summary>
        /// 取得交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public EvaluationGroup Get(IPublishedContent content)
        {
            if (content != null && content.ContentType.Alias == PM.EvaluationControl.ModelTypeAlias)
            {
                return new EvaluationGroup((PM.EvaluationControl)content);
            }
            return new EvaluationGroup();
        }
        /// <summary>
        /// 設定資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            content.Name = Name;
            if (content.ContentType.Alias == PM.EvaluationControl.ModelTypeAlias)
            { 
                //設定評鑑模組
                content.SetValue(PM.EvaluationControl.GetModelPropertyType(f => f.EvaluationItem).Alias, JsonConvert.SerializeObject(new EvaluationData().Set(Evaluation)));
            }
        }
    }
}