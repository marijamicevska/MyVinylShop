using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVinylShop.Models
{
    public class Vinyl
    {
        [Key]
        public int VinylId { get; set; }
        public int ArtistId { get; set; }
        public int YearId { get; set; }
        public int GenreId { get; set; }
        [Display (Name ="Vinyl")]
        public string VinylName { get; set; }
        [Display(Name = "Price")]
        public decimal VinylPrice { get; set; }
        [Display(Name = "Release")]
        public string Release { get; set; }
        public string Description { get; set; }
        public string VinylURL { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Year Year { get; set; }
        public virtual Genre Genre { get; set; }

    }
}