using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    public class CustomersController : EntityController<Customer>
    {
        public override IActionResult GetById(Guid entityId)
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
        }
    }
}
