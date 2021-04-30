using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.ConfirmEnum;
using MvcFinalApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        RGameDbContext db = new RGameDbContext();
        public ActionResult Index()
        {
            GameService gameService = new GameService(db);
            CategoryService category = new CategoryService(db);
            var games = gameService.GetAll().Where(x => x.Confirm == Confirm.Correct.ToString()).OrderByDescending(x=>x.Id).ToList();
            var allGames = gameService.GetAll().Where(x=>x.Confirm==Confirm.Correct.ToString()).ToList();
            HomeViewModel model = new HomeViewModel()
            {
                Games = games,
                Categories = category.GetAll(),
                AllGames = allGames
            };
            
            return View(model);
        }
        public ActionResult GetCategory(int id)
        {
            GameService service = new GameService(db);
            var category = service.GetById(id);
            CategoryService categoryService = new CategoryService(db);
            var games = service.GetAll().Where(x => x.CategoryId == id).Where(x => x.Confirm == Confirm.Correct.ToString()).OrderByDescending(x=>x.Id).ToList();
            var allGames = service.GetAll().Where(x => x.Confirm == Confirm.Correct.ToString()).ToList();
            HomeViewModel model = new HomeViewModel()
            {
                Games = games,
                Categories = categoryService.GetAll(),
                AllGames=allGames
            };

            return View(model);
        }
        public ActionResult Search(string Search)
        {
            GameService gameService = new GameService(db);
            CategoryService category = new CategoryService(db);
            var games = gameService.GetAll().Where(x => x.Confirm == Confirm.Correct.ToString()).Where(x=>x.Name.ToLower().Contains(Search.ToLower())).OrderByDescending(x => x.Id).ToList();
            var allGames = gameService.GetAll().Where(x => x.Confirm == Confirm.Correct.ToString()).ToList();
            HomeViewModel model = new HomeViewModel()
            {
                Games = games,
                Categories = category.GetAll(),
                AllGames = allGames
            };

            return View(model);
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