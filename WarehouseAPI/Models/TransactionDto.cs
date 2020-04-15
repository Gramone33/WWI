using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public class TransactionDto
    {
        public enum Types
        {
            StockIssue = 10,
            StockReceipt,
            StockAdjust
        }
        /// <summary>
        /// Transaction identifier
        /// </summary>
        public int? StockItemTransactionID { get; set; }
        /// <summary>
        /// Stock item identifier
        /// </summary>
        [Required]
        public int StockItemID { get; set; }
        /// <summary>
        /// Transaction ID, can be 10: stock issue, 11: stock receipt or 12 for stock adjustment
        /// </summary>
        [Required]
        public int TransactionTypeID { get; set; }
        /// <summary>
        /// Optional customer id linked to this stock transactions
        /// </summary>
        public int? CustomerID { get; set; }
        /// <summary>
        /// Optional invoice id linked to this stock transactions
        /// </summary>
        public int? InvoiceID { get; set; }
        /// <summary>
        /// Optional supplier id linked to this stock transactions
        /// </summary>
        public int? SupplierID { get; set; }
        /// <summary>
        /// Optional purchase id linked to this stock transactions
        /// </summary>
        public int? PurchaseOrderID { get; set; }
        /// <summary>
        /// Time when the transaction actually occured
        /// </summary>
        public DateTime TransactionOccurredWhen { get; set; }
        /// <summary>
        /// Quantity being added or removed from the warehouse
        /// </summary>
        [Required]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Id of the person editing this transaction
        /// </summary>
        public int LastEditedBy { get; set; }
        /// <summary>
        /// Last edition date time of this transaction
        /// </summary>
        public DateTime LastEditedWhen { get; set; }       
    }
}
