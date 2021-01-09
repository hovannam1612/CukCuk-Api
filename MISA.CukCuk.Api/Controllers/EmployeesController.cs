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

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Lấy dữ liệu nhân viên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVNam (1/9/2020)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Kết nối tới Database: 
                var connectionString = "Host=103.124.92.43;" +
                    "Port=3306;" +
                    "Database=MISACukCuk_MF656_HVNAM;" +
                    "User Id=nvmanh;" +
                    "Password=12345678";
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                // Lấy dữ liệu từ Database:
                var employees = dbConnection.Query<Employee>("Proc_GetEmployees", commandType:CommandType.StoredProcedure);
                // Trả lại dữ liệu cho Client:
                return Ok(employees);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            return StatusCode(201,name);
        }
    }
}
