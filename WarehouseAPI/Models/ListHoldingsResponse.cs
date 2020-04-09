using System.Collections.Generic;

namespace WarehouseAPI.Models
{
    public class ListHoldingsResponse
    {
        /// <summary>
        /// List of stock item holdings found
        /// </summary>
        public IEnumerable<HoldingDto> Holdings { get; set; }
        /// <summary>
        /// Next page of result, null if none
        /// </summary>
        public string NextPage { get; set; }
    }
}
