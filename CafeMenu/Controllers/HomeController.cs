using CafeMenu.Filters;
using CafeMenu.Helpers;
using CafeMenu.Models;
using CafeMenu.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();
        public ActionResult Index()
        {
            var categoryProductCounts = _context.Products
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new CategoryProductCountViewModel
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count()
                })
                .ToList();

            ViewBag.CategoryProductCounts = categoryProductCounts;

            return View();
        }

        public ActionResult Customer()
        {
            var currency = CurrencyHelper.GetCurreny(new DateTime(2024, 11, 15, 0, 0, 0, 0));

            var products = _context.Products.Select(p => new ProductViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price,
                ImagePath = p.ImagePath,
                CategoryName = p.Category.CategoryName,
                Properties = p.ProductProperties.Select(pp => new PropertyViewModel
                {
                    Key = pp.Property.Key,
                    Value = pp.Property.Value
                }).ToList(),
                CurrencyRateUSD = currency,
                PriceUSD = currency == 0 ? 0 : p.Price / currency,
            }).ToList();

            return View(products);
        }


    }
}