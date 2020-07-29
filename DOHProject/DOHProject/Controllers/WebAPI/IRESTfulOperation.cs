using System.Web.Http;

namespace DOHProject.Controllers.WebAPI
{
    interface IRestfulOperation<in T> where T : class
    {

        IHttpActionResult GetAll(int id = 0);
        IHttpActionResult Get(int id);
        IHttpActionResult Put(int id, [FromBody] T model);
        IHttpActionResult Delete(int id);
        IHttpActionResult Post(T model);

    }
}
