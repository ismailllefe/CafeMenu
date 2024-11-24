using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();
        public ActionResult Index()
        {
            var categories = _context.Categories.Where(c => !c.IsDeleted).ToList();

            ViewBag.Message = "Category";

            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            ViewBag.Message = "Add New Category";

            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.IsDeleted = false; 
                category.CreatorUserID = 1; 

                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(category); 
        }
    }
}