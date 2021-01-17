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
        IBaseService<Customer> _baseService;
        #endregion
        #region Constructor
        public CustomersController(IBaseService<Customer> baseService) : base(baseService)
        {
            _baseService = baseService;
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
