using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarehouseAPI.Models;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("suppliers")]
    public class StockItemsController : ControllerBase
    {
        private readonly ILogger<StockItemsController> _logger;
        private readonly IStockRepository _repo;

        public StockItemsController(ILogger<StockItemsController> logger, IStockRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// List of the stock items for a given supplier
        /// </summary>
        /// <param name="supplierID">Identifier of the supplier whose stock items are to be retreived</param>
        /// <param name="request">Paging parameters for the request</param>
        /// <returns>Stock items response</returns>
        /// <response code="200">Successfully retreived</response>
        /// <response code="400">Bad pagin parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{supplierID}/[controller]")]
        public ActionResult<ListStockItemsResponse> ListStockItems(int supplierID, [FromQuery] ListStockRequest request)
        {
            if(request.IsValid())
            {
                var response = new ListStockItemsResponse();

                response.StockItems = _repo.ListStockItems(supplierID, request.PageToken, request.PageSize);
                response.NextPage = response.StockItems.Count() == request.PageSize
                    ? $"{Request.Scheme}://{Request.Host}{Request.Path}?pageToken={request.PageToken+1}&pageSize={request.PageSize}"
                    : null;
                return response;
            }
            else
            {
                return BadRequest("Invalid paging parameters");
            }
        }
        /// <summary>
        /// List of the holdings for a given stock items for a given supplier
        /// </summary>
        /// <param name="stockItemID">Stock item whose holdings is to be retreived</param>
        /// <param name="request">Paging parameters for the request</param>
        /// <returns>Stock item holdings response</returns>
        /// <response code="200">Succesfully retreived</response>
        /// <response code="400">Bad pagin parameters</response>
        [HttpGet("/[controller]/{stockItemID}/holdings")]
        public ActionResult<ListHoldingsResponse> ListHoldings(int stockItemID, [FromQuery] ListStockRequest request)
        {
            if (request.IsValid())
            {
                var response = new ListHoldingsResponse();

                response.Holdings = _repo.ListHoldings(stockItemID, request.PageToken, request.PageSize);
                response.NextPage = response.Holdings.Count() == request.PageSize
                    ? $"{Request.Scheme}://{Request.Host}{Request.Path}?pageToken={request.PageToken + 1}&pageSize={request.PageSize}"
                    : null;
                return response;
            }
            else
            {
                return BadRequest("Invalid paging parameters");
            }
        }
    }
}
