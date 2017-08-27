using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using blogs.Areas.Admin.Models;

namespace blogs.Models
{
    public class likes_detail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public Blog Blog { get; set; }
        [Required]
        public int BlogId { get; set; }
        [Required]
        public bool LikeStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}