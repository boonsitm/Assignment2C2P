namespace Assignment2P2C.Domain.Transactions
{
    public interface ITransactionCriteria
    {
        string CurrencyCode { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string Status { get; set; }
        
    }
}
