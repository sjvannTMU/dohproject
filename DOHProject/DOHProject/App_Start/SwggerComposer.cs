﻿using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Composing;

namespace DOHProject.App_Start
{
    public class SwggerComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            GlobalConfiguration.Configuration.EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "照護司共通交換標準");
                  c.ResolveConflictingActions(a => a.First());
                

              }).EnableSwaggerUi();
        }
    }
}