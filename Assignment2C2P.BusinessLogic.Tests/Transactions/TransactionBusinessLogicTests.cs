using Assignment2C2P.BusinessLogic.Implementation.Transactions;
using Assignment2C2P.BusinessLogic.Transactions;
using Assignment2C2P.Domain.Implementation.Transactions;
using Assignment2C2P.Domain.Transactions;
using Assignment2C2P.Repository.Transactions;
using Assignment2C2P.Utils.Logger;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assignment2C2P.BusinessLogic.Tests
{
    public class TransactionBusinessLogicTests
    {
        private ITransactionBusinessLogic _transactionBusinessLogic;
        private Mock<ILogger> _logger;
        private Mock<ITransactionRepository> _transactionRepository;
        
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger>();
            _logger.Setup(x => x.Error(It.IsAny<string>())).Verifiable();

            _transactionRepository = new Mock<ITransactionRepository>();
            _transactionRepository.Setup(x => x.Add(It.IsAny<ITransaction>())).Verifiable();
            _transactionRepository.Setup(x => x.GetAll())
                .Returns(
                    new List<ITransaction>()
                    {
                        new Transaction{
                            TransactionId = "TransactionId_01",
                            Amount = 100,
                            CurrencyCode = "THB",
                            Date = new DateTime(2020, 12, 22),
                            Status = "A"
                        },
                        new Transaction{
                            TransactionId = "TransactionId_02",
                            Amount = 150,
                            CurrencyCode = "USD",
                            Date = new DateTime(2020, 12, 25),
                            Status = "D"
                        }
                    }
            );

            _transactionBusinessLogic = new TransactionBusinessLogic(
                _logger.Object,
                _transactionRepository.Object);
        }

        [Test]
        public void TransactionBusinessLogic_CanGetAll()
        {
            // action
            var result = _transactionBusinessLogic.GetAll();

            // assert
            _transactionRepository.Verify(x => x.GetAll(), Times.Once);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("TransactionId_01", result[0].TransactionId);
            Assert.AreEqual(100, result[0].Amount);
            Assert.AreEqual("THB", result[0].CurrencyCode);
            Assert.AreEqual(new DateTime(2020, 12, 22), result[0].Date);
            Assert.AreEqual("A", result[0].Status);

            Assert.AreEqual("TransactionId_02", result[1].TransactionId);
            Assert.AreEqual(150, result[1].Amount);
            Assert.AreEqual("USD", result[1].CurrencyCode);
            Assert.AreEqual(new DateTime(2020, 12, 25), result[1].Date);
            Assert.AreEqual("D", result[1].Status);
        }

        [Test]
        public void TransactionBusinessLogic_CanAdd()
        {
            // action
            _transactionBusinessLogic.Add(new Transaction());
            
            // assert
            _transactionRepository.Verify(x => x.Add(It.IsAny<ITransaction>()), Times.Once);
        }

        [Test]
        public void TransactionBusinessLogic_CanGetByCriteria()
        {
            // mock
            var criteria = new TransactionCriteria
            {
                CurrencyCode = "USD",
                Status = "D",
                StartDate = "22/12/2020",
                EndDate = "30/12/2020"
            };
            // action
            var result = _transactionBusinessLogic.GetByCriteria(criteria);

            // assert
            _transactionRepository.Verify(x => x.GetAll(), Times.Once);
            _logger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TransactionId_02", result[0].TransactionId);
            Assert.AreEqual(150, result[0].Amount);
            Assert.AreEqual("USD", result[0].CurrencyCode);
            Assert.AreEqual(new DateTime(2020, 12, 25), result[0].Date);
            Assert.AreEqual("D", result[0].Status);
        }

        [TestCase("ABC", "D", "22/12/2020", "22/12/2020")]
        [TestCase("THB", "D", "22/12/20", "22/12/2020")]
        [TestCase("THB", "D", "22/12/2020", "22/12/20")]
        public void TransactionBusinessLogic_GetByCriteria_With_Invalid_Criteria(
            string currencyCode,
            string status,
            string startDate,
            string endDate)
        {
            // mock
            var criteria = new TransactionCriteria
            {
                CurrencyCode = currencyCode,
                Status = status,
                StartDate = startDate,
                EndDate = endDate
            };
            // action
            var result = _transactionBusinessLogic.GetByCriteria(criteria);

            // assert
            _transactionRepository.Verify(x => x.GetAll(), Times.Once);
            _logger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
