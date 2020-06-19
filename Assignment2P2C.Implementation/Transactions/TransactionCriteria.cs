using Assignment2P2C.Domain.Transactions;

namespace Assignment2P2C.Domain.Implementation.Transactions
{
    public class TransactionCriteria : ITransactionCriteria
    {
        public string CurrencyCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
