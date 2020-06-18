using Microsoft.EntityFrameworkCore;
using Assignment2P2C.Domain.Implementation.Transactions;

namespace Assignment2P2C.DataAccess.Implementation
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
