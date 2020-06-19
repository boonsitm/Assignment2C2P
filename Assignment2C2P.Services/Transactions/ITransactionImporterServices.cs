using System.IO;

namespace Assignment2C2P.Services.Transactions
{
    public interface ITransactionImporterServices
    {
        int ImportTransactions(Stream stream, string fileExtension);
    }
}
