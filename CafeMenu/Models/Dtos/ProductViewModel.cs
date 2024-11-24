using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models.Dtos
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceUSD { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public List<PropertyViewModel> Properties { get; set; }

        public decimal CurrencyRateUSD { get; set; }

    }

    public class PropertyViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}