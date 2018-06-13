using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public AuthenticationFilter()
        {

        }
        public AuthenticationFilter(string role)
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("USER_BO")))
            {
                context.Result = new RedirectToActionResult("Login", "Authentication", new { area = "" });
            }
        }
    }
}
