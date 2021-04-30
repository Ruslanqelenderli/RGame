using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.ConfirmEnum;
using MvcFinalApp.Filter;
using MvcFinalApp.Models.ManageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Areas.Manage.Controllers
{
    [Auth]
    public class ProjectController : Controller
    {
        RGameDbContext db = new RGameDbContext();
        // GET: Manage/Project
        public ActionResult Index()
        {
            GameService service = new GameService(db);
            UserService userService = new UserService(db);
            CategoryService categoryService = new CategoryService(db);
            var games = service.GetAll().Where(x => x.Confirm == Confirm.Incorrect.ToString()).ToList();
            return View(games);
        }
        public ActionResult Yes(int id)
        {
            GameService service = new GameService(db);
            var game = service.GetById(id);
            db.Entry(game).State= EntityState.Modified;
            game.Confirm = Confirm.Correct.ToString();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult No()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult No(int id,string Message)
        {
            UserService service = new UserService(db);
            GameService game = new GameService(db);
            var user = service.GetById(game.GetById(id).UserId);
            var admin = Session["User"] as User;
            MailMessage mail = new MailMessage(admin.Email, user.Email);
            mail.Subject = "You have a message from RGame.";
            mail.Body = Message;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.DeliveryMethod=SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(admin.Email,admin.EmailPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            var game1 = game.GetById(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads/GameImage"), game1.GamePhoto));
            
            db.Games.Remove(game1);
            db.SaveChanges();
            return RedirectToAction("Index");
            

            
        }
    }
}