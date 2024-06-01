using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstokyucedag.Models.entity;

namespace mvcstokyucedag.Controllers
{
    public class satisController : Controller
    {
        // GET: satis
        mvcdbstokEntities db = new mvcdbstokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult yenisatis()
        {



            return View();
        }
        [HttpPost]
        public ActionResult yenisatis(tblsatis p)
        {

            db.tblsatis.Add(p);
            db.SaveChanges();


            return View("Index");
        }





    }
}