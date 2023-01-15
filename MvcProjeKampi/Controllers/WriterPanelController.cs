using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.FluentValidation;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm=new WriterManager(new EfWriterDal());
       
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string param = (string)Session["WriterEmail"];
            id = c.Writers.Where(x => x.WriterEmail == param).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results = writervalidator.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string param)
        {
            param = (string)Session["WriterEmail"];
            var writeridinfo=c.Writers.Where(x=>x.WriterEmail==param).Select(y=>y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        { 
            List<SelectListItem> categoryvalues = (from x in cm.GetCategoryList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string mail = (string)Session["WriterEmail"];
            var writeridinfo = c.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterId).FirstOrDefault();  
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId =writeridinfo ;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetCategoryList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            var headingvalue = hm.GetById(id);
            ViewBag.cv = categoryvalues;
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetById(id);
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int page=1)
        {

            var headings = hm.GetHeadingList().ToPagedList(page, 4);
            return View(headings);

        }
    }
}