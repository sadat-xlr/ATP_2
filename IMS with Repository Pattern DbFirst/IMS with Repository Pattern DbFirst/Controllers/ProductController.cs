using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS_with_Repository_Pattern_DbFirst.Models;
using IMS_with_Repository_Pattern_DbFirst.Repositories;

namespace IMS_with_Repository_Pattern_DbFirst.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        // GET: Product
        public ActionResult Index()
        {
            return View(productRepository.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["catagories"] = categoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)

        {
            productRepository.Insert(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["catagories"] = categoryRepository.GetAll();
            return View(productRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {   
                
            productRepository.Update(product);
                return RedirectToAction("Index");
           
           
              
            
     
           
        }
    }
}