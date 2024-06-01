using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstokyucedag.Models.entity;

namespace mvcstokyucedag.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        mvcdbstokEntities db=new mvcdbstokEntities();
        public ActionResult Index()
        {
            var degerler=db.tblurunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult urunekle()
        {
            List<SelectListItem> degerler=(from i in db.tblkategoriler.ToList() select new SelectListItem
            {
                Text=i.kategoriad,
                Value=i.kategoriID.ToString()
            }).ToList();
            ViewBag.dgr=degerler;
            return View();
        }

        [HttpPost]
        public ActionResult urunekle(tblurunler p3)
        {

            var ktg = db.tblkategoriler.Where(s => s.kategoriID == p3.tblkategoriler.kategoriID).FirstOrDefault();

            p3.tblkategoriler = ktg;

            db.tblurunler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var urun = db.tblurunler.Find(id);
            db.tblurunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult urungetir(int id)
        {
            var urun = db.tblurunler.Find(id);

            List<SelectListItem> degerler = (from i in db.tblkategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            

            return View("urungetir", urun);

        }

        public ActionResult guncelle(tblurunler p3)
        {
            var urun = db.tblurunler.Find(p3.urunID);
            urun.urunad=p3.urunad;
            urun.urunstok=p3.urunstok;
            urun.urunmarka = p3.urunmarka;
            urun.urunfiyat=p3.urunfiyat;
            // urun.urunkategori=p3.urunkategori;

            var ktg = db.tblkategoriler.Where(s => s.kategoriID == p3.tblkategoriler.kategoriID).FirstOrDefault();

            urun.urunkategori = ktg.kategoriID;


            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}