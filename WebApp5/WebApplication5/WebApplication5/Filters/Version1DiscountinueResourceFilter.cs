using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Filters
{
    // Using before ActionFilter, this is Resource Filter
    // The example here is to force expire the V1 post method API
    // Then apply on the entire Ticket Controller (top of the class), so any V1 will be invalid from now
    // for globally, add this one in the startup.cs, it will apply for all controllers
    public class Version1DiscountinueResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // after executed, this one is not apply here yet
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
            {
                // so this is v1
                context.Result = new BadRequestObjectResult(
                    new
                    {
                        Versioning = new[] {"This version of the API has expired, please us the latest version one."}
                    }
                    );
            }
        }
    }
}
