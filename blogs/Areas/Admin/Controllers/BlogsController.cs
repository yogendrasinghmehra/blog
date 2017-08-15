using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blogs.Areas.Admin.Models;
using blogs.Models;
using System.IO;

namespace blogs.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class BlogsController : Controller
    {
        private dbContext db = new dbContext();

      
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Tags);
            return View(blogs.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

       
        public ActionResult Create()
        {
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagId,BlogTitle,BlogDescription,BlogExampleUrl")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                BlogMethods blogMethods = new BlogMethods();
                blog.CreatedDate = DateTime.Now;
                blog.ModifiedDate = DateTime.Now;               
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,TagId,BlogTitle,BlogDescription,BlogExampleUrl,Status")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.ModifiedDate = DateTime.Now;
                blog.CreatedDate = DateTime.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);         
            BlogMethods methods = new BlogMethods();
           

             db.Blogs.Remove(blog);
             db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      
    }
}
