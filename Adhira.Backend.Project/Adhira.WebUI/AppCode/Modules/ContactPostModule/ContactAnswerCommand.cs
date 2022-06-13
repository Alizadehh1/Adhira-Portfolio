using Adhira.WebUI.AppCode.Extensions;
using Adhira.WebUI.Models.DataContexts;
using Adhira.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Adhira.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactAnswerCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Cannot be Empty")]
        [MinLength(3, ErrorMessage = "Cannot be less than three symbol")]
        public string Answer { get; set; }
        public class ContactAnswerCommandHandler : IRequestHandler<ContactAnswerCommand, ContactPost>
        {
            readonly AdhiraDbContext db;
            readonly IActionContextAccessor ctx;
            public ContactAnswerCommandHandler(AdhiraDbContext db,IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<ContactPost> Handle(ContactAnswerCommand request, CancellationToken cancellationToken)
            {
                l1:
                if (!ctx.ModelIsValid())
                {
                    return new ContactPost
                    {
                        Answer = request.Answer,
                        Id = request.Id
                    };
                }

                var post = await db.ContactPosts
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (post==null)
                {
                    ctx.AddModelError("AnswerMessage", "Not Found");
                    goto l1;
                }
                else if(post.AnswerByUserId != null)
                {
                    ctx.AddModelError("AnswerMessage", "Already Answered");
                }
                post.AnswerByUserId = 1;
                post.AnsweredDate = DateTime.UtcNow.AddHours(4);
                post.Answer = request.Answer;
                await db.SaveChangesAsync(cancellationToken);
                return post;
            }
        }
    }
}
