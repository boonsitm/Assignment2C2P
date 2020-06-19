using System;

namespace Assignment2C2P.Domain.Transactions
{
    public interface ITransaction
    {
        string TransactionId { get; set; }
        double Amount { get; set; }
        string CurrencyCode { get; set; }
        string Status { get; set; }
        DateTime Date { get; set; }
    }
}
