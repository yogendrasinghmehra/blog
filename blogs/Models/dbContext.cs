using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using blogs.Areas.Admin.Models;

namespace blogs.Models
{
    public class dbContext:DbContext
    {
        public dbContext() : base("constr") { }

        //public DbSet<subjects> subjects { get; set; }
       // public DbSet<topics> topics { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<likes_detail> like_details { get; set; }

    }
}