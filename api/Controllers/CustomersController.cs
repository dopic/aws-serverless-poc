using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController: Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService) => _customerService = customerService;

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _customerService.GetAsync(id);
            if (customer is null) return NotFound();

            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            await _customerService.AddAsync(customer);
            return Created(new Uri($"api/customers/{customer.Id}", UriKind.Relative), customer);
        }
    }
}