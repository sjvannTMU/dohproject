using DOHProject.Models.Committee;
using DOHProject.Repository.Committee;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Web.WebApi;

namespace DOHProject.Controllers.WebAPI
{
    /// <summary>
    /// 儲備委員管理
    /// </summary>
    [RoutePrefix("api/committee")]
    public class CommitteeController : UmbracoApiController, IRESTfulOperation<CommitteeViewModel>
    {
        private readonly CommitteeRepository _cr;
        /// <summary>
        /// 建構元
        /// </summary>
        public CommitteeController()
        {
            this._cr = new CommitteeRepository(Services.ContentService, Umbraco);
        }

        /// <summary>
        /// 刪除特定儲備委員
        /// </summary>
        /// <param name="id">儲備委員流水號</param>
        /// <returns></returns>
        /// <response code="404">此儲備委員不存在</response>
        /// <response code="200">成功刪除此儲備委員</response>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var node = _cr.GetById(id);
            if(node == null)
            {
                return NotFound();
            }
            else
            {
                _cr.Delete(id);
                return Ok();
            }
        }
        /// <summary>
        /// 取得特定之儲備委員
        /// </summary>
        /// <param name="id">儲備委員流水號</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="404">查無此儲備委員</response>
        [ResponseType(typeof(CommitteeViewModel))]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var node = _cr.GetById(id);
            return (node == null) ? NotFound() : (IHttpActionResult)Json(node);
        }
        /// <summary>
        /// 取得所有儲備委員
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<CommitteeViewModel>))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll(int id = 0)
        {
            return Json(_cr.GetAll());
        }
        /// <summary>
        /// 新增儲備委員
        /// </summary>
        /// <param name="model">儲備委員交換資料模組</param>
        /// <returns></returns>
        /// <response code="409">同一身份證號之委員已存在</response>
        /// <response code ="201">已新增儲備委員</response>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(CommitteeViewModel model)
        {
            try
            {
                var node = _cr.Create(model);
                return Ok(node);
            }
            catch(SystemException e)
            {
                return Content(System.Net.HttpStatusCode.Conflict, e.Message);
            }
        }

        /// <summary>
        /// 更新儲備委員
        /// </summary>
        /// <param name="id">儲備委員流水號</param>
        /// <param name="model">儲備委員交換集</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody] CommitteeViewModel model)
        {
            var node = _cr.GetById(id);
            return (node != null) ? Ok(_cr.Update(model)) : (IHttpActionResult)NotFound();
        }
    }
}
