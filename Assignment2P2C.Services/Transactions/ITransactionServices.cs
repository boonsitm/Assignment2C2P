using Assignment2P2C.Domain.Transactions;
using System.Collections.Generic;

namespace Assignment2P2C.Services.Transactions
{
    public interface ITransactionServices
    {
        IList<ITransaction> GetAllTransactions();
        //IList<ITransaction> GetTransactionsByCondition();
    }
}
