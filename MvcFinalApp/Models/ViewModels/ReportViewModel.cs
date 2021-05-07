using MvcFinalApp.Models.ManageModel;
using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.ViewModels
{
    public class ReportViewModel
    {
        public List<Game> Games { get; set; }
        public List<Category> Categories { get; set; }
        public List<Game> ThisGames { get; set; }
        public List<User> Users { get; set; }


    }
}