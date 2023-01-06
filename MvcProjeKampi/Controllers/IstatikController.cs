using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatikController : Controller
    {
        // GET: Istatik
        Context db= new Context();

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TotolCategory()
        {
            var number = db.Categories.Count();
            return View(number);

        }

        public ActionResult WriterWithA()
        {
            var writerA = from p in db.Writers
                    where p.WriterName == "%a%"
                    select p;

            //var a = db.Writers.Where(p.WriterName.Contains("a");
            return View(writerA);
        }


    }
}