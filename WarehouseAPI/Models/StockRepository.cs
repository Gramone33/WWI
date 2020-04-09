using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WarehouseAPI.Models
{
    public class StockRepository : IStockRepository
    {
        private SqlConnection _db;
        private const string SelectStockItems = @"
            SELECT StockItemID, StockItemName, SupplierID, 
                Warehouse.Colors.ColorID, Warehouse.Colors.ColorName AS ColorName,
                Brand, Barcode 
            FROM 
                Warehouse.StockItems LEFT JOIN Warehouse.Colors ON Warehouse.StockItems.ColorID = Warehouse.Colors.ColorID";

        private const string SelectHoldings = @"
            SELECT StockItemID, QuantityOnHand, BinLocation, LastStocktakeQuantity,
                LastCostPrice, ReorderLevel, TargetStockLevel, LastEditedBy, LastEditedWhen
            FROM Warehouse.StockItemHoldings";

        private const string Paging = "OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";

        public StockRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }
        public void Dispose() => _db.Dispose();

        public IEnumerable<HoldingDto> ListHoldings(int stockItemID, int pageNum, int pageSize) =>
            _db.Query<HoldingDto>($"{SelectHoldings} WHERE StockItemID = @StockItemID ORDER BY LastEditedWhen DESC {Paging}",
                new { PageNum = pageNum, PageSize = pageSize, StockItemID = stockItemID }
            );

        public IEnumerable<StockItemDto> ListStockItems(int supplierID, int pageNum, int pageSize) =>
            _db.Query<StockItemDto>($"{SelectStockItems} WHERE SupplierID = @SupplierID ORDER BY StockItemID {Paging}",
                new { PageNum = pageNum, PageSize = pageSize, SupplierID = supplierID }
            );
    }
}
