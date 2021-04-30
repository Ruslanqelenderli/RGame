using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.ManageModel
{
    public class User:BaseModel
    {
        public  User()
        {
            Games = new HashSet<Game>();
        }
        
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string UserPhoto { get; set; }
        public virtual ICollection<Game> Games { get; set; }

    }
}