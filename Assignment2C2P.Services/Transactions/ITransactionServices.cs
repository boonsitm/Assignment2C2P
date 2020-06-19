using Assignment2C2P.Domain.Transactions;
using System.Collections.Generic;

namespace Assignment2C2P.Services.Transactions
{
    public interface ITransactionServices
    {
        IList<ITransaction> GetAllTransactions();
        IList<ITransaction> GetTransactionsByCriteria(ITransactionCriteria criteria);
        void InsertTransaction(ITransaction transaction);
    }
}
