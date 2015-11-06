using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikken.Models;

namespace MvcMusicStore.Controllers
{
    
    public class ButikkSjefController : Controller
    {
        private Dbkontekst db = new Dbkontekst();

        public ActionResult Index()
        {
            if (Session["AdminInne"]!=null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    var varer = db.Varer.Include(a => a.Kategori);
                    return View(varer.ToList());
                }
                      
            }
 
            return RedirectToAction("Logginn", "Konto");
        }

        public ViewResult Detaljer(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Vare vare = db.Varer.Find(id);
                    return View(vare);
                }
            }
            return null;
            
        }

        public ActionResult Opprett()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    ViewBag.KategoriId = new SelectList(db.Kategorier, "KategoriId", "Navn");
                    return View();
                }
            }
            return RedirectToAction("Logginn", "Konto");
        } 

      
        [HttpPost]
        public ActionResult Opprett(Vare vare)
        {
            if (ModelState.IsValid)
            {
                db.Varer.Add(vare);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.KategoriId = new SelectList(db.Kategorier, "KategoriId", "Navn", vare.KategoriId);
            return View(vare);
        }

        public ActionResult leggTilKat()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

       
        [HttpPost]
        public ActionResult leggTilKat(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                db.Kategorier.Add(kat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kat);
        }
        public ActionResult Endre(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Vare vare = db.Varer.Find(id);
                    ViewBag.KategoriId = new SelectList(db.Kategorier, "KategoriId", "Navn", vare.KategoriId);
                    return View(vare);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

       
        [HttpPost]
        public ActionResult Endre(Vare vare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Varer, "GenreId", "Name", vare.KategoriId);
            return View();
        }

        public ActionResult Slett(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Vare vare = db.Varer.Find(id);
                    return View(vare);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        [HttpPost, ActionName("Slett")]
        public ActionResult SlettOk(int id)
        {            
            Vare album = db.Varer.Find(id);
            db.Varer.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}