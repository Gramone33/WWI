using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesAPI.Models;

namespace SalesAPI.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Customer> ListCustomers([FromQuery] string name)
        {
            if(name!=null)
            { 
                return _repo.SearchCustomers(name);
            }
            else
            {
                return _repo.ListCustomers();
            }
        }

        /// <summary>
        /// Retreive a customer from its identifier / primary key.
        /// </summary>
        /// <param name="customerId">Id of the customer to look for.</param>
        /// <returns>The customer found or 404 else.</returns>
        /// <response code="200">Customer found with given Id</response>
        /// <response code="404">No customer found with this identifier</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
