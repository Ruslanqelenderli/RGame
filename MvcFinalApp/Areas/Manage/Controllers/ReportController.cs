using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Enums.ConfirmEnum;
using MvcFinalApp.Filter;
using MvcFinalApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Areas.Manage.Controllers
{
    [Auth]
    public class ReportController : Controller
    {

        // GET: Manage/Report
        
        RGameDbContext db = new RGameDbContext();
        public ActionResult Index()
        {
            GameService gameService = new GameService(db);
            CategoryService categoryService = new CategoryService(db);
            var games = gameService.GetAll().Where(x => x.Confirm == Confirm.Correct.ToString()).ToList();
            var date = DateTime.Now;
            
            var thisgame = gameService.GetAll().Where(x => (date - x.CreateDate).Days < 31).ToList();
            var categories = categoryService.GetAll();
            ReportViewModel viewModel = new ReportViewModel()
            {
                Games = games,
                Categories = categories,
                ThisGames = thisgame
            };

            return View(viewModel);
        }
    }
}