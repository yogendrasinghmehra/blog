using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blogs.Models;
using blogs.Areas.Admin.Models;

namespace blogs.Controllers
{
   [AllowAnonymous]
  
    public class HomeController : Controller
    {
       private  dbContext db = new dbContext();
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
       
     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
      
        public ActionResult Tag(int id)
        {
            var subjects = db.Tags.Where(i=>i.TagId==id).ToList();
            return View(subjects);
        }
       
       public ActionResult Blog(int id)
        {
            var topic = db.Blogs.Where(i => i.BlogId == id).SingleOrDefault();
            return View(topic);
        }

       
        public ActionResult subjectsList()
        {

            var subjects = db.Tags.ToList();
            return PartialView("SubjectsList", subjects);
        }
    }
}