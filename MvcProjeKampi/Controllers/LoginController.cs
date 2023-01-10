﻿using DataAccessLayer.Concrete;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c=new Context();
            var adminuserinfo=c.Admins.FirstOrDefault(x=>x.AdminUserName==admin.AdminUserName && x.AdminPassword==admin.AdminPassword);
            if (adminuserinfo!=null)
            {
                //yönlendirme işlemleri
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}