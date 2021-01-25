using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable GetEmployeeFilter(string specs, Guid? departmentId, Guid? positionId)
        {
            return null;
        }

        public IEnumerable GetMaxEmployeeCode()
        {
            return _employeeRepository.GetMaxEmployeeCode();
        }
        #endregion

    }
}
