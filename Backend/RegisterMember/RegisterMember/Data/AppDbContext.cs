using Microsoft.EntityFrameworkCore;
using RegisterMember.Model;

namespace RegisterMember.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Members> members => Set<Members>();
    }
}
