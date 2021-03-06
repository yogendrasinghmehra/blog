﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogs.Areas.Admin.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }
    }

    public class TagResult
    {
        public int  TagId { get; set; }
        public string TagName { get; set; }
        public int TotalCount { get; set; }

    }
}