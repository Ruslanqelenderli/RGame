using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.RoleEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcFinalApp.Areas.Manage.Controllers
{
    public class AdminController : Controller
    {
        RGameDbContext db = new RGameDbContext();
        // GET: Manage/Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            if (Email != null &&
                Password != null)
            {
                UserService service = new UserService(db);
                var all = service.GetAll();
                foreach (var item in all)
                {
                    if (item.Email == Email && Crypto.VerifyHashedPassword(item.Password, Password))
                    {
                        
                        if (item.Role == Role.Admin.ToString())
                        {
                            Session["Login"] = "Loginned";

                            Session["User"] = item;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            Session["LoginCheck"] = "LoginCheck";
                            return RedirectToAction("Login","Admin");
                        }
                        
                    }

                }
            }

            Session["LoginCheck"] = "LoginCheck";
            return RedirectToAction("Login");


        }
    }
}