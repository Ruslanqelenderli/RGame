using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.ViewModels
{
    public class AddGameViewModel
    {
        public List<Category> Categories { get; set; }
        public Game Game { get; set; }

    }
}