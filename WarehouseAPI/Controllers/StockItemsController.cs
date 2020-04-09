using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{supplierID}/[controller]")]
        public IEnumerable<StockItemDto> Get(int supplierID)
        {
            return null;
        }
    }
}
