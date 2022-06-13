using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactAllQuery : IRequest<IEnumerable<ContactPost>>
    {

        public class ContactAllQueryHandler : IRequestHandler<ContactAllQuery, IEnumerable<ContactPost>>
        {
            readonly AdhiraDbContext db;
            public ContactAllQueryHandler(AdhiraDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<ContactPost>> Handle(ContactAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
