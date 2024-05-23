using Hotel_Booking.Shared;
using Repository;

namespace Hotel_Booking.Services
{
    public class ImplCustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public ImplCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> InsertCustomer(Customer customer)
        {
            return await _customerRepository.InsertCustomer(customer);
        }

        public async Task<Customer> GetCustomerByDni(string dniCustomer)
        {
            return await _customerRepository.GetCustomerByDni(dniCustomer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<bool> UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer)
        {
            return await _customerRepository.UpdateCustomerByDni(dniCustomer, updatedCustomer);
        }

        public async Task<bool> DeleteCustomerByDni(string dniCustomer)
        {
            return await _customerRepository.DeleteCustomerByDni(dniCustomer);
        }
    }
}
