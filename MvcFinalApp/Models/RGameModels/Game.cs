using MvcFinalApp.Models.ManageModel;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFinalApp.Models.RGameModel
{
    public class Game:BaseModel
    {
        [Required(ErrorMessage ="Please add Description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please add DownloadLink.")]

        public string DownloadLink { get; set; }
        public string Confirm { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Please add Size.")]

        public float Size { get; set; }
        [Required(ErrorMessage = "Please add Language.")]

        public string Language { get; set; }
        [Required(ErrorMessage = "Please add Processor.")]

        public string Processor { get; set; }
        [Required(ErrorMessage = "Please add RamSize.")]

        public int RamSize { get; set; }
        [Required(ErrorMessage = "Please add GraphicsCard.")]

        public string GraphicsCard { get; set; }
        [Required(ErrorMessage = "Please add DiskSpace.")]

        public string DiskSpace { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Please add GamePhoto.")]

        public string GamePhoto { get; set; }
        

    }
}