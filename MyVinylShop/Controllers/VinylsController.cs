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
    public class VinylsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public ActionResult Index()
        {
            var vinyls = db.Vinyls.Include(v => v.Artist).Include(v => v.Genre).Include(v => v.Year);

            if (User.IsInRole("Administrator"))
            {
                 return View(vinyls.ToList());
            }
            return View("IndexCustomers", vinyls.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = db.Vinyls.Find(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VinylId,ArtistId,YearId,GenreId,VinylName,VinylPrice,Release,Description,VinylURL")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                db.Vinyls.Add(vinyl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", vinyl.GenreId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", vinyl.YearId);
            return View(vinyl);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = db.Vinyls.Find(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", vinyl.GenreId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", vinyl.YearId);
            return View(vinyl);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VinylId,ArtistId,YearId,GenreId,VinylName,VinylPrice,Release,Description,VinylURL")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vinyl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", vinyl.GenreId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", vinyl.YearId);
            return View(vinyl);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = db.Vinyls.Find(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vinyl vinyl = db.Vinyls.Find(id);
            db.Vinyls.Remove(vinyl);
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
    }
}
