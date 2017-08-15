using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogs.Areas.Admin.Models
{
    public class Blog
    {

        [Key]
        public int BlogId { get; set; }
        public Tag Tags { get; set; }
        [Required]
        public int TagId { get; set; }
        [Required]
        public string BlogTitle { get; set; }
        [Required]
        [AllowHtml]
        public string BlogDescription { get; set; }       
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public List<Tag> TagsList { get; set; }
    }

    public class BlogMethods
    {
        //public string SaveBlogImage(HttpPostedFileBase file)
        //{

        //    var serverPath = HttpContext.Current.Server.MapPath("~/BlogImages");

        //    if (!Directory.Exists(serverPath))
        //    {
        //        Directory.CreateDirectory(serverPath);
        //    }

        //    string[] allowedImageExtensions = new string[] { ".jpg", ".png", ".jpeg", ".Jpg" };          
        //    var fileExtension = Path.GetExtension(file.FileName);
        //    if(allowedImageExtensions.Contains(fileExtension))
        //    {
        //        string newFileName = GenrateUniqueName() + fileExtension;
        //        string finalImageUrl = Path.Combine(serverPath, newFileName);
        //        file.SaveAs(finalImageUrl);
        //        return "/BlogImages/" + newFileName;
        //    }
        //    else
        //    {
        //        return "";
        //    }

                     
        //}

        //public void RemoveFile(string path)
        //{
        //    var filePath = HttpContext.Current.Server.MapPath(path);
        //    if(File.Exists(filePath))
        //    {
        //        File.Delete(filePath);
        //    }
        //}

        //public string GenrateUniqueName()
        //{
        //    Guid guid = Guid.NewGuid();
        //    return guid.ToString();
        //}

    }

 
  
  
}