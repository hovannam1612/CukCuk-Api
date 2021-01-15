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
    /// <summary>
    /// Api Danh mục nhân viên
    /// CreatedBy: HVNAM (9/1/2021)
    /// </summary>
    
    public class EmployeesController : EntityController<Employee>
    {

    }
}
