using Hotel_Booking.Shared;

namespace Hotel_Booking.Services
{
    public interface ICustomerService
    {
        Task InsertCustomer(Customer customer);
        Task GetCustomerByDni(string dniCustomer);
        Task GetAllCustomers();
        Task UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer);
        Task DeleteCustomerByDni(string dniCustomer);
    }
}
