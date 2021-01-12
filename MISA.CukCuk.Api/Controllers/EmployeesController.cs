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
    /// <summary>
    /// Api Danh mục nhân viên
    /// CreatedBy: HVNAM (9/1/2021)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: HVNam (1/9/2020)
        [HttpGet]
        public IActionResult GetEmployee()
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
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Trả về nhân viên được thêm mới</returns>
        /// CreatedBy: HVNAM(9/1/201)
        [HttpPost]
        public IActionResult Post(Employee employee)
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

                //Lấy param
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = employee.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(employee);
                    if (property.PropertyType == typeof(Guid))
                        propertyValue = property.GetValue(employee).ToString();
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }

                // Lấy dữ liệu từ Database:
                var rowAffects = dbConnection.Execute("Proc_InsertEmployee", commandType: CommandType.StoredProcedure, param: dynamicParameters);

                // Trả lại dữ liệu cho Client:
                if (rowAffects > 0)
                    return Created("Thêm thành công", employee);
                else
                    return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
