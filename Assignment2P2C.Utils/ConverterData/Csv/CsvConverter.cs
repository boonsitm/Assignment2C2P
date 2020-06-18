using Assignment2P2C.Utils.Converter;
using Assignment2P2C.ViewModels.Transactions;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Assignment2P2C.Utils.ConverterData.Csv
{
    public class CsvConverter : BaseConverter
    {
        public override IList<TransactionMappingData> ConverterTransactions(Stream stream)
        {
            TextReader textReader = new StreamReader(stream);

            using var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);
            csv.Configuration.HasHeaderRecord = false;
            var records = csv.GetRecords<TransactionMappingData>().ToList();
            return records;
        }
    }
}
