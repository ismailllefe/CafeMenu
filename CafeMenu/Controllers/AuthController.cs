using CafeMenu.Helpers;
using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class AuthController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && PasswordHelper.VerifyPassword(password, user.HashPassword, user.SaltPassword))
            {
                Session["UserID"] = user.UserID;
                Session["Username"] = user.Username;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}