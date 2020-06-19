using Assignment2P2C.BusinessLogic.Transactions;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Repository.Transactions;
using Assignment2P2C.Utils.CurrencyUtils;
using Assignment2P2C.Utils.DateTimeUtils;
using Assignment2P2C.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2P2C.BusinessLogic.Implementation.Transactions
{
    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        private readonly ILogger _logger;
        private readonly ITransactionRepository _repository;
        public TransactionBusinessLogic(ILogger logger, ITransactionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void Delete(long internalId)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Get(long internalId)
        {
            throw new System.NotImplementedException();
        }

        public IList<ITransaction> GetAll()
        {
            return _repository.GetAll();
        }

        public ITransaction Add(ITransaction item)
        {
            return _repository.Add(item);
        }

        public ITransaction Update(ITransaction item)
        {
            throw new System.NotImplementedException();
        }

        public IList<ITransaction> GetByCriteria(ITransactionCriteria criteria)
        {
            var results = GetAll();

            // by Currency
            if (!string.IsNullOrEmpty(criteria.CurrencyCode))
            {
                try
                {
                    var allCurrencyCodes = CurrencyUtils.GetAllCurrencyCodes();
                    var currencyCode = CurrencyUtils.GetValidCurrencyCode(allCurrencyCodes, criteria.CurrencyCode);

                    results = results.Where(x => x.CurrencyCode == currencyCode).ToList();
                }
                catch (Exception ex)
                {
                    _logger.Equals(string.Format("Invalid currency criteria: ", ex.Message));
                    return new List<ITransaction>();
                }
                
            }

            // by Date range format dd/MM/yyyy
            if (!string.IsNullOrEmpty(criteria.StartDate))
            { 
                try
                {
                    var startDate = DateTimeUtils.ParseDate(criteria.StartDate);
                    results = results.Where(x => x.Date >= startDate).ToList();
                }
                catch (Exception ex)
                {
                    _logger.Equals(string.Format("Invalid start date criteria: ", ex.Message));
                    return new List<ITransaction>();
                }
            }

            if (!string.IsNullOrEmpty(criteria.EndDate))
            {
                try
                {
                    var endDate = DateTimeUtils.ParseDate(criteria.EndDate);
                    results = results.Where(x => x.Date <= endDate).ToList();
                }
                catch (Exception ex)
                {
                    _logger.Equals(string.Format("Invalid end date criteria: ", ex.Message));
                    return new List<ITransaction>();
                }
            }

            // by Status
            if (!string.IsNullOrEmpty(criteria.Status))
            {
                results = results.Where(x => x.Status == criteria.Status).ToList();
            }

            return results;
        }
    }
}
