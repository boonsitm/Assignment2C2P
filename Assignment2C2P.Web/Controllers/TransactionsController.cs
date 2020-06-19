using System.Collections.Generic;
using System.Linq;
using Assignment2C2P.Domain.Transactions;
using Assignment2C2P.Services.Transactions;
using Assignment2C2P.ViewModels.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2C2P.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;
        public TransactionsController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }
        // GET: api/transactions
        [HttpGet]
        public IActionResult Get(
            string currency ="",
            string startDate = "",
            string endDate = "",
            string status = "")
        {
            var criteria = new TransactionCriteriaViewModel(currency, startDate, endDate, status).Convert();

            IList<ITransaction> result = _transactionServices.GetTransactionsByCriteria(criteria);
            return Ok(result.Select(x => new TransactionViewModel(x)));
        }
    }
}
