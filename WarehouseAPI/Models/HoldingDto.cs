using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Models
{
    public class HoldingDto
    {
        /// <summary>
        /// Primary key for Stock Item
        /// </summary>
        public int? StockItemID { get; set; }
        /// <summary>
        /// Actual quantity of the item (SKU)
        /// </summary>
        [Required]
        public int QuantityOnHand { get; set; }
        /// <summary>
        /// Location of the item in the warehouse
        /// </summary>
        [Required]
        public string BinLocation { get; set; }
        /// <summary>
        /// Stock take quantity. Stock taking results in a summary-level document that contains a list of the quantities on hand for every inventory item as of a specific point in time.
        /// </summary>
        [Required]
        public int LastStocktakeQuantity { get; set; }
        /// <summary>
        /// Last cost price of the item
        /// </summary>
        [Required]
        public decimal LastCostPrice { get; set; }
        /// <summary>
        /// Level for reordering the item
        /// </summary>
        [Required]
        public int ReorderLevel { get; set; }
        /// <summary>
        /// Desired stock level for the item
        /// </summary>
        [Required]
        public int TargetStockLevel { get; set; }
        /// <summary>
        /// ID of the employee who last edited the stock item.
        /// </summary>
        [Required]
        public int LastEditedBy { get; set; }
        /// <summary>
        /// Last editing date time
        /// </summary>
        [Required]
        public DateTime LastEditedWhen { get; set; }
    }
}