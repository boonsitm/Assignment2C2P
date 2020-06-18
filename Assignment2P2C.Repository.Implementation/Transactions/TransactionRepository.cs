using Assignment2P2C.DataAccess.Implementation;
using Assignment2P2C.Domain.Implementation.Transactions;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Repository.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2P2C.Repository.Implementation.Transactions
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

        public void Delete(int internalId)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Get(int internalId)
        {
            throw new System.NotImplementedException();
        }

        public IList<ITransaction> GetAll()
        {
            return _context.Transactions.ToList<ITransaction>();
        }

        public ITransaction GetByTransactionId(string id)
        {
            return _context.Transactions.FirstOrDefault(x => x.TransactionId.Equals(id));
        }

        public ITransaction Update(ITransaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
