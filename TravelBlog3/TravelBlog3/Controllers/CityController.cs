using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog3.Models;

namespace TravelBlog3.Controllers
{
    public class CityController : Controller
    {
        DataContext db = new DataContext();
        // GET: City
        public ActionResult Index()
        {
            var cities = db.Citys.ToList();
            return View(cities);
        }

        public ActionResult Blogs(int id)
        {
            var city = db.Citys.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            var blogs = db.Blogs.Where(b => b.CityId == id).ToList();
            ViewBag.CityName = city.Name;
            return View(blogs);
        }

        public PartialViewResult Recent()
        {
            var blog = db.Blogs.Take(5).ToList();
            return PartialView(blog);
        }

        public ActionResult Hakkimda()
        {
            var cities = db.Citys.ToList();
            return View(cities);
        }
        public ActionResult Iletisim()
        {
            return View();
        }
    }
}