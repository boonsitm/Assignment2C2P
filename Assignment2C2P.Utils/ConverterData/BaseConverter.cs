using Assignment2C2P.ViewModels.Transactions;
using System.Collections.Generic;
using System.IO;

namespace Assignment2C2P.Utils.Converter
{
    public abstract class BaseConverter
    {
        public abstract IList<TransactionMappingData> ConverterTransactions(Stream stream);
    }
}
