using MvcFinalApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Areas.Manage.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}