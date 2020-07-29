using Swashbuckle.Swagger;
using System.Linq;
using System.Web.Http.Description;

namespace DOHProject.App_Start
{
    /// <summary>
    /// Swagger 文件過濾器
    /// </summary>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 應用
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths = swaggerDoc.paths.Where(x => x.Key.StartsWith("/api")).ToDictionary(e => e.Key, e => e.Value);
        }
    }
}