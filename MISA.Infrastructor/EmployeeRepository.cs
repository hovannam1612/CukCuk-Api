using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructor
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Declare
        IConfiguration _configuration;
        #endregion

        #region Constructor
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion
        public int DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            var dbConnection = new MySqlConnection(connectionString);
            var employees = dbConnection.Query<Employee>($"Proc_GetEmployees", commandType: CommandType.StoredProcedure);
            return employees;
        }

        public int InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
