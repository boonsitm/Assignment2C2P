using Assignment2C2P.Domain.Implementation.Transactions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment2C2P.DataAccess
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Transaction> Transactions { get; set; }
    }
}
