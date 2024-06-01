using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstokyucedag.Models.entity;
using PagedList;
using PagedList.Mvc;

namespace mvcstokyucedag.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        mvcdbstokEntities db=new mvcdbstokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler=db.tblkategoriler.ToList();
            var degerler = db.tblkategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YeniKategori(tblkategoriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }

            db.tblkategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult sil(int id)
        {
            var kategori=db.tblkategoriler.Find(id);
            db.tblkategoriler.Remove(kategori); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategorigetir(int id)
        {
            var ktgr = db.tblkategoriler.Find(id);
            return View("kategorigetir",ktgr);

        }

        public ActionResult guncelle(tblkategoriler p1)
        {
            var ktg = db.tblkategoriler.Find(p1.kategoriID);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
                
                
        }

    }
}