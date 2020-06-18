using Assignment2P2C.Utils.Converter;
using Assignment2P2C.ViewModels.Transactions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Assignment2P2C.Utils.ConverterData.Xml
{
    public class XmlConverter : BaseConverter
    {
        public override IList<TransactionMappingData> ConverterTransactions(Stream stream)
        {
            XmlReader reader = XmlReader.Create(stream);
            XElement xElement = XElement.Load(reader);

            var transactionElements = xElement.Elements().
                Select(s => new TransactionMappingData
                {
                    TransactionId = s.Attribute("id").Value,
                    Amount = s.Element("PaymentDetails").Element("Amount").Value,
                    CurrencyCode = s.Element("PaymentDetails").Element("CurrencyCode").Value,
                    TransactionDate = s.Element("TransactionDate").Value,
                    Status = s.Element("Status").Value
                }).ToList();

            return transactionElements;
        }
    }
}
