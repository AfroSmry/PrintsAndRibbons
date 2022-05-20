using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintsAndRibbons.Models.Accounts;

namespace PrintsAndRibbons.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Ribbon> ribbons { get; set; }
        public DbSet<Print> prints { get; set; }
    }
}
