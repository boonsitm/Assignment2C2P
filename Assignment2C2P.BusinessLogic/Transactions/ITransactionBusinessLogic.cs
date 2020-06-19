using Assignment2C2P.Domain.Transactions;
using System.Collections.Generic;

namespace Assignment2C2P.BusinessLogic.Transactions
{
    public interface ITransactionBusinessLogic : IBusinessLogic<ITransaction>
    {
        IList<ITransaction> GetByCriteria(ITransactionCriteria criteria);
    }
}
