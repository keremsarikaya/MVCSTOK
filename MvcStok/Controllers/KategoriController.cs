using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        UrunEntities db = new UrunEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tbl_kategoriler.ToList();
            var degerler = db.tbl_kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(tbl_kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_kategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(tbl_kategoriler p1)
        {
            var ktgr = db.tbl_kategoriler.Find(p1.kategoriid);
            ktgr.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}