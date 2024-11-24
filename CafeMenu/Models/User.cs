using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}