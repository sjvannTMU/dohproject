using DOHProject.Models.Agency;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Repository.Agency
{
    public class AgencyGroupRepository : RepositoryBased<AgencyGroupViewModel>
    {
        private UmbracoHelper _helper;

        public AgencyGroupRepository(IContentService service, UmbracoHelper helper):base(service)
        {
            this._helper = helper;
        }
        public override AgencyGroupViewModel Create(AgencyGroupViewModel model)
        {
            IContent p = model.PId != 0 ? GetNode(model.PId) : GetUnGroupNode(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias);
            IContent content = CreateNewNode(p.Id, PM.AgencyGroup.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);

            return model.Get(_helper.Content(content));
        }
        public override AgencyGroupViewModel Create(int pid, AgencyGroupViewModel model)
        {
            IContent content = CreateNewNode(pid, PM.Agency.ModelTypeAlias, model.Name);
            model.Set(ref content);
            return model.Get(_helper.Content(content));
        }
        public override AgencyGroupViewModel GetById(int id)
        {
            return new AgencyGroupViewModel().Get(_helper.Content(id));
        }
        public override IQueryable<AgencyGroupViewModel> GetAll(int pid = 0)
        {
            IList<AgencyGroupViewModel> rList = new List<AgencyGroupViewModel>();
            IEnumerable<IContent> childNodes = SetupNodes(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias, pid);
            if(childNodes != null && childNodes.Any())
            {
                foreach(IContent item in childNodes)
                {
                    var cc = _helper.Content(item.Id);
                    var ag = new AgencyGroupViewModel().Get(cc);
                    rList.Add(ag);
                }
            }
            return rList.AsQueryable();
        }
        public override AgencyGroupViewModel Update(AgencyGroupViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model), MESSAGE_ERROR_UPDATENULL);
            var content = model.Id != 0 ? GetNode(model.Id) : null;
            if(content == null)
            {
                return model;
            }
            else
            {
                model.Set(ref content);
                SaveAndPublish(content);
                return model.Get(_helper.Content(content));
            }
           
        }

    }
}