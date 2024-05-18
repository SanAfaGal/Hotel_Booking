using Hotel_Booking.Shared;
    
namespace Repository
{
    public interface ICustomerRepository
    {
        Task<bool> InsertCustomer(Customer customer);
        Task<Customer> GetCustomerByDni(string dniCustomer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<bool> UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer);
        Task<bool> DeleteCustomerByDni(string dniCustomer);
    }
}
