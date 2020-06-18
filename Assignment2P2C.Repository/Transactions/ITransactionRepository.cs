using Assignment2P2C.Domain.Transactions;

namespace Assignment2P2C.Repository.Transactions
{
    public interface ITransactionRepository : IRepository<ITransaction>
    {
        ITransaction GetByTransactionId(string id);
    }
}
