using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog3.Models;

namespace TravelBlog3.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Username = model.Username, Mail = model.Mail, Password = model.Password, RoleId = 2 };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "City");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["Username"] = user.Username;
                Session["RoleId"] = user.RoleId;

                if (user.RoleId == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else  
                {
                    return RedirectToAction("Index", "City");
                }
            }
            else
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "City");
        }
    }
}