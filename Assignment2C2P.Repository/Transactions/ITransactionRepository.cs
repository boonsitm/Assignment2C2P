using Assignment2C2P.Domain.Transactions;

namespace Assignment2C2P.Repository.Transactions
{
    public interface ITransactionRepository : IRepository<ITransaction>
    {
        ITransaction GetByTransactionId(string id);
    }
}
