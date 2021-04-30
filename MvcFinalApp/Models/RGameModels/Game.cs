using MvcFinalApp.Models.ManageModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.RGameModel
{
    public class Game:BaseModel
    {
        
        public string Description { get; set; }
        public string DownloadLink { get; set; }
        public string Confirm { get; set; }
        public DateTime CreateDate { get; set; }
        public float Size { get; set; }
        public string Language { get; set; }
        public string Processor { get; set; }
        public int RamSize { get; set; }
        public string GraphicsCard { get; set; }
        public string DiskSpace { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string GamePhoto { get; set; }
        

    }
}