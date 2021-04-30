using MvcFinalApp.DAL;
using MvcFinalApp.DAL.Services;
using MvcFinalApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFinalApp.Controllers
{
    
    public class GameInfoController : Controller
    {
        // GET: GameInfo
        RGameDbContext db = new RGameDbContext();
        public ActionResult GameInfo(int id)
        {
            GameService gameService = new GameService(db);
            var game = gameService.GetById(id);
            return View(game);
        }
    }
}