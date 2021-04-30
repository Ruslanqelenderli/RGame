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
                        if (item.Role == Role.User.ToString()) { return RedirectToAction("Index", "Home"); }
                        else { return RedirectToAction("Index", "Home", new { area = "Manage" }); }
                    }
                    
                }
            }
            
                Session["LoginCheck"] = "LoginCheck";
                return RedirectToAction("Login");
            

           
        }


        [HttpPost]
        
        public ActionResult Register(User user, string PasswordAgain)
        {
            UserService service = new UserService(db);
            if (user.Email != null &&
                user.Surname != null &&
                user.PhoneNumber != 0 &&
                user.Name != null &&
                user.Password !=null)
            {
                var all = service.GetAll();
                foreach (var item in all)
                {
                    if (user.Email == item.Email)
                    {
                        Session["IncorrectCells"] = "This email has been used.";
                        return RedirectToAction("Register");
                    }
                }
                if (ModelState.IsValid && user.Password==PasswordAgain)
                {
                    
                        string hashed = Crypto.HashPassword(user.Password);
                        user.Password = hashed;
                    
                    
                    user.UserPhoto = "UserPhoto.png";
                    user.Role = Role.User.ToString();
                    user.EmailPassword = "123";
                    service.Add(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    Session["IncorrectCells"] = "Incorrect Cells";
                    return RedirectToAction("Register");
                }
            }
            else
            {
                Session["IncorrectCells"] = "Incorrect Cells";
                return RedirectToAction("Register");
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