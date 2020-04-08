using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<CustomerDto> ListCustomers();
        IEnumerable<CustomerDto> SearchCustomers(string keyword);
        CustomerDetailDto GetCustomer(int customerId);
    }
}
