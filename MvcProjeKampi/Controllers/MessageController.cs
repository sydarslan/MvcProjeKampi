using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
        var messagelist=mm.GetListSendbox();
            return View(messagelist);
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values=mm.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results =mv.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message); 
                return RedirectToAction("Sendbox");
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

    }
}