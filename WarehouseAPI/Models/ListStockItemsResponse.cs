using System.Collections.Generic;

namespace WarehouseAPI.Models
{
    public class ListStockItemsResponse
    {
        /// <summary>
        /// List of stock items found
        /// </summary>
        public IEnumerable<StockItemDto> StockItems { get; set; }
        /// <summary>
        /// Next page of result, null if none
        /// </summary>
        public string NextPage { get; set; }
    }
}
