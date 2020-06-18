using Assignment2P2C.Domain.Implementation.Transactions;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Services.Transactions;
using Assignment2P2C.Utils.Converter;
using Assignment2P2C.Utils.ConverterData.Xml;
using Assignment2P2C.Utils.ConverterData.Csv;
using Assignment2P2C.Utils.DateTimeUtils;
using Assignment2P2C.Utils.StatusUtils;
using Assignment2P2C.ViewModels.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment2P2C.Utils.CurrencyUtils;
using Assignment2P2C.Utils.Logger;

namespace Assignment2P2C.Services.Implementation.Transactions
{
    public class TransactionImporterServices : ITransactionImporterServices
    {
        private readonly ILogger _logger;
        private readonly ITransactionServices _transactionServices;
        private readonly IList<string> _allCurrencyCodes;
        public TransactionImporterServices(ITransactionServices transactionServices, ILogger logger)
        {
            _transactionServices = transactionServices;
            _logger = logger;
            _allCurrencyCodes = CurrencyUtils.GetAllCurrencyCodes();
        }

        public int ImportTransactions(Stream stream, string fileExtension)
        {
            IList<TransactionMappingData> transactions = GetTransactionFromFileImport(stream, fileExtension);
            IList<string> messages = new List<string>();
            var counter = 0;

            foreach (var transaction in transactions)
            {
                try
                {
                    ITransaction newTransaction = new Transaction
                    {
                        TransactionId = transaction.TransactionId,
                        Amount = double.Parse(transaction.Amount),
                        Date = DateTimeUtils.ParseDate(transaction.TransactionDate, fileExtension),
                        Status = StatusUtils.GetStatusId(transaction.Status.ToLowerInvariant(), fileExtension),
                        CurrencyCode = CurrencyUtils.GetValidCurrencyCode(_allCurrencyCodes, transaction.CurrencyCode)
                    };

                    _transactionServices.InsertTransaction(newTransaction);

                    counter++;
                }
                catch (Exception ex)
                {
                    var errMessage = string.Format("Error import transaction id: {0}, {1}", transaction.TransactionId, ex.Message);
                    _logger.Error(errMessage);
                    messages.Add(errMessage);
                }
            }

            if (messages.Any())
                throw new Exception(string.Join("\r\n", messages.ToArray()));

            return counter;
        }

        internal IList<TransactionMappingData> GetTransactionFromFileImport(Stream stream, string fileExtension)
        {
            BaseConverter converter;

            switch (fileExtension)
            {
                case "csv":
                    {
                        converter = new CsvConverter();
                        return converter.ConverterTransactions(stream);
                    }
                case "xml":
                    {
                        converter = new XmlConverter();
                        return converter.ConverterTransactions(stream);
                    }
                default:
                    return null;
            }
        }
    }
}
