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
        ICustomerRepository _customerRepository;
        #endregion

        #region Contructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
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
