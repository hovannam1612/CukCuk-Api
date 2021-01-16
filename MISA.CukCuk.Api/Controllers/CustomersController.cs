using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api Danh mục khách hàng
    /// </summary>
    /// CreatedBy: HVNAM (13/1/2021)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>   
        /// Lấy dữ liệu khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: HVNAm (13/1/2021)
        [HttpGet]
        public IActionResult Get()
        {
            DBConnector dBConnector = new DBConnector();
            var customer = dBConnector.Get<Customer>();
            return Ok(customer);
        }
    }
}
