using Microsoft.EntityFrameworkCore;
using Assignment2C2P.Domain.Implementation.Transactions;

namespace Assignment2C2P.DataAccess.Implementation
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
            base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
