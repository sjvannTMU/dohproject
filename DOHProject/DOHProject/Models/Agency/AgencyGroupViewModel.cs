using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Agency
{
    /// <summary>
    /// 護產機構分類群組（評鑑申報衛生局之縣市代碼）
    /// </summary>
    public class AgencyGroupViewModel : ViewModelBased, IContentMap<AgencyGroupViewModel>
    {

        /// <summary>
        /// 取得交換資料集（來自資料源）
        /// </summary>
        /// <param name="content">資料源</param>
        /// <returns>護產機構分類群組交換集-AgencyGroupViewModel</returns>
        public AgencyGroupViewModel Get(IPublishedContent content)
        {
            AgencyGroupViewModel model = new AgencyGroupViewModel();
            if(content != null && content.ContentType.Alias == PM.AgencyGroup.ModelTypeAlias)
            {
                PM.AgencyGroup ag = new PM.AgencyGroup(content);
                model.Id = ag.Id;
                model.PId = ag.Parent.Id;
                model.Name = ag.Name;
            }
          
            return model;
        }
        /// <summary>
        /// 設定護產機構分類群組
        /// </summary>
        /// <param name="content">（參照）資料源</param>
        public void Set(ref IContent content)
        {
            content.Name = Name;
        }
    }
}