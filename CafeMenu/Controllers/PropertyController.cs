using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class PropertyController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();

        public ActionResult Index()
        {
            var properties = _context.Properties.ToList();
            return View(properties);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Property property)
        {
            if (ModelState.IsValid)
            {
                _context.Properties.Add(property);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(property);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }


        [HttpPost]
        public ActionResult Edit(Property property)
        {
            if (ModelState.IsValid)
            {
                var existingProperty = _context.Properties.Find(property.PropertyID);
                if (existingProperty != null)
                {
                    existingProperty.Key = property.Key;
                    existingProperty.Value = property.Value;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(property);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var property = _context.Properties.Find(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
