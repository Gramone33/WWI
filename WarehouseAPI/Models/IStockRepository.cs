using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public interface IStockRepository : IDisposable
    {
        IEnumerable<HoldingDto> ListHoldings(int stockItemID, int pageNum, int pageSize);
        IEnumerable<StockItemDto> ListStockItems(int supplierID, int pageNum, int pageSize);
    }
}
