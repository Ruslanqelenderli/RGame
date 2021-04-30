using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Game> Games { get; set; }
        public List<Game> AllGames { get; set; }
        public List<Category> Categories { get; set; }
    }
}