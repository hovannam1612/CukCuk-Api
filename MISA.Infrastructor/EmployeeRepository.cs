using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructor
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Declare
        #endregion

        #region Constructor
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion

        #region Method
        public IEnumerable GetEmployeeFilter(string specs, Guid? departmentId, Guid? positionId)
        {
            return null;
        }

        public IEnumerable GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _dbConnection.Query("Proc_getEmployeeCodeMax", commandType: CommandType.StoredProcedure).FirstOrDefault();
            return maxEmployeeCode;
        }
        #endregion
    }
}
