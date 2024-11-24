using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorUserID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    }
}