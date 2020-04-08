using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<CustomerDto> ListCustomers(int pageNum, int pageSize);
        IEnumerable<CustomerDto> SearchCustomers(string keyword, int pageNum, int pageSize);
        CustomerDetailDto GetCustomer(int customerId);
    }
}
