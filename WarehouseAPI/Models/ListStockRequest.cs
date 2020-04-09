using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public class ListStockRequest
    {
        public const int MaxPageSize = 50;
        public const int DefaultPageSize = 10;

        
        public bool IsValid() =>
            1 <= PageSize && PageSize <= MaxPageSize &&
            0 <= PageToken && PageToken < PageSize;

        /// <summary>
        /// Page id, zero starting index less than PageSize
        /// </summary>
        public int PageToken { get; set; } = 0;
        /// <summary>
        /// Required number of item per page. 1 to 50
        /// </summary>
        public int PageSize { get; set; } = DefaultPageSize;
    }
}
