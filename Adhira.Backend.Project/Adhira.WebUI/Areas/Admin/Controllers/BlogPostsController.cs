using Adhira.WebUI.AppCode.Modules.BlogPostModule;
using Adhira.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly AdhiraDbContext db;
        readonly IMediator mediator;

        public BlogPostsController(AdhiraDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogPostAllQuery query)
        {
            var entity = await mediator.Send(query);
            return View(entity);
        }

        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Edit(BlogPostSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }
            var command = new BlogPostEditCommand();
            command.Id = blog.Id;
            command.Title = blog.Title;
            command.Body = blog.Body;
            command.ImagePath = blog.ImagePath;
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, BlogPostEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BlogPostRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
