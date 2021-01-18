using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        public ServiceResult Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
