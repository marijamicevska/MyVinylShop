using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVinylShop.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        public string Description { get; set; }
        public virtual List<Vinyl> Vinyls { get; set; }

    }
}