using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryvalues=cm.GetCategoryList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p) 
        {
            CategoryValidator cv=new CategoryValidator(); //validatordeki koşulları sağlıyor mu
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
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
        public ActionResult CategoryDelete(int id)  //View kullanılmayacak
        {
            var categoryvalue=cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryUpdate(categoryvalue);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

    }
}