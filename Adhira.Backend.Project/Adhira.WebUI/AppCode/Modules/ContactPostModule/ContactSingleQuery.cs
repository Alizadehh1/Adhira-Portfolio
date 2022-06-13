using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactSingleQuery : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public class ContactSingleQueryHandler : IRequestHandler<ContactSingleQuery, ContactPost>
        {
            readonly AdhiraDbContext db;
            public ContactSingleQueryHandler(AdhiraDbContext db)
            {
                this.db = db;
            }
            public async Task<ContactPost> Handle(ContactSingleQuery request, CancellationToken cancellationToken)
            {

                var model = await db.ContactPosts
                    .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return model;
            }
        }
    }
}
