using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    /// <summary>
    /// Kết nối với cơ sở dữ liệu (MariaDB)
    /// </summary>
    /// CreateBy: HVNAM (14/1/2021)
    [Route("api/[controller]")]
    [ApiController]
    public class DBConnector : ControllerBase
    {
        #region Declare
        //Chuỗi kết nối database 
        string _connectionString = "Host=103.124.92.43;" +
            "Port=3306;" +
            "Database=MISACukCuk_MF656_HVNAM;" +
            "User Id=nvmanh;" +
            "Password=12345678";
        IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DBConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<T> Get<T>()
        {
            var tableName = typeof(T).Name;
            var obj = _dbConnection.Query<T>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
            return obj;
        }
        
        public T GetById<T>(Guid entityId)
        {
            var tableName = typeof(T).Name;
            var storeParamObject = new
            {
                property = entityId.ToString()
            };
            var obj = _dbConnection.Query<T>($"Proc_Get{tableName}ById", param: storeParamObject, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return obj;
        }

        public int Post<T>(T obj){
            var tableName = typeof(T).Name;
            //Lấy param
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);

                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(obj, null).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            // Lấy dữ liệu từ Database:
            var rowAffects = _dbConnection.Execute($"Proc_Insert{tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            
            // Trả lại dữ liệu cho Client:
            return rowAffects;
        }
        #endregion
    }
}
