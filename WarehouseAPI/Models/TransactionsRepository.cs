using Dapper;
using System;
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
                SELECT current_value FROM sys.sequences WHERE name = 'TransactionID' ;
            ";

        public TransactionsRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }
        public TransactionDto CreateTransaction(TransactionDto newTransaction)
        {
            if(newTransaction.TransactionTypeID<(int)TransactionDto.Types.StockIssue 
                || newTransaction.TransactionTypeID>(int)TransactionDto.Types.StockAdjust)
            {
                throw new ArgumentOutOfRangeException("Type must be 10: issue, 11: receipt or 12: adjust");
            }
            var id = _db.QuerySingle<int>(InsertTransaction, newTransaction);
            newTransaction.StockItemTransactionID = id;
            return newTransaction;
        }
            

        public void Dispose() => _db.Dispose();
    }
}
