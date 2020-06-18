using System.Collections.Generic;
using System.Linq;
using Assignment2P2C.Domain.Transactions;
using Assignment2P2C.Services.Transactions;
using Assignment2P2C.ViewModels.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2P2C.Web.Controllers
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
        public IActionResult Get()
        {
            IList<ITransaction> result = _transactionServices.GetAllTransactions();
            return Ok(result.Select(x => new TransactionViewModel(x)));
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/transactions
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
