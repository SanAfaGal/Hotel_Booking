using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_Booking.Context
{
    public class DapperContext

    {
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CONNECTION_SQL");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
