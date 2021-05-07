using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Filter
{
    public class AuthAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Login"] == null)
            {
                filterContext.Result = new RedirectResult("~/Manage/Admin/Login") ;
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}