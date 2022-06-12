using Microsoft.EntityFrameworkCore;

namespace Adhira.WebUI.Models.DataContexts
{
    public class AdhiraDbContext : DbContext
    {
        public AdhiraDbContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
