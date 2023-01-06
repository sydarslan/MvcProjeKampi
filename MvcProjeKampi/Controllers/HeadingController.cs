using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues=hm.GetHeadingList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetCategoryList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value=x.CategoryId.ToString()
                                                   }).ToList();
            List<SelectListItem> writervalues = (from x in wm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.WriterName + " " + x.WriterSurname,
                                                       Value = x.WriterId.ToString()
                                                   }).ToList();
            ViewBag.wv = writervalues;
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        public ActionResult ContentByHeading()
        {
            return View();
        }

    }
}