using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesAPI.Models;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {   
        private readonly ILogger<CustomersController> _logger;
        private ICustomerRepository _repo;

        public CustomersController(ILogger<CustomersController> logger, ICustomerRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        private const int DefaultPageSize = 10;
        [HttpGet]
        public ListCustomersResponse ListCustomers([FromQuery] ListCustomersRequest request)
        {
            var result = new ListCustomersResponse();

            if (request != null)
            {
                var keyword = request.Name;                
                var customers = _repo.SearchCustomers(keyword);

                // TODO : Pagination avec Linq
                result.Customers = customers;
                result.NextPage = $"/customers?Name={request.Name}&PageSize={request.PageSize}&PageToken=1";
                return result;
            }
            else
            {
                // TODO : Pagination avec Linq
                result.Customers = _repo.ListCustomers();
                result.NextPage = $"/customers?Name=null&PageSize={DefaultPageSize}&PageToken=1";
                return result;
            }
        }
            

        [HttpGet("{customerId}")]
        public ActionResult<CustomerDetailDto> GetCustomer(int customerId)
        {
            var result = _repo.GetCustomer(customerId);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return result;
            }
        }
    }
}
