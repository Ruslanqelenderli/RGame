using MvcFinalApp.Models.ManageModel;
using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.ViewModels
{
    public class ProfileViewModel
    {
        public List<Game> Games { get; set; }
        public User User { get; set; }
    }
}