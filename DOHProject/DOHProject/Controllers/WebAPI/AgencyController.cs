using DOHProject.Models.Agency;
using Superpower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Services.Description;
using System.Web.UI.WebControls.WebParts;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace DOHProject.Controllers
{
    [RoutePrefix("api/agency")]
    public class AgencyController : Umbraco.Web.WebApi.UmbracoApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAgencies()
        {
            var agencies = Umbraco.ContentAtRoot().DescendantsOrSelf<Agency>();

            var models = agencies.Select(a => new AgencyApiModel { 
                AgencyId = a.AgencyID,
                AgencyName = a.AgencyName,
                AgencyAlias = a.AgencyAlias,
                ContactName = a.ContactName,
                ContactDepartment = a.ContactDepartment,
                ContactTitle = a.ContactTitle,
                ContactTelOffice = a.ContactTeloffice,
                ContactTelOfficeExt = a.ContactTelofficeExtension,
                ContactMobile = a.ContactTeloffice,
                ContactEmail = a.ContactEmail,
                IsHQ = a.IsHQ,
                AreaCode = a.Parent.Name,
                AccreditationName = a.AccreditationType.ToString(),
            });
            return Json(models);
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostAgency(AgencyApiModel model)
        {
            var parent = Services.ContentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == AgencyRoot.ModelTypeAlias);
           
            if(model.AgencyId.IsNullOrWhiteSpace() || model.AgencyName.IsNullOrWhiteSpace() )   //必填欄位查核
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);  //回應錯誤
            }
            else
            {   
                if(Umbraco.Content(parent.Id).Descendants<Agency>().First(x=>x.AgencyID == model.AgencyId) != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
               
                if(model.AreaCode != null)  //有群組，所以父節點改變
                {
                    int childCount = Services.ContentService.CountChildren(parent.Id);
                    parent = Services.ContentService.GetPagedChildren(parent.Id, 1, childCount, out long childNodeLength).FirstOrDefault(x => x.Name == model.AreaCode);
                }

                //寫入資料
                var content = Services.ContentService.Create(model.AgencyId, parent.Id, Agency.ModelTypeAlias);
                content.SetValue(Agency.GetModelPropertyType(f => f.AgencyID).Alias, model.AgencyId);
                content.SetValue(Agency.GetModelPropertyType(f => f.AgencyName).Alias, model.AgencyName);
                content.SetValue(Agency.GetModelPropertyType(f => f.AgencyAlias).Alias, model.AgencyAlias);
                content.SetValue(Agency.GetModelPropertyType(f => f.IsHQ).Alias, model.IsHQ);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactID).Alias, model.ContactId);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactName).Alias, model.ContactName);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactTitle).Alias, model.ContactTitle);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactDepartment).Alias, model.ContactDepartment);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactTeloffice).Alias, model.ContactTelOffice);
                content.SetValue(Agency.GetModelPropertyType(f => f.ContactTelofficeExtension).Alias, model.ContactTelOfficeExt);

                content.SetValue(Agency.GetModelPropertyType(f => f.AgencyID).Alias, model.AgencyId);



                return new HttpResponseMessage(HttpStatusCode.OK);

            }
        
        }

    }
}
