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

        /// <summary>
        /// Register a transaction on a stock item in the warehouse. Can be either an issue, a receipt or a adjustment
        /// </summary>
        /// <param name="stockItemID">ID of the stock item being added or removed from the stock</param>
        /// <param name="newTransaction">Transaction about to be created</param>
        /// <returns>The transaction created with its identifier correctly affected by the API</returns>
        /// <response code="201">Transaction succesfully stored</response>
        /// <response code="400">Bad request, can be TransactionTypeID</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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