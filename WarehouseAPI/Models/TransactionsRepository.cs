using Dapper;
using System.Data.SqlClient;

namespace WarehouseAPI.Models
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private SqlConnection _db;
        private const string InsertTransaction = @"
            INSERT INTO Warehouse.StockItemTransactions
                (StockItemID, TransactionTypeID, CustomerID, InvoiceID, SupplierID, PurchaseOrderID, TransactionOccurredWhen, Quantity, LastEditedBy, LastEditedWhen) 
                VALUES (@StockItemID, @TransactionTypeID, @CustomerID, @InvoiceID, @SupplierID, @PurchaseOrderID, @TransactionOccurredWhen, @Quantity, @LastEditedBy, @LastEditedWhen);
                SELECT CAST(SCOPE_IDENTITY() as int)
            ";

        public TransactionsRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }
        public TransactionDto CreateTransaction(TransactionDto newTransaction)
        {
            var id = _db.QuerySingle<int>(InsertTransaction, newTransaction);
            newTransaction.StockItemTransactionID = id;
            return newTransaction;
        }
            

        public void Dispose() => _db.Dispose();
    }
}
