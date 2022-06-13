using Adhira.WebUI.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Models.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public int PublishedById { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
