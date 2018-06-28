using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Study.Auth0.Server.Filters
{
    public class WithRolesAttribute : ActionFilterAttribute
    {
        public List<string> Roles { get; set; }

        public WithRolesAttribute(string roles)
        {
            Roles = roles.Split(',').ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string roleClaimType = Startup.RolesNamespace;
            if (!actionContext.HttpContext.User.HasClaim(c => c.Type == roleClaimType))
            {
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            var role = actionContext.HttpContext.User?.FindFirst(c => c.Type == roleClaimType)?.Value ?? "";
            if (!Roles.Contains(role))
            {
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}