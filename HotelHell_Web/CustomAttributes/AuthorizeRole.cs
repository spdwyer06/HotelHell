using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHell_Web.CustomAttributes
{
    public class AuthorizeRole : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // If they are not authorized, do this
            if (!this.AuthorizeCore(filterContext.HttpContext))
                filterContext.Result = new RedirectResult("~/Account/Unauthorized");

            base.OnAuthorization(filterContext);

            // If they are authorized, do this
            //if (this.AuthorizeCore(filterContext.HttpContext))
            //{
            //    base.OnAuthorization(filterContext);
            //}

            //filterContext.Result = new RedirectResult("~/Account/Unauthorized");
            //filterContext.Result = new RedirectResult("~/Shared/Unauthorized");

        }
    }
}