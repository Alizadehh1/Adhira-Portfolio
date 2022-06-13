using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.BlogPostModule
{
    public class BlogPostAllQuery : IRequest<IEnumerable<BlogPost>>
    {
        public class BlogPostPostAllQueryHandler : IRequestHandler<BlogPostAllQuery, IEnumerable<BlogPost>>
        {
            readonly AdhiraDbContext db;
            public BlogPostPostAllQueryHandler(AdhiraDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<BlogPost>> Handle(BlogPostAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.BlogPosts
                .Where(b => b.DeletedById == null)
                .ToListAsync(cancellationToken);
                return entity;
            }
        }
    }
}
