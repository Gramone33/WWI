using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> ListCustomers();
        IEnumerable<Customer> SearchCustomers(string keyword);
        Customer GetCustomer(int customerId);
    }
}
