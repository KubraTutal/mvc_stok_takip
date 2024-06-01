using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstokyucedag.Models.entity;


namespace mvcstokyucedag.Controllers
{
    public class musteriController : Controller
    {
        // GET: musteri
        mvcdbstokEntities db = new mvcdbstokEntities();
        public ActionResult Index( string p)
        {
            var deger = from d in db.tblmusteriler select d;

            if(!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(m => m.musteriad.Contains(p));
            }


            return View(deger.ToList());
            //var deger=db.tblmusteriler.ToList();
            //return View(deger);
        }

        [HttpGet]
        public ActionResult yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yenimusteri(tblmusteriler p2)
        {
            if(!ModelState.IsValid)
            {
                return View("yenimusteri");
            }


            db.tblmusteriler.Add(p2);
            db.SaveChanges();
            return View();

        }

        public ActionResult sil(int id)
        {
            var mstr = db.tblmusteriler.Find(id);
            db.tblmusteriler.Remove(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult musterigetir(int id)
        {
            var mstr = db.tblmusteriler.Find(id);
            return View("musterigetir", mstr);

        }
        public ActionResult guncelle(tblmusteriler p2)
        {
            var mus = db.tblmusteriler.Find(p2.musteriID);
            mus.musteriad = p2.musteriad;
            mus.musterisoyad = p2.musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}