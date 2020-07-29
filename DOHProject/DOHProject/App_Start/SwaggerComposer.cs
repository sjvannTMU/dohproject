using Swashbuckle.Application;
using System.Linq;
using System.Web.Http;
using Umbraco.Core.Composing;

namespace DOHProject.App_Start
{
    /// <summary>
    /// Swagger產生器
    /// </summary>
    public class SwaggerComposer : IUserComposer
    {
        /// <summary>
        /// 起始
        /// </summary>
        /// <param name="composition"></param>
        public void Compose(Composition composition)
        {
            GlobalConfiguration.Configuration.EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "照護司共通交換標準");
                  c.ResolveConflictingActions(a => a.First());
                  c.DocumentFilter<SwaggerDocumentFilter>();
                  c.IncludeXmlComments(string.Format(@"{0}\bin\SwaggerApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));

              }).EnableSwaggerUi();
        }
    }
}