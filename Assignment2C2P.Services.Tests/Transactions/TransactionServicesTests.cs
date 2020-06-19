using Assignment2C2P.BusinessLogic.Transactions;
using Assignment2C2P.Domain.Implementation.Transactions;
using Assignment2C2P.Domain.Transactions;
using Assignment2C2P.Services.Implementation.Transactions;
using Assignment2C2P.Services.Transactions;
using Moq;
using NUnit.Framework;

namespace Assignment2C2P.Services.Tests
{
    public class TransactionServicesTests
    {
        private ITransactionServices _transactionServices;
        private Mock<ITransactionBusinessLogic> _transactionBusinessLogic;

        [SetUp]
        public void Setup()
        {
            _transactionBusinessLogic = new Mock<ITransactionBusinessLogic>();
            _transactionBusinessLogic.Setup(x => x.GetAll()).Verifiable();
            _transactionBusinessLogic.Setup(x => x.GetByCriteria(It.IsAny<ITransactionCriteria>())).Verifiable();
            _transactionBusinessLogic.Setup(x => x.Add(It.IsAny<ITransaction>())).Verifiable();
            
            _transactionServices = new TransactionServices(_transactionBusinessLogic.Object);
        }

        [Test]
        public void TransactionServices_CanGetAllTransactions()
        {
            // action
            _transactionServices.GetAllTransactions();

            // assert
            _transactionBusinessLogic.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void TransactionServices_CanGetTransactionsByCriteria()
        {
            // action
            _transactionServices.GetTransactionsByCriteria(new TransactionCriteria());

            // assert
            _transactionBusinessLogic.Verify(x => x.GetByCriteria(It.IsAny<ITransactionCriteria>()), Times.Once);
        }

        [Test]
        public void TransactionServices_CanInsertTransaction()
        {
            // action
            _transactionServices.InsertTransaction(new Transaction());

            // assert
            _transactionBusinessLogic.Verify(x => x.Add(It.IsAny<ITransaction>()), Times.Once);
        }
    }
}
