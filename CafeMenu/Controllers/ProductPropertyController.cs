using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class ProductPropertyController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();

        public ActionResult Index()
        {
            var productProperties = _context.ProductProperties
                .Include("Product")
                .Include("Property")
                .ToList();
            return View(productProperties);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Products = _context.Products.Where(p => !p.IsDeleted).ToList();
            ViewBag.Properties = _context.Properties.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductProperty productProperty)
        {
            if (ModelState.IsValid)
            {
                _context.ProductProperties.Add(productProperty);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Products = _context.Products.Where(p => !p.IsDeleted).ToList();
            ViewBag.Properties = _context.Properties.ToList();
            return View(productProperty);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productProperty = _context.ProductProperties.Find(id);
            if (productProperty == null)
            {
                return HttpNotFound();
            }

            ViewBag.Products = _context.Products.Where(p => !p.IsDeleted).ToList();
            ViewBag.Properties = _context.Properties.ToList();
            return View(productProperty);
        }

        [HttpPost]
        public ActionResult Edit(ProductProperty productProperty)
        {
            if (ModelState.IsValid)
            {
                var existingProductProperty = _context.ProductProperties.Find(productProperty.ProductPropertyID);
                if (existingProductProperty != null)
                {
                    existingProductProperty.ProductID = productProperty.ProductID;
                    existingProductProperty.PropertyID = productProperty.PropertyID;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Products = _context.Products.Where(p => !p.IsDeleted).ToList();
            ViewBag.Properties = _context.Properties.ToList();
            return View(productProperty);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var productProperty = _context.ProductProperties.Find(id);
            if (productProperty != null)
            {
                _context.ProductProperties.Remove(productProperty);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
