using Microsoft.Data.SqlClient;
using Hotel_Booking.Shared;
using System.Data;
using Repository;
using Dapper;
using System.Data.Common;

namespace ImplRepository
{
    public class ImplCustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public ImplCustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Inserts a new customer record into the database.
        /// </summary>
        /// <param name="customer">The customer object to be inserted.</param>
        /// <returns>True if the insertion was successful, otherwise false.</returns>
        public async Task<bool> InsertCustomer(Customer customer)
        {
            try
            {
                string sql = @"INSERT INTO tbl_customers (dni_customer, first_name, last_name, email, phone) 
                   VALUES (@Dni_Customer, @First_Name, @Last_Name, @Email, @Phone)";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    customer.Dni_Customer,
                    customer.First_Name,
                    customer.Last_Name,
                    customer.Email,
                    customer.Phone
                });

                // Returning true if at least one record was affected
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while inserting customer: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Retrieves a customer from the database based on their DNI.
        /// </summary>
        /// <param name="DniCustomer">The DNI of the customer.</param>
        /// <returns>The customer object if found, otherwise null.</returns>
        public async Task<Customer> GetCustomerByDni(string dniCustomer)
        {
            try
            {
                string sql = @"SELECT dni_customer, first_name, last_name, email, phone FROM tbl_customers WHERE dni_customer = @DniCustomer";
                
                var customer = await _dbConnection.QueryFirstOrDefaultAsync<Customer>(sql, new { dniCustomer });
                
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving customer by DNI: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Retrieves all customers from the database.
        /// </summary>
        /// <returns>An IEnumerable of all customers. If an exception occurs, an empty IEnumerable will be returned.</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                string sql = @"SELECT dni_customer, first_name, last_name, email, phone FROM tbl_customers";

                var customers = await _dbConnection.QueryAsync<Customer>(sql);

                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving all customers: {ex.Message}");
                return new List<Customer>();
            }
        }

        /// <summary>
        /// Deletes a customer from the database based on their DNI.
        /// </summary>
        /// <param name="dniCustomer">The DNI of the customer to be deleted.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        public async Task<bool> DeleteCustomerByDni(string dniCustomer)
        {
            try
            {
                string sql = @"DELETE FROM tbl_customers WHERE dni_customer = @DniCustomer";

                var result = await _dbConnection.ExecuteAsync(sql, new { DniCustomer = dniCustomer });

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting customer by DNI: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Updates customer information in the database based on their DNI.
        /// </summary>
        /// <param name="dniCustomer">The DNI of the customer to be updated.</param>
        /// <param name="updatedCustomer">The updated customer object containing new information.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public async Task<bool> UpdateCustomerByDni(string dniCustomer, Customer updatedCustomer)
        {
            try
            {
                string sql = @"UPDATE tbl_customers 
                               SET first_name = @FirstName, last_name = @LastName, email = @Email, phone = @Phone
                               WHERE dni_customer = @DniCustomer";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    FirstName = updatedCustomer.First_Name,
                    LastName = updatedCustomer.Last_Name,
                    Email = updatedCustomer.Email,
                    Phone = updatedCustomer.Phone,
                    DniCustomer = dniCustomer
                });

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating customer by DNI: {ex.Message}");
                return false;
            }
        }
    }
}
