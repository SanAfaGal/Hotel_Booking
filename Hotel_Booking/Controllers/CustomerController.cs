using Hotel_Booking.Services;
using Hotel_Booking.Shared;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Hotel_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Create: POST api/customer
        [HttpPost()]
        public async Task<IActionResult> InsertCustomer([FromBody] Customer customer)
        {
            if (customer == null) return BadRequest();
            bool result = await _customerService.InsertCustomer(customer);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // Read: GET api/customer/{dni}
        [HttpGet("{dni}")]
        public async Task<IActionResult> GetCustomerByDni(string dni)
        {
            if (string.IsNullOrEmpty(dni)) return BadRequest();
            Customer customer = await _customerService.GetCustomerByDni(dni);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        // Read All: GET api/customer
        [HttpGet()]
        public async Task<IActionResult> GetAllCustomers()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // Update: PUT api/customer/{dni}
        [HttpPut("{dni}")]
        public async Task<IActionResult> UpdateCustomer(string dni, [FromBody] Customer updatedCustomer)
        {
            if (string.IsNullOrEmpty(dni) || updatedCustomer == null) return BadRequest();
            bool result = await _customerService.UpdateCustomerByDni(dni, updatedCustomer);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Delete: DELETE api/customer/{dni}
        [HttpDelete("{dni}")]
        public async Task<IActionResult> DeleteCustomer(string dni)
        {
            if (string.IsNullOrEmpty(dni)) return BadRequest();
            bool result = await _customerService.DeleteCustomerByDni(dni);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
