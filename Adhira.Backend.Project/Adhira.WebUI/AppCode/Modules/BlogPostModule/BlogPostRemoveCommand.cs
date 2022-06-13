using Adhira.WebUI.AppCode.Infrastructure;
using Adhira.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.BlogPostModule
{
    public class BlogPostRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int Id { get; set; }
        public class BlogPostRemoveCommandHandler : IRequestHandler<BlogPostRemoveCommand, CommandJsonResponse>
        {
            readonly AdhiraDbContext db;
            public BlogPostRemoveCommandHandler(AdhiraDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(BlogPostRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.BlogPosts
                    .FirstOrDefaultAsync(b => b.DeletedById == null && b.Id == request.Id, cancellationToken);

                if (entity==null)
                {
                    return new CommandJsonResponse(true, "Qeyd Movcud Deyil!");
                }

                entity.DeletedById = 1; //helelik
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return new CommandJsonResponse(false, "Deleted Successfully");
            }
        }
    }
}
