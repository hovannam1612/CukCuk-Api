using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    /// <summary>
    /// Api Danh mục nhân viên
    /// CreatedBy: HVNAM (9/1/2021)
    /// </summary>
    public class EmployeesController : BaseEntityController<Employee>
    { 
        #region Declare
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion


        #region Method
        /// <summary>
        /// Lấy mã nhân viên lớn nhất (không tính các ký tự chữ)
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: HVNAM (24/1/2021)
        [HttpGet("maxemployeecode")]
        public IActionResult GetMaxEmployeeCode()
        {
            var maxCode =  _employeeService.getMaxEmployeeCode();
            return Ok(maxCode);
        }
        #endregion
    }
}
