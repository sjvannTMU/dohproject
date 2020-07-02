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

        private readonly AgencyRepository _ar;
        private readonly AgencyGroupRepository _agr;
        /// <summary>
        /// 建構元
        /// </summary>
        public AgencyController()
        {
            _ar = new AgencyRepository(Services.ContentService, Umbraco);
            _agr = new AgencyGroupRepository(Services.ContentService, Umbraco);
        }
        #region Agency部份
        /// <summary>
        /// 取得所有護產機構
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Json(_ar.GetAll());
        }
        /// <summary>
        /// 取得所有護產機構-從特定分類
        /// </summary>
        /// <param name="pid">分類節點代碼</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pid}/agencies")]
        public IHttpActionResult GetAll(int pid)
        {
            return Json(_ar.GetAll(pid));
        }
        /// <summary>
        /// 取得特定護產機構
        /// </summary>
        /// <param name="id">護產機構代碼</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var node = _ar.GetById(id);
            return (node == null) ? NotFound() : (IHttpActionResult)Json(node);
        }
        /// <summary>
        /// 刪除護產機構
        /// </summary>
        /// <param name="id">護產機構代碼</param>
        /// <returns></returns>
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
        /// <summary>
        /// 更新護產機構
        /// </summary>
        /// <param name="id">護產機構代碼</param>
        /// <param name="model">交換集</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] AgencyViewModel model)
        {
            var node = _ar.GetById(id);
            return node != null ? Ok(_ar.Update(model)) : (IHttpActionResult)NotFound();
        }
        /// <summary>
        /// 新增護產機構
        /// </summary>
        /// <param name="model">交換集</param>
        /// <returns></returns>
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
        /// <summary>
        /// 新增護產機構-指定特定分類
        /// </summary>
        /// <param name="pid">分類代碼</param>
        /// <param name="model">交換集</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{pid}")]
        public IHttpActionResult Post(int pid, AgencyViewModel model)
        {
            var node = _ar.Create(pid, model);
            return Ok(node);
        }

        #endregion

        #region AgencyGroup
        /// <summary>
        /// 取得所有護產機構分類
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Groups")]
        public IHttpActionResult GetAllGroup()
        {
            var root = _agr.GetRootNode(PM.AgencyRoot.ModelTypeAlias);
            return Json(_agr.GetAll(root.Id));
        }
        /// <summary>
        /// 取得特定護產機構分類
        /// </summary>
        /// <param name="id">護產機構分類代碼</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Groups/{id}")]
        public IHttpActionResult GetGroup(int id)
        {
            return Json(_agr.GetById(id));
        }
        /// <summary>
        /// 新增護產機構分類
        /// </summary>
        /// <param name="model">分類交換集</param>
        /// <returns></returns>
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
