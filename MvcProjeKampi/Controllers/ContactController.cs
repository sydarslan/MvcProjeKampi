using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv=new ContactValidator();
        public ActionResult Index()
        {
            var contactvalue = cm.GetList();
            return View(contactvalue);
        }
        
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues=cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}