using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// Requested page size, ie number of items per page. From 1 to 50. Default is 10.
        /// </summary>
        [Range(1, MaxPageSize)]
        public int PageSize { get; set; } = DefaultPageSize;
        /// <summary>
        /// Desired page token. Default is 0
        /// </summary>
        public int PageToken { get; set; } = 0;

    }
}
