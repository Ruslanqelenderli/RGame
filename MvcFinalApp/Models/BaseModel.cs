using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please add Name.")]
        public string Name { get; set; }
    }
}