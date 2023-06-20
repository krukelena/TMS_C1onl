using NLog;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services.DateBases
{
    public class CustomerService
    {
      private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
      private readonly NpgsqlConnection _connection;

    public CustomerService(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void CreateTable()
        {
            var sqlQuery = "CREATE TABLE customers (" +
                                "id SERIAL PRIMARY KEY, " +
                                "firstname CHARACTER VARYING(30), " +
                                "lastname CHARACTER VARYING(30), " +
                                "email CHARACTER VARYING(30), " +
                                "age INTEGER" +
                                ");";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);
            cmd.ExecuteNonQuery();

        }
        public void DropTable() 
        {
            var sqlQuery = "drop table if exists customer;";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);
            cmd.ExecuteNonQuery();

        }
        public List<Customer> GetAllCustomers()
        {
            var sqlQuery = "";
            return null;
        }

        public void AddCustomer(Customer customer)
        {

        }

        public void DeleteCustomer (Customer customer)
        {

        }
    }
}
