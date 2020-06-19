using Assignment2C2P.Domain.Transactions;

namespace Assignment2C2P.Domain.Implementation.Transactions
{
    public class TransactionCriteria : ITransactionCriteria
    {
        public string CurrencyCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
