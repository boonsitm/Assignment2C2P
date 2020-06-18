using Assignment2P2C.BusinessLogic.Transactions;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Repository.Transactions;
using System.Collections.Generic;

namespace Assignment2P2C.BusinessLogic.Implementation.Transactions
{
    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        private readonly ITransactionRepository _repository;
        public TransactionBusinessLogic(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void Delete(long internalId)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Get(long internalId)
        {
            throw new System.NotImplementedException();
        }

        public IList<ITransaction> GetAll()
        {
            return _repository.GetAll();
        }

        public ITransaction Add(ITransaction item)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Update(ITransaction item)
        {
            throw new System.NotImplementedException();
        }
    }
}
