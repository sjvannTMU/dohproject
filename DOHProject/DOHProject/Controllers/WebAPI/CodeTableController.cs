using DOHProject.Models.CodeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOHProject.Controllers.WebAPI
{
    public class CodeTableController : Umbraco.Web.WebApi.UmbracoApiController
    {
        public IEnumerable<TableCodeItem> GetAreaTable()
        {

            return null;
        }

    }
}
