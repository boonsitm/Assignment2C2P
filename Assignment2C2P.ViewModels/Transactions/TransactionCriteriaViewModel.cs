using Assignment2C2P.Domain.Implementation.Transactions;
using Assignment2C2P.Domain.Transactions;

namespace Assignment2C2P.ViewModels.Transactions
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
