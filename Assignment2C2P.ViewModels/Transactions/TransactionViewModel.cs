using Assignment2C2P.Domain.Transactions;

namespace Assignment2C2P.ViewModels.Transactions
{
    public class TransactionViewModel
    {
        public TransactionViewModel(ITransaction transaction)
        {
            id = transaction.TransactionId;
            payment = $"{transaction.Amount:F2} {transaction.CurrencyCode}";
            status = transaction.Status;
        }

        public string id { get; set; }

        public string payment { get; set; }

        public string status { get; set; }
    }
}
