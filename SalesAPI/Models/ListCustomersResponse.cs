using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public class ListCustomersResponse
    {
        /// <summary>
        /// List of customers
        /// </summary>
        public IEnumerable<CustomerDto> Customers { get; set; }
        /// <summary>
        /// Link to next customer result page
        /// </summary>
        public string NextPage { get; set; }
    }
}
