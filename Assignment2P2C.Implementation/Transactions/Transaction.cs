using Assignment2P2C.Domain.Transactions;
using System;

namespace Assignment2P2C.Implementation.Transactions
{
    public class Transaction : Entity, ITransaction
    {
        public virtual int TransactionId { get; set; }
        public virtual double Amount { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual char Status { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
