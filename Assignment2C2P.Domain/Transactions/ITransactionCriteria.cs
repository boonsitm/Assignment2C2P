namespace Assignment2C2P.Domain.Transactions
{
    public interface ITransactionCriteria
    {
        string CurrencyCode { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string Status { get; set; }
        
    }
}
