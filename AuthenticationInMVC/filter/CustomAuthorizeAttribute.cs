using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationInMVC.filter
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userIdentity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var claims = userIdentity.Claims;
                var roles = claims.Where(c => c.Type == "Role").ToList();

                if (allowedRoles.Contains(roles[0].Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller","Account" },
                        {"action","Login" }
                    });
            }

            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"action","Unauthorized" }
                });
        }
    }
}