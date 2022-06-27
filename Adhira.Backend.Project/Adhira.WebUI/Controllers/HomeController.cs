using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdhiraDbContext db;

        public HomeController(AdhiraDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactPost model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = ModelState.SelectMany(ms => ms.Value.Errors).First().ErrorMessage
                });
            }
            await db.ContactPosts.AddAsync(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                message = "Muracietiniz qeyde alindi!"
            });
        }
    }
}
