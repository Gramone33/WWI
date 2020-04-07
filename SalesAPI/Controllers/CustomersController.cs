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

        [HttpGet]
        public IEnumerable<Customer> ListCustomers()
        {
            if (Request.Query.ContainsKey("q"))
            {
                var keyword = Request.Query["q"];
                var result = _repo.SearchCustomers(keyword);

                return result;
            }
            else
            {
                return _repo.ListCustomers();
            }
        }
            

        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomer(int customerId)
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
