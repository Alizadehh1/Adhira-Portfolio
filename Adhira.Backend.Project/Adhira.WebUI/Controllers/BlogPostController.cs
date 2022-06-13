using Adhira.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly AdhiraDbContext db;

        public BlogPostController(AdhiraDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await db.BlogPosts
                .Where(bp => bp.PublishedDate != null)
                .ToListAsync();
            return View(posts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var posts = await db.BlogPosts
                .FirstOrDefaultAsync(bp => bp.PublishedDate != null && bp.Id == id);
            return View(posts);
        }
        public async Task<IActionResult> Comment(int postId,string comment)
        {
            //var posts = await db.BlogPosts
            //    .FirstOrDefaultAsync(bp => bp.Id == postId && bp.PublishedDate != null);
            return View();
        }
    }
}
