using Assignment2P2C.Domain.Transactions;
using System.Collections.Generic;

namespace Assignment2P2C.BusinessLogic.Transactions
{
    public interface ITransactionBusinessLogic : IBusinessLogic<ITransaction>
    {
        IList<ITransaction> GetByCriteria(ITransactionCriteria criteria);
    }
}
