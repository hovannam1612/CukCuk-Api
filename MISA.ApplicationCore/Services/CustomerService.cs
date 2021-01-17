using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;
namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer> , ICustomerService
    {
        #region Declare
        IBaseRepository<Customer> _baseRepository;
        #endregion

        #region Contructor
        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Method
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
