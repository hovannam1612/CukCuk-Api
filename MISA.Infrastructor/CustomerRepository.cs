using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructor
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Declare
        IConfiguration _configuration;
        #endregion

        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion
        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            var dbConnection = new MySqlConnection(connectionString);
            var customer = dbConnection.Query<Customer>($"Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            return customer;
        }

        public int InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        private void MappingDataType<T>(T obj)
        {
            var properties = obj.GetType().GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);

                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(obj, null).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
        }
    }
}
