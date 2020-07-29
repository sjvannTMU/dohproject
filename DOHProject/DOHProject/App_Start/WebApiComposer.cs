using System.Web.Http;
using Umbraco.Core.Composing;

namespace DOHProject.App_Start
{
    /// <summary>
    /// Web API產生器
    /// </summary>
    public class WebApiComposer :IUserComposer
    {
        /// <summary>
        /// 產生
        /// </summary>
        /// <param name="composition"></param>
        public void Compose(Composition composition)
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
          
        }

       
    }
}