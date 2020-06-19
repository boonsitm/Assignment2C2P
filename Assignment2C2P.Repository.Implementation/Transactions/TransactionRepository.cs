using Assignment2C2P.DataAccess.Implementation;
using Assignment2C2P.Domain.Implementation.Transactions;
using Assignment2C2P.Domain.Transactions;
using Assignment2C2P.Repository.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2C2P.Repository.Implementation.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ITransaction Add(ITransaction entity)
        {
            _context.Transactions.Add(entity as Transaction);
            _context.SaveChanges();
            return GetByTransactionId(entity.TransactionId);
        }

        public IList<ITransaction> GetAll()
        {
            return _context.Transactions.ToList<ITransaction>();
        }

        public ITransaction GetByTransactionId(string id)
        {
            return _context.Transactions.FirstOrDefault(x => x.TransactionId.Equals(id));
        }
    }
}
