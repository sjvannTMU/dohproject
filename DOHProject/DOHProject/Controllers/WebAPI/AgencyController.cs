using DOHProject.Controllers.WebAPI;
using DOHProject.Models.Agency;
using DOHProject.Repository.Agency;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using Umbraco.Web.WebApi;
using PM = Umbraco.Web.PublishedModels;

namespace DOHProject.Controllers
{
    /// <summary>
    /// 機構管理
    /// </summary>
    [RoutePrefix("api/agencies")]
    public class AgencyController : UmbracoApiController, IRESTfulOperation<AgencyViewModel>
    {

        private AgencyRepository _ar;
        private AgencyGroupRepository _agr;
        public AgencyController()
        {
            _ar = new AgencyRepository(Services.ContentService, Umbraco);
            _agr = new AgencyGroupRepository(Services.ContentService, Umbraco);
        }
        #region Agency部份
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Json(_ar.GetAll());
        }

        [HttpGet]
        [Route("{pid}/agencies")]
        public IHttpActionResult GetAll(int pid)
        {
            return Json(_ar.GetAll(pid));
        }
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var node = _ar.GetById(id);
            return (node == null) ? NotFound() : (IHttpActionResult)Json(node);
        }
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var node = _ar.GetNode(id);
            if (node == null)
            {
                return NotFound();
            }
            else
            {
                _ar.Delete(node);
                return Ok();
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] AgencyViewModel model)
        {
            var node = _ar.GetById(id);
            return node != null ? Ok(_ar.Update(model)) : (IHttpActionResult)NotFound();
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(AgencyViewModel model)
        {
            try
            {
                var node = _ar.Create(model);
                return Ok(node);
            }
            catch (System.Exception e)
            {
                return Content(System.Net.HttpStatusCode.Conflict, e.Message);
              
            }
           
        }
        [HttpPost]
        [Route("{pid}")]
        public IHttpActionResult Post(int pid, AgencyViewModel model)
        {
            var node = _ar.Create(pid, model);
            return Ok(node);
        }

        #endregion
        #region AgencyGroup

        [HttpGet]
        [Route("Groups")]
        public IHttpActionResult GetAllGroup()
        {
            var root = _agr.GetRootNode(PM.AgencyRoot.ModelTypeAlias);
            return Json(_agr.GetAll(root.Id));
        }

        [HttpGet]
        [Route("Groups/{id}")]
        public IHttpActionResult GetGroup(int id)
        {
            return Json(_agr.GetById(id));
        }

        [HttpPost]
        [Route("Groups")]
        public IHttpActionResult PostGroup(AgencyGroupViewModel model)
        {
            var root = _agr.GetRootNode(PM.AgencyRoot.ModelTypeAlias);
            var node = _agr.Create(root.Id, model);
            return Ok(node);
        }
        #endregion

    }
}
