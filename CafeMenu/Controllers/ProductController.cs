using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly CafeMenuContext _context = new CafeMenuContext();

        // GET: Product List
        public ActionResult Index()
        {
            var products = _context.Products.Where(p => !p.IsDeleted).ToList();
            return View(products);
        }

        // GET: Add Product Page
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            return View();
        }

        // POST: Add Product to Database
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                product.CreatorUserID = 1; // Sabit kullanıcı ID (örnek)
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            return View(product);
        }

        // GET: Edit Product Page
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || product.IsDeleted)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            return View(product);
        }

        // POST: Edit Product in Database
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(product.ProductID);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.CategoryID = product.CategoryID;
                    existingProduct.Price = product.Price;
                    existingProduct.ImagePath = product.ImagePath;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            return View(product);
        }

        // POST: Delete Product
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.IsDeleted = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}