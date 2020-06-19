using Assignment2C2P.Services.Transactions;
using Assignment2C2P.Utils.FileUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment2C2P.Web.Controllers
{
    public class TransactionImporterController : Controller
    {
        private readonly ITransactionImporterServices _transactionImporterServices;

        public TransactionImporterController(ITransactionImporterServices transactionServices)
        {
            _transactionImporterServices = transactionServices;
        }

        [HttpPost("ImportTransactions")]
        public IActionResult Index(IFormFile file)
        {
            if (file == null)
                return BadRequest("Please attach transaction file.");

            var fileExtension = FileUtils.GetFileExtension(file.FileName);

            if (!FileUtils.IsValidFileExtension(fileExtension))
                return BadRequest("Unknown format.");

            if (!FileUtils.IsValidFileSize(file.Length))
                return BadRequest("File size is max 1 MB.");

            try
            {
                int result = _transactionImporterServices.ImportTransactions(file.OpenReadStream(), fileExtension);
                return Ok(string.Format("Import transaction success {0} records.", result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
