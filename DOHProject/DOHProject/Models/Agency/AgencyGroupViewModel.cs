using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Models.Agency
{
    public class AgencyGroupViewModel : ViewModelBased, IContentMap<AgencyGroupViewModel>
    {
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

        public void Set(ref IContent content)
        {
            content.Name = Name;
        }
    }
}