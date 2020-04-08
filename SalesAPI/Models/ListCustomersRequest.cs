using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    // https://cloud.google.com/apis/design/design_patterns#list_pagination
    public class ListCustomersRequest
    {
        public const int MaxPageSize = 50;
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Name of the customer to search. null for all customers
        /// </summary>
        public string Name { get; set; } = null;
        public int PageSize { get; set; } = DefaultPageSize;
        public int PageToken { get; set; } = 0;

    }
}
