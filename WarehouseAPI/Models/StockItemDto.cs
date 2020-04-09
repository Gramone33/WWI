using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Models
{
    public class StockItemDto
    {
        /// <summary>
        /// Priary Key of the stock item
        /// </summary>
        public int? StockItemID { get; set; }
        /// <summary>
        /// Stock item name
        /// </summary>
        [Required]
        public string StockItemName { get; set; }
        /// <summary>
        /// ID of the supplier for this Stock Item
        /// </summary>
        [Required]
        public int SupplierID { get; set; }
        /// <summary>
        /// ID of the color for the stock item
        /// </summary>
        public int? ColorID { get; set; }
        /// <summary>
        /// Color name of the stock item
        /// </summary>
        public string ColorName { get; set; }
        /// <summary>
        /// Brand of the stock item
        /// </summary>
        [Required]
        public string Brand { get; set; }
        /// <summary>
        /// Bar code of the stock item. null if undefined
        /// </summary>
        public string Barcode { get; set; }
    }
}