using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog3.Models;

namespace TravelBlog3.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        DataContext db = new DataContext();

        public ActionResult Index()
        {

            return RedirectToAction("Index","Blog");
         
        }
    }
}