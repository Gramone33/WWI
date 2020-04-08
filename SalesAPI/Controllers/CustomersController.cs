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
        public ActionResult<ListCustomersResponse> ListCustomers([FromQuery] ListCustomersRequest request)
        {
            if (request == null)
            {
                request = new ListCustomersRequest();
            }
            if(request.PageSize < 1 || ListCustomersRequest.MaxPageSize < request.PageSize)
            {
                return BadRequest("Bad PageSize");
            }
            if (request.PageToken < 0)
            {
                return BadRequest("Bad PageToken");
            }
            var result = new ListCustomersResponse();
            
            if(request.Name !=null)
            {
                result.Customers = _repo.SearchCustomers(request.Name);
            }
            else
            {
                result.Customers = _repo.ListCustomers();
            }
            var count = result.Customers.Count();
            var pagenum = (count + request.PageSize - 1) / request.PageSize;

            if(request.PageToken>=pagenum)
            {
                return BadRequest("PageToken exceeds page number");
            }
            result.Customers = result.Customers.Skip(request.PageToken * request.PageSize).Take(request.PageSize);
            if(request.PageToken == pagenum)
            {
                result.NextPage = null;
            }
            else
            {
                result.NextPage = $"/customers?Name={request.Name}&PageSize={request.PageSize}&PageToken={request.PageToken + 1}";
            }
            return result;

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
