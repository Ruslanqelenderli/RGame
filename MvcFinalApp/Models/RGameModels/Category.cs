using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.RGameModel
{
    public class Category:BaseModel
    {
        public Category()
        {
            Games = new HashSet<Game>();
        }
        public virtual ICollection<Game> Games { get; set; }
    }
}