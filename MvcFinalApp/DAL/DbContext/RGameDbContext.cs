using MvcFinalApp.Models.AdminSettings;
using MvcFinalApp.Models.ManageModel;
using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFinalApp.DAL
{
    public class RGameDbContext:DbContext
    {
        public RGameDbContext() : base("myDb") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }
}