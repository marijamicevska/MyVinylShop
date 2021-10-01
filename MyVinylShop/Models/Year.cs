using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVinylShop.Models
{
    public class Year
    {
        public int YearId { get; set; }
        [Display (Name ="Release")]
     
        public int YearName { get; set; }
        public virtual List<Vinyl> Vinyls { get; set; }
    }
}