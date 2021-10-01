using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVinylShop.Models
{
    public class ProductModel
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Vinyl> vinyls;
        public ProductModel()
        {
            this.vinyls = db.Vinyls.ToList();
        }
        public List<Vinyl> findAll()
        {
            return this.vinyls;
        }
        public Vinyl find(string id)
        {
            return this.vinyls.Single(p => p.VinylId.ToString().Equals(id));
        }
    }
   
}