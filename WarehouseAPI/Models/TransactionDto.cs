using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public class TransactionDto
    {
        public int? StockItemTransactionID { get; set; }
        public int StockItemID { get; set; }
        public int TransactionTypeID { get; set; }
        public int? CustomerID { get; set; }
        public int? InvoiceID { get; set; }
        public int? SupplierID { get; set; }
        public int? PurchaseOrderID { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }       
    }
}
