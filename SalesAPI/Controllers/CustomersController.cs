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
        /// Get a paginated list of customers using optional search criteria.
        /// </summary>
        /// <param name="request">Request parameters</param>
        /// <returns>Paging information and list of customers</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<ListCustomersResponse> ListCustomers([FromQuery] ListCustomersRequest request)
        {
            if (request == null)
            {
                request = new ListCustomersRequest();
            }
            else
            {
                if (request.PageSize < 1 || ListCustomersRequest.MaxPageSize < request.PageSize)
                {
                    return BadRequest("Bad PageSize");
                }
                if (request.PageToken < 0)
                {
                    return BadRequest("Bad PageToken");
                }
            }
            var result = new ListCustomersResponse();
            
            result.Customers = request.Name == null
                ? _repo.ListCustomers(request.PageToken, request.PageSize)
                : _repo.SearchCustomers(request.Name, request.PageToken, request.PageSize);
            result.NextPage = result.Customers.Any()
                ? $"/customers?Name={request.Name}&PageSize={request.PageSize}&PageToken={request.PageToken + 1}"
                : null;
            return result;
        }

        /// <summary>
        /// Retreive a customer details using its identifier
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Detailed customer</returns>
        /// <response code="200">Customer with the given ID found</response>
        /// <response code="404">No customer with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
