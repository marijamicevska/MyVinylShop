using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyVinylShop.Models;

namespace MyVinylShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private int Exists(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.VinylId.ToString().Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Buy(string id)
        {
            ProductModel productModel = new ProductModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = Exists(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index","Vinyls");
        }

        public ActionResult Remove(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = Exists(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

    }
}