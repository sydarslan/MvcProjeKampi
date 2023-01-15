using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterEmail"];
            var writeridinfo=c.Writers.Where(x=>x.WriterEmail==p).Select(y=>y.WriterId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterEmail"];
            var writeridinfo = c.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            content.ContentDate =DateTime.Parse( DateTime.Now.ToShortTimeString());
            content.WriterId = writeridinfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}