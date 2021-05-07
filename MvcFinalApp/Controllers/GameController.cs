using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.ConfirmEnum;
using MvcFinalApp.Enums.RoleEnum;
using MvcFinalApp.Filter;
using MvcFinalApp.Models.ManageModel;
using MvcFinalApp.Models.RGameModel;
using MvcFinalApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcFinalApp.Controllers
{
    [Auth]
    public class GameController : Controller
    {
        RGameDbContext db = new RGameDbContext();
        // GET: Game
        public ActionResult UserProfile()
        {
            GameService service = new GameService(db);
            User user = Session["User"] as User;

            var games = service.GetAll().Where(x => x.UserId == user.Id).Where(x=>x.Confirm==Confirm.Correct.ToString()).ToList();
            ProfileViewModel view = new ProfileViewModel()
            {
                Games = games,
                User = user
            };

            return View(view);
        }

        public ActionResult EditUser(int id)
        {
            UserService service = new UserService(db);
            var user = service.GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user, HttpPostedFileBase UserPhoto)
        {
            if (UserPhoto != null)
            {


                if (UserPhoto.ContentLength > 1048576)
                {
                    Session["FileSize"] = "File size is a big";
                    RedirectToAction("Edit", "Project", new { id = user.Id });
                }
                if (UserPhoto.ContentType != "image/jpeg" && UserPhoto.ContentType != "image/jpg" && UserPhoto.ContentType != "image/gif" && UserPhoto.ContentType != "image/png")
                {
                    Session["FileSize"] = "Incorrect type";
                    RedirectToAction("Edit", "Project", new { id = user.Id });
                }
                string date = DateTime.Now.ToString("yyMMddHHmmss");
                string fileName = date + UserPhoto.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads/UserImage"), fileName);
                UserPhoto.SaveAs(path);
                user.UserPhoto = fileName;
                User proj = db.Users.Find(user.Id);
                if (proj.UserPhoto != "UserPhoto.png")
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads/UserImage"), proj.UserPhoto));
                }
                
                db.Entry(proj).State = EntityState.Detached;
            }

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                var userP = Session["User"] as User;
                if (UserPhoto == null)
                {
                    //db.Entry(user).Property(p => p.UserPhoto).IsModified = false;
                    user.UserPhoto = userP.UserPhoto;

                }
                if (user.Password != null)
                {
                    string hashed = Crypto.HashPassword(user.Password);
                    user.Password = hashed;
                }
                user.Role = Role.User.ToString();
                
                user.Password = userP.Password;
                

                db.SaveChanges();
                Session["User"] = user;

                return RedirectToAction("EditUser");
            }
            
            return View(user);
            
        }

        public ActionResult AddGame()
        {
            CategoryService service = new CategoryService(db);
            GameService game = new GameService(db);
            var games = new Game();
            var categories = service.GetAll();
            
            ViewBag.Categories = categories;

            return View(games);
        }

        [HttpPost]
        public ActionResult AddGame(Game game, HttpPostedFileBase GamePhoto,int SizeVersion)
        {
            try
            {
                CategoryService catservice = new CategoryService(db);
                var categories = catservice.GetAll();

                ViewBag.Categories = categories;
                if (ModelState.IsValid)
                {
                    if (GamePhoto != null)
                    {
                        if (GamePhoto.ContentLength > 1048576)
                        {
                            ModelState.AddModelError("PhotoLenght", "Please add correct Photo.");
                            return View(game);
                        }
                        if (GamePhoto.ContentType != "image/jpeg" && GamePhoto.ContentType != "image/jpg" && GamePhoto.ContentType != "image/gif" && GamePhoto.ContentType != "image/png")
                        {
                            ModelState.AddModelError("PhotoLenght", "Please add correct Photo.");
                            return View(game);
                        }
                    }



                    string date = DateTime.Now.ToString("yyMMddHHmmss");
                    string fileName = date + GamePhoto.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads/GameImage"), fileName);
                    GamePhoto.SaveAs(path);
                    if (SizeVersion==1)
                    {
                        float size = game.Size;
                        size = size / 1024;
                        game.Size = size;
                    }
                    game.GamePhoto = fileName;
                    GameService service = new GameService(db);
                    game.Confirm = Confirm.Incorrect.ToString();
                    game.CreateDate = DateTime.Now;
                    var user = Session["User"] as User;
                    game.UserId = user.Id;
                    service.Add(game);
                    db.SaveChanges();
                    Session["GameAddAdmin"] = true;
                    return RedirectToAction("UserProfile", "Game");
                }
                
                return View(game);
            }
            catch (Exception)
            {

                ModelState.AddModelError("Size", "Please add correct Size.");
                CategoryService catservice = new CategoryService(db);
                var categories = catservice.GetAll();

                ViewBag.Categories = categories;
                return View(game);
            }
            
        }


        public ActionResult EditGame(int id)
        {
            GameService service = new GameService(db);
            CategoryService category = new CategoryService(db);
            var categories = category.GetAll();
            var game = service.GetById(id);

            ViewBag.Categories = categories;
            return View(game);
        }

        [HttpPost]
        public ActionResult EditGame(Game game, HttpPostedFileBase GamePhoto,int SizeVersion)
        {
            try
            {
               
                CategoryService category = new CategoryService(db);
                var categories = category.GetAll();
                ViewBag.Categories = categories;
                if (ModelState.IsValid)
                {
                    if (GamePhoto != null)
                    {


                        if (GamePhoto.ContentLength > 1048576)
                        {
                            ModelState.AddModelError("PhotoLenght", "Please add correct Photo.");
                            return View(game);
                        }
                        if (GamePhoto.ContentType != "image/jpeg" && GamePhoto.ContentType != "image/jpg" && GamePhoto.ContentType != "image/gif" && GamePhoto.ContentType != "image/png")
                        {
                            ModelState.AddModelError("PhotoLenght", "Please add correct Photo.");
                            return View(game);
                        }
                        string date = DateTime.Now.ToString("yyMMddHHmmss");
                        string fileName = date + GamePhoto.FileName;
                        string path = Path.Combine(Server.MapPath("~/Uploads/GameImage"), fileName);
                        GamePhoto.SaveAs(path);
                        if (SizeVersion == 1)
                        {
                            float size = game.Size;
                            size = size / 1024;
                            game.Size = size;
                        }
                        game.GamePhoto = fileName;
                        Game proj = db.Games.Find(game.Id);
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads/GameImage"), proj.GamePhoto));
                        db.Entry(proj).State = EntityState.Detached;
                    }


                    game.Confirm = Confirm.Incorrect.ToString();
                    db.Entry(game).State = EntityState.Modified;

                    if (GamePhoto == null)
                    {
                        db.Entry(game).Property(p => p.GamePhoto).IsModified = false;
                        db.Entry(game).Property(p => p.UserId).IsModified = false;
                        db.Entry(game).Property(p => p.CreateDate).IsModified = false;

                    }

                    db.SaveChanges();
                    return RedirectToAction("UserProfile"); ;
                }
                return View(game);
            }
            catch (Exception)
            {
                CategoryService category = new CategoryService(db);
                var categories = category.GetAll();
                ViewBag.Categories = categories;
                ModelState.AddModelError("Size", "Please add correct Size.");
                return View(game);
            }
            
        }
        public ActionResult Delete(int id)
        {
            Game proj = db.Games.Where(x => x.Id == id).FirstOrDefault();
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads/GameImage"), proj.GamePhoto));
            Game project = db.Games.Find(id);
            db.Games.Remove(project);
            db.SaveChanges();
            return RedirectToAction("UserProfile");
        }
    }
}