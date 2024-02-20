using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog3.Migrations;
using TravelBlog3.Models;
using System.Data.Entity;
namespace TravelBlog3.Controllers
{
    public class BlogController : Controller
    {
        DataContext db = new DataContext();
        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.ToList();
            return View(blogs);
        }
     
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.CityId = new SelectList(db.Citys, "Id", "Name");
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
     
        public ActionResult Create(Blog blog, int? CityId)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    blog.UserId = (int)Session["UserId"];
                    blog.Date = DateTime.Now;

                    if (CityId.HasValue)
                    {
                        blog.CityId = CityId.Value;
                    }

                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index", "City");
                }

                ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", blog.CityId);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View(blog);
        }

        public ActionResult Details(int id)
        {
            var blog = db.Blogs.Include(b => b.Comments.Select(c => c.User)).FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost]

        public ActionResult AddComment(int blogId, string commentContent)
        {
            if (Session["UserId"] != null)
            {
                var blog = db.Blogs.Find(blogId);
                if (blog != null && !String.IsNullOrWhiteSpace(commentContent))
                {
                    var comment = new Comment
                    {
                        BlogId = blogId,
                        CommentContent = commentContent,
                        UserId = (int)Session["UserId"],
                    };
                    db.Comments.Add(comment);
                    db.SaveChanges();

                    // Onay mesajı oluştur
                    TempData["ConfirmationMessage"] = "Yorumunuz gönderildi, teşekkür ederiz.";
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Details", new { id = blogId });
        }

        [HttpPost]
        public ActionResult Like(int blogId)
        {
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var like = db.Like.FirstOrDefault(l => l.BlogId == blogId && l.UserId == userId);

                // Eğer kullanıcı daha önce beğenmediyse
                if (like == null)
                {
                    db.Like.Add(new Like { BlogId = blogId, UserId = userId });
                    var blog = db.Blogs.Find(blogId);
                    blog.LikeCount++;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Details", new { id = blogId });
        }

    }
}