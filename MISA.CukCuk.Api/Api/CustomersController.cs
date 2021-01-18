using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    public class CustomersController : BaseEntityController<Customer>
    {
        #region Declare
        ICustomerService _customerService;
        #endregion
        #region Constructor
        public CustomersController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
        #endregion

        #region Method
        /*public override IActionResult GetById(Guid entityId)
        {
            storeParam = new
            {
                CustomerId = entityId.ToString()
            };
            return base.GetById(entityId);
        }

        public override IActionResult Delete(Guid entityId)
        {
            storeParam = new
            {
                CustomerId = entityId.ToString()
            };
            return base.Delete(entityId);
        }*/
        #endregion
    }
}
