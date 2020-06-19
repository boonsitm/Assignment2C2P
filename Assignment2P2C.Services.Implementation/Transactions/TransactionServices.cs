using Assignment2P2C.BusinessLogic.Transactions;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Services.Transactions;
using System.Collections.Generic;

namespace Assignment2P2C.Services.Implementation.Transactions
{
    public class TransactionServices : ITransactionServices
    {
        readonly private ITransactionBusinessLogic _businessLogic;
        public TransactionServices(ITransactionBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        public IList<ITransaction> GetAllTransactions()
        {
            return _businessLogic.GetAll();
        }

        public IList<ITransaction> GetTransactionsByCriteria(ITransactionCriteria criteria)
        {
            return _businessLogic.GetByCriteria(criteria);
        }

        public void InsertTransaction(ITransaction transaction)
        {
            _businessLogic.Add(transaction);
        }
    }
}
