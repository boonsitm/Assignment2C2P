using System;

namespace Assignment2P2C.Domain.Transactions
{
    public interface ITransaction : IEntity
    {
        int TransactionId { get; set; }
        double Amount { get; set; }
        string CurrencyCode { get; set; }
        char Status { get; set; }
        DateTime Date { get; set; }
    }
}
