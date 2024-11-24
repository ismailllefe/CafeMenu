using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models.Dtos
{
    public class CategoryProductCountViewModel
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
    }
}