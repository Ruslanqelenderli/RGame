using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.AdminSettings
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        public string SiteIcon { get; set; }
        public string Footer { get; set; }
    }
}