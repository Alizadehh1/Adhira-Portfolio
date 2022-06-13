using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.BlogPostModule
{
    public class BlogPostSingleQuery : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public class BlogPostSingleQueryHandler : IRequestHandler<BlogPostSingleQuery, BlogPost>
        {
            readonly AdhiraDbContext db;
            public BlogPostSingleQueryHandler(AdhiraDbContext db)
            {
                this.db = db;
            }
            public async Task<BlogPost> Handle(BlogPostSingleQuery request, CancellationToken cancellationToken)
            {

                var blog = await db.BlogPosts
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedById == null, cancellationToken);

                return blog;
            }
        }
    }
}
