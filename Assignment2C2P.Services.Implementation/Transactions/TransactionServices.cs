using Assignment2C2P.BusinessLogic.Transactions;
using Assignment2C2P.Domain.Transactions;
using Assignment2C2P.Services.Transactions;
using System.Collections.Generic;

namespace Assignment2C2P.Services.Implementation.Transactions
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
