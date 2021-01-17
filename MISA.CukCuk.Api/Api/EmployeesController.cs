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
    /// <summary>
    /// Api Danh mục nhân viên
    /// CreatedBy: HVNAM (9/1/2021)
    /// </summary>
    public class EmployeesController : BaseEntityController<Employee>
    {
        /*#region Declare
        IBaseService<Employee> _baseService;
        #endregion
        #region Constructor
        public EmployeesController(IBaseService<Employee> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        #endregion*/

        #region Method
        /*public override IActionResult GetById(Guid entityId)
        {
            storeParam = new
            {
                EmployeeId = entityId.ToString()
            };
            return base.GetById(entityId);
        }

        public override IActionResult Delete(Guid entityId)
        {
            storeParam = new
            {
                EmployeeId = entityId.ToString()
            };
            return base.Delete(entityId);
        }*/
        #endregion

    }
}
