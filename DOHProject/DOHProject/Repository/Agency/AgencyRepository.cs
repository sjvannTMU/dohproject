using DOHProject.Models.Agency;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Repository.Agency
{
    public class AgencyRepository : RepositoryBased<AgencyViewModel>
    {
        private UmbracoHelper _helper;
        
        public AgencyRepository(IContentService service, UmbracoHelper helper):base(service)
        {
            this._helper = helper;
        }
        public override AgencyViewModel Create(AgencyViewModel model)
        {
            IContent p = (model.PId != 0) ? GetNode(model.PId) : GetUnGroupNode(PM.AgencyRoot.ModelTypeAlias, PM.AgencyGroup.ModelTypeAlias);
            var childNode = GetChildNodes(p.Id, PM.Agency.ModelTypeAlias).Where(x => x.GetValue<string>(PM.Agency.GetModelPropertyType(f => f.AgencyID).Alias) == model.Agency.AgencyId);
            if (childNode != null || childNode.Any()) throw new Exception(MESSAGE_ERROR_ADDNEW);
            
            IContent content = CreateNewNode(p.Id, PM.Agency.ModelTypeAlias, model.Name);
            model.Set(ref content);
            SaveAndPublish(content);
            IContent contacts = CreateNewNode(content.Id, PM.Contacts.ModelTypeAlias, NAME_NODE_CONSTACTS);
            model.Set(ref contacts);
            SaveAndPublish(contacts);
            IContent principal = CreateNewNode(content.Id, PM.Principal.ModelTypeAlias, NAME_NODE_PRINCIPAL);
            model.Set(ref principal);
            SaveAndPublish(principal);

            return model.Get(_helper.Content(content));
        }
        public override AgencyViewModel GetById(int id)
        {
            return new AgencyViewModel().Get(_helper.Content(id));
        }
        public override IQueryable<AgencyViewModel> GetAll(int pid = 0)
        {
            IList<AgencyViewModel> rList = new List<AgencyViewModel>();
            IEnumerable<IContent> childNodes = SetupNodes(PM.AgencyRoot.ModelTypeAlias, PM.Agency.ModelTypeAlias, pid);
            if(childNodes != null && childNodes.Any())
            {
                foreach(IContent item in childNodes)
                {
                    var cc = _helper.Content(item.Id);
                    var aa = new AgencyViewModel().Get(cc);

                    rList.Add(aa);
                }
            }
            return rList.AsQueryable();
        }
        public override AgencyViewModel Update(AgencyViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model),MESSAGE_ERROR_UPDATENULL);
            var content = model.Id != 0 ? GetNode(model.Id) : null;
            if(content == null)
            {
                return model;
            }
            else
            {
                model.Set(ref content);
                SaveAndPublish(content);
                IContent contacts = GetChildNode(content.Id, PM.Contacts.ModelTypeAlias, NAME_NODE_CONSTACTS);
                model.Set(ref contacts);
                SaveAndPublish(contacts);
                IContent principal = GetChildNode(content.Id, PM.Principal.ModelTypeAlias, NAME_NODE_PRINCIPAL);
                model.Set(ref principal);
                SaveAndPublish(principal);

                return model.Get(_helper.Content(content));
            }
        }

    }
}