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
    public class UrunController : Controller
    {
        // GET: Urun
        UrunEntities db = new UrunEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var urunler = db.tbl_urunler.ToList();
            var urunler = db.tbl_urunler.ToList().ToPagedList(sayfa, 4);
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler p1)
        {
            var ktg = db.tbl_kategoriler.Where(x => x.kategoriid == p1.tbl_kategoriler.kategoriid).FirstOrDefault();
            p1.tbl_kategoriler = ktg;

            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(tbl_urunler p)
        {
            var urunler = db.tbl_urunler.Find(p.urunid);
            urunler.urunad = p.urunad;
            urunler.marka = p.marka;
            urunler.stok = p.stok;
            urunler.fiyat = p.fiyat;
            //urunler.urunkategori = p.urunkategori;
            var ktg = db.tbl_kategoriler.Where(x => x.kategoriid == p.tbl_kategoriler.kategoriid).FirstOrDefault();
            urunler.urunkategori = ktg.kategoriid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}