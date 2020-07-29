using DOHProject.Models.DataType;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Composition
{
    /// <summary>
    /// 經歷資料
    /// </summary>
    public class ExperimentGroup : ViewModelBased, IContentMap<ExperimentGroup>
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public ExperimentGroup() { }
        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="content"></param>
        public ExperimentGroup(PM.ExperimentControl content)
        {
            Experiment = new OccupationData().Get((IPublishedContent)content.ExperimentItem);
           
        }
        /// <summary>
        /// 職業資料
        /// </summary>
        public  OccupationData Experiment { get; set; }
      

        /// <summary>
        /// 取得交換元
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ExperimentGroup Get(IPublishedContent content)
        {
            if (content != null && content.ContentType.Alias == PM.ExperimentControl.ModelTypeAlias)
            {
                return new ExperimentGroup((PM.ExperimentControl)content);
            }
            return new ExperimentGroup();
        }
        /// <summary>
        /// 設定資料元
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Set(ref IContent content, int index = 0)
        {
            content.Name = Name;
            if (content.ContentType.Alias == PM.ExperimentControl.ModelTypeAlias)
            {
                //設定職業模組
                content.SetValue(PM.ExperimentControl.GetModelPropertyType(f => f.ExperimentItem).Alias, JsonConvert.SerializeObject(new OccupationData().Set(Experiment)));
            }
        }
    }
}