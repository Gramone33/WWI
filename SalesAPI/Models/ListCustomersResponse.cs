using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public class ListCustomersResponse
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
        public string NextPage { get; set; }
    }
}
