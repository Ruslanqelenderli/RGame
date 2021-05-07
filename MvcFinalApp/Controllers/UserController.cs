using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.RoleEnum;
using MvcFinalApp.Models.ManageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcFinalApp.Controllers
{
    public class UserController : Controller
    {
        // GET: Manage
        RGameDbContext db = new RGameDbContext();
  
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
                var all=service.GetAll();
                foreach (var item in all)
                {
                    if (item.Email == Email && Crypto.VerifyHashedPassword(item.Password, Password))
                    {
                        Session["Login"] = "Loginned";
                        
                        Session["User"] = item;
                        return RedirectToAction("Index", "Home"); 
                    }
                    
                }
            }
            
                Session["LoginCheck"] = "LoginCheck";
                return RedirectToAction("Login");
            

           
        }


        [HttpPost]
        
        public ActionResult Register(User user, string PasswordAgain)
        {
            if (ModelState.IsValid)
            {
                UserService service = new UserService(db);
                
                    var all = service.GetAll();
                    foreach (var item in all)
                    {
                        if (user.Email == item.Email)
                        {
                            ModelState.AddModelError("EmailCheck", "This email has been used.");
                            return View(user);
                        }
                    }
                    if (user.Password == PasswordAgain)
                    {

                        string hashed = Crypto.HashPassword(user.Password);
                        user.Password = hashed;


                        user.UserPhoto = "UserPhoto.png";
                        user.Role = Role.User.ToString();
                        user.EmailPassword = "123";
                        service.Add(user);
                        return RedirectToAction("Login", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordAgain", "Please add correct password.");
                        return View(user);
                    }
                
            }
            else
            {
                
                return View(user);
            }

            
           
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;

            return RedirectToAction("Index","Home");
        }


        public ActionResult Register()
        {
            
            return View();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}