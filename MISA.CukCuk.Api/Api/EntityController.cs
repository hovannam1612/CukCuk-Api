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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntityController<T> : ControllerBase
    {
        #region Declare
        DBConnector _dBConnector;
        #endregion
        #region Constructor
        public EntityController()
        {
            _dBConnector = new DBConnector();
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy: HVNam (1/9/2020)
        [HttpGet]
        public IActionResult Get()
        {
            var obj = _dBConnector.Get<T>();
            return Ok(obj);
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVNAM (1/9/2021)
        [HttpGet("{entityId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            var obj = _dBConnector.GetById<T>(entityId);
            return Ok(obj);
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

                    if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                    {
                        if(propertyValue!=null)
                        {
                            propertyValue = property.GetValue(employee, null).ToString();
                        }
                        else
                        {
                            propertyValue = "";
                        }
                    }
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

        /// <summary>
        /// Sửa nhân viên
        /// </summary>
        /// <param name="employeeId">id nhân viên cần sửa</param>
        /// <param name="employee">thông tin nhân viên cần sửa</param>
        /// <returns>Trả về thông tin nhân viên đã được update</returns>
        /// CreatedBy: HVNAM(13/1/2021)
        [HttpPut]
        public IActionResult Update([FromBody] Employee employee)
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

                    if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                    {
                        propertyValue = property.GetValue(employee, null).ToString();
                    }
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }

                // Lấy dữ liệu từ Database:
                var rowAffects = dbConnection.Execute("Proc_UpdateEmployee", commandType: CommandType.StoredProcedure, param: dynamicParameters);

                // Trả lại dữ liệu cho Client:
                if (rowAffects > 0)
                    return Ok(employee);
                else
                    return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên cần xóa</param>
        /// <returns>Trả về thông báo "Delete success" khi xóa thành công</returns>
        /// CreatedBy: HVNam (13/1/2021)
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid employeeId)
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
                var storeParamObject = new
                {
                    EmployeeId = employeeId.ToString(),
                };
                // Lấy dữ liệu từ Database:
                var rowAffects = dbConnection.Execute("Proc_DeleteEmployeeById", commandType: CommandType.StoredProcedure, param: storeParamObject);

                // Trả lại dữ liệu cho Client:
                if (rowAffects > 0)
                    return Ok("Delete success");
                else
                    return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
