using Hotel_Booking.Shared;

namespace Hotel_Booking.Services
{
    public class ImplCustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public ImplCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        Task ICustomerService.DeleteCustomerByDni(string dniCustomer)
        {
            throw new NotImplementedException();
        }

        Task ICustomerService.GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        Task ICustomerService.GetCustomerByDni(string dniCustomer)
        {
            throw new NotImplementedException();
        }


        async Task ICustomerService.InsertCustomer(Customer customer)
        {
            var data = await _httpClient.PostAsJsonAsync<Customer>($"api/Customer/SaveCustomer", customer);
        }

        Task ICustomerService.UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
