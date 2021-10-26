using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        UrunEntities db = new UrunEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tbl_musterıler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.musteriad.Contains(p));
            }
            return View(degerler.ToList());
            //var musteri = db.tbl_musterıler.ToList();
            //return View(musteri);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tbl_musterıler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tbl_musterıler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.tbl_musterıler.Find(id);
            db.tbl_musterıler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.tbl_musterıler.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(tbl_musterıler p1)
        {
            var mus = db.tbl_musterıler.Find(p1.musteriid);
            mus.musteriad = p1.musteriad;
            mus.musterisoyad = p1.musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}