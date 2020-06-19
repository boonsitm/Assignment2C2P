using Assignment2C2P.Utils.Converter;
using Assignment2C2P.ViewModels.Transactions;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Assignment2C2P.Utils.ConverterData.Csv
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
