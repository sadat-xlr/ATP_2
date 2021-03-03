using IMS_with_Repository_Pattern_DbFirst.Models;
using IMS_with_Repository_Pattern_DbFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_with_Repository_Pattern_DbFirst.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Catagory category)
        {
            categoryRepository.Insert(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {



            return View(categoryRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Catagory category)
        {

            categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
          
            return View(categoryRepository.Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
          
         
            return View(categoryRepository.Get(id));
        }



    }
}