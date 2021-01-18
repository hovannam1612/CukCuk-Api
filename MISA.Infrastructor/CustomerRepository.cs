using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace MISA.Infrastructor
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Declare
        #endregion

        #region Constructor
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion

        #region Method
        public Customer GetCustomerByCode(string customerCode)
        {
            var customerDuplicate = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customerDuplicate;
        }

        #endregion


    }
}
