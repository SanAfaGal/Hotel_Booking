using Hotel_Booking.Shared;

namespace Hotel_Booking.Services
{
    public interface ICustomerService
    {
        Task<bool> InsertCustomer(Customer customer);
        Task<Customer> GetCustomerByDni(string dniCustomer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<bool> UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer);
        Task<bool> DeleteCustomerByDni(string dniCustomer);
    }
}
