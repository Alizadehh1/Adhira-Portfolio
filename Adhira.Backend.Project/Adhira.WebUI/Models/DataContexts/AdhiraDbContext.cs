using Adhira.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adhira.WebUI.Models.DataContexts
{
    public class AdhiraDbContext : DbContext
    {
        public AdhiraDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ContactPost> ContactPosts { get; set; }
    }
}
