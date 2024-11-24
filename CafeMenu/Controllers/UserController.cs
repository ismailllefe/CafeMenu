using CafeMenu.Helpers;
using CafeMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenu.Controllers
{
    public class UserController : Controller
    {
        private readonly CafeMenuContext _context = new CafeMenuContext();

        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user, string password)
        {
            if (ModelState.IsValid)
            {
                string salt = PasswordHelper.GenerateSalt();
                string hash = PasswordHelper.HashPassword(password, salt);

                user.SaltPassword = salt;
                user.HashPassword = hash;

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.Find(user.UserID);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Surname = user.Surname;
                    existingUser.Username = user.Username;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}