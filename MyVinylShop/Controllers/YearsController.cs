using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyVinylShop.Models;

namespace MyVinylShop.Controllers
{
    public class YearsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                return View(db.Years.ToList());

            return View("IndexCustomers", db.Years.ToList());
        }

     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearId,YearName")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Years.Add(year);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(year);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearId,YearName")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Entry(year).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(year);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Year year = db.Years.Find(id);
            db.Years.Remove(year);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult VinylsByYear(int year)
        {
            List<Vinyl> vinyls = db.Vinyls.Include(v => v.Artist).Include(v => v.Year).Include(v => v.Genre)
                .ToList();
            List<Vinyl> model = new List<Vinyl>();
            foreach(var v in vinyls)
            {
                if (v.Year.YearName.Equals(year))
                {
                    model.Add(v);
                }
            }
            
            return View(model);
        }
    }
}
