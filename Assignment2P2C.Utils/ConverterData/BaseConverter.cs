using Assignment2P2C.ViewModels.Transactions;
using System.Collections.Generic;
using System.IO;

namespace Assignment2P2C.Utils.Converter
{
    public abstract class BaseConverter
    {
        public abstract IList<TransactionMappingData> ConverterTransactions(Stream stream);
    }
}
