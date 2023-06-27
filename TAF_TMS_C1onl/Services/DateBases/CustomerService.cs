using NLog;
using Npgsql;
using NUnit.Framework.Constraints;
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

        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }

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
            var sqlQuery = "SELECT * FROM customers;";
            var actualList = new List<Customer>();

            //получаем все строки

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);
            using var reader = cmd.ExecuteReader();

            //обрабатываем данные

            while (reader.Read())
            {
                var customer = new Customer();
                {
                    Id = reader.GetInt32(0);
                    Firstname = reader.GetString(reader.GetOrdinal("firstname"));
                    Lastname = reader.GetString(reader.GetOrdinal("lasttname"));
                    Email = reader.GetString(reader.GetOrdinal("email"));
                    Age = reader.GetInt32(reader.GetOrdinal("age"));
                };

                _logger.Info(customer.ToString);
                actualList.Add(customer);

            }


            return actualList;
        }

        public int AddCustomer(Customer customer)
        {
            var sqlQuery = "INSERT INTO customers(firstname, lastname, email, age) VALUES ($1,$2,$3,$4);";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection)
            {
                Parameters ={

                    new() { Value = customer.Firstname },
                    new() { Value = customer.Lastname },
                    new() { Value = customer.Email },
                    new() { Value = customer.Age }
                }
            };

          return cmd.ExecuteNonQuery();
        }

        public int DeleteCustomer (Customer customer)
        {
            var sqlQuery = "DELETE FROM customers WHERE <condition>;";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection)
            {
                Parameters ={

                    new() { Value = customer.Firstname },
                    new() { Value = customer.Lastname },
                    new() { Value = customer.Email },
                    new() { Value = customer.Age }
                }
            };

            return cmd.ExecuteNonQuery();

        }
    }
}
