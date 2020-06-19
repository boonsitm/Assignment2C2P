using Assignment2P2C.Domain.Implementation.Transactions;
using Assignment2P2C.Domain.Transactions;

namespace Assignment2P2C.ViewModels.Transactions
{
    public class TransactionCriteriaViewModel
    {
        public TransactionCriteriaViewModel(
            string currency,
            string startDate,
            string endDate,
            string status)
        {
            Currency = currency;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
        public string Currency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        
        public ITransactionCriteria Convert()
        {
            return new TransactionCriteria
            {
                CurrencyCode = Currency,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = Status

            };
        }
    }
}
