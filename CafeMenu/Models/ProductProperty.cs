using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class ProductProperty
    {
        public int ProductPropertyID { get; set; }
        public int ProductID { get; set; }
        public int PropertyID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
    }
}