using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    }
}