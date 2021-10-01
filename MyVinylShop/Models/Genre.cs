using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVinylShop.Models
{
    public class Genre
    {
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
        public virtual List<Vinyl> Vinyls { get; set; }
    }
}