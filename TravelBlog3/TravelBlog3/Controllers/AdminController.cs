using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TravelBlog3.Models;
using System.Data.Entity;

namespace TravelBlog3.Controllers
{
    
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
    
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["RoleId"] != null && (int)Session["RoleId"] == 1)
            {
                // User ve City bilgileriyle birlikte tüm blogları getir.
                var blogs = db.Blogs.Include(b => b.User).Include(b => b.City).ToList();
                return View(blogs);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            ViewBag.CityId = new SelectList(db.Citys, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.UserId = (int)Session["UserId"]; 
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", blog.CityId);
            return View(blog);
        }

        public ActionResult DeleteBlog(int id)
        {
            var blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBlogById(int id)
        {
            var blog = db.Blogs.Find(id);

            return View("GetBlogById", blog);
        }

        public ActionResult UpdateBlog(Blog blog)
        {
            var updateBlog = db.Blogs.Find(blog.Id);
            updateBlog.Title = blog.Title;
            updateBlog.Description = blog.Description;
            updateBlog.Date = blog.Date;
            updateBlog.ImageUrl = blog.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentList()
        {
            var comments = db.Comments.Include(c => c.User).Include(c => c.Blog).ToList();
            return View(comments);
        }


        public ActionResult DeleteComment(int id)
        {
            var comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("CommentList");
        }

        public ActionResult GetComment(int id)
        {
            var comment = db.Comments.Find(id);

            return View("GetComment", comment);
        }
        public ActionResult UpdateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var updateComment = db.Comments.Find(comment.Id);
                if (updateComment != null)
                {
                    updateComment.CommentContent = comment.CommentContent;
                
                    db.SaveChanges();
                    return RedirectToAction("CommentList");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(comment); 
        }

    }
}
