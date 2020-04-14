using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Models;

namespace WarehouseAPI.Controllers
{
    [Route("stockitems")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private ITransactionsRepository _repo;

        public TransactionsController(ITransactionsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("{stockItemID}/[controller]")]
        public ActionResult<TransactionDto> CreateTransaction(int stockItemID, [FromBody] TransactionDto newTransaction)
        {
            try
            {
                newTransaction.StockItemID = stockItemID;
                newTransaction.LastEditedBy = 1; // TODO : Get current user ID
                newTransaction.LastEditedWhen = DateTime.Now;
                newTransaction.SupplierID = null;
                newTransaction.CustomerID = null;
                newTransaction.InvoiceID = null;
                newTransaction.PurchaseOrderID = null;
                var createTransaction = _repo.CreateTransaction(newTransaction);

                return Created(
                    $"/stockitems/{stockItemID}/[controller]/{createTransaction.StockItemTransactionID}",
                    createTransaction
                );
            }
            catch(ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
            catch(SqlException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}