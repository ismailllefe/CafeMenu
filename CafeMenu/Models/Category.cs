using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorUserID { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}