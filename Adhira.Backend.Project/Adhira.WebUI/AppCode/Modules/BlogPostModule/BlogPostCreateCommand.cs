using Adhira.WebUI.AppCode.Extensions;
using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.BlogPostModule
{
    public class BlogPostCreateCommand : IRequest<BlogPost>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
        public class BlogPostCreateCommandHandler : IRequestHandler<BlogPostCreateCommand, BlogPost>
        {

            readonly AdhiraDbContext db;
            readonly IWebHostEnvironment env;
            readonly IActionContextAccessor ctx;
            public BlogPostCreateCommandHandler(AdhiraDbContext db, IWebHostEnvironment env,IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<BlogPost> Handle(BlogPostCreateCommand request, CancellationToken cancellationToken)
            {
                if (request?.File == null)
                {
                    ctx.AddModelError("ImagePath", "Image Cannot be empty");
                }

                if (ctx.ModelIsValid())
                {
                    string fileExtension = Path.GetExtension(request.File.FileName);
                    string name = $"blog-{Guid.NewGuid()}{fileExtension}";
                    string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", name);
                    using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                    {
                        await request.File.CopyToAsync(fs,cancellationToken);
                    }
                    var blog = new BlogPost
                    {
                        Title = request.Title,
                        Body = request.Body,
                        ImagePath = name
                    };
                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;
                }

                return null;
            }
        }
    }
}
