using Assignment2P2C.Domain.Implementation.Transactions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment2P2C.DataAccess
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Transaction> Transactions { get; set; }
    }
}
