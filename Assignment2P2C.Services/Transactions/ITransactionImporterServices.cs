using System.IO;

namespace Assignment2P2C.Services.Transactions
{
    public interface ITransactionImporterServices
    {
        int ImportTransactions(Stream stream, string fileExtension);
    }
}
