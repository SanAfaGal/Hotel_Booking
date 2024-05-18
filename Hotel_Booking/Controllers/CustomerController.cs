using Hotel_Booking.Shared;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Hotel_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _ICustomerRepository;

        public CustomerController(ICustomerRepository CustomerParam)
        {
            _ICustomerRepository = CustomerParam;
        }

   
        [HttpPost("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            await _ICustomerRepository.InsertCustomer(customer);

            return Ok();
        }
    }
}
