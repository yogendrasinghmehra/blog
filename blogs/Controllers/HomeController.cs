using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blogs.Models;
using blogs.Areas.Admin.Models;
using System.Data.Entity;

namespace blogs.Controllers
{
   [AllowAnonymous]
  
    public class HomeController : Controller
    {
       private  dbContext db = new dbContext();
        public ActionResult Index()
        {
            var ip = Request.ServerVariables["REMOTE_ADDR"];
            var ip2 = Request.UserHostAddress;
            return View(db.Blogs.OrderByDescending(i => i.CreatedDate).ToList());
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
            var subjects = db.Blogs.Where(i => i.TagId == id).ToList();
            
          var tagName=db.Tags.Where(i => i.TagId == id).SingleOrDefault();
          ViewBag.TagName = tagName.TagName;
            return View(subjects);
        }
       
       public ActionResult Blog(int id)
        {
            var topic = db.Blogs.Where(i => i.BlogId == id).SingleOrDefault();
            var like_status = db.like_details.Any(i => i.IpAddress == Request.UserHostAddress && i.BlogId == topic.BlogId && i.LikeStatus == true);
            ViewBag.likeStatus = like_status;
            return View(topic);
        }

       
        public ActionResult subjectsList()
        {

            var subjects = db.Tags.ToList();
           
            
           var  results = from p in db.Tags
                          join pp in db.Blogs on p.TagId equals pp.TagId into g
                          select new TagResult
                          {
                              TagId = p.TagId,
                              TagName = p.TagName,
                              TotalCount = g.Count()
                          };
           List<TagResult> tagResult = results.ToList();

           return PartialView("SubjectsList", results);
        }

       //Adding  likes and dislikes
       public JsonResult AddLike(int id,bool status)
        {
            if (id!=0)
            {
                likes_detail likeDetails = new likes_detail
                {
                    BlogId=id,
                    IpAddress=Request.UserHostAddress,
                    LikeStatus=status,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now
                    
                };
                var ifExists = db.like_details.Where(i => i.BlogId == id && i.IpAddress == Request.UserHostAddress).SingleOrDefault();
                if (ifExists != null)
                {
                    ifExists.LikeStatus = status;
                    db.Entry(ifExists).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.like_details.Add(likeDetails);
                    db.SaveChanges();

                }

               
            }
            return Json("hii");

        }

    }
}