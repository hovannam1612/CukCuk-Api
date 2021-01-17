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
        
        public T GetById<T>(object entityObj)
        {
            var tableName = typeof(T).Name;
            var obj = _dbConnection.Query<T>($"Proc_Get{tableName}ById", param: entityObj, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return obj;
        }

        public int Post<T>(T obj){
            var tableName = typeof(T).Name;
            //Lấy param đã được Mapping dự liệu với DB
            var dynamicParameters = MappingDataType(obj);
            // Thực thi truy vấn:
            var rowAffects = _dbConnection.Execute($"Proc_Insert{tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            // Trả về số dòng bị ảnh hưởng:
            return rowAffects;
        }

        public int Put<T>(T entity)
        {
            var tableName = typeof(T).Name;
            //Lấy param đã được Mapping dự liệu với DB
            var dynamicParameters = MappingDataType(entity);
            // Thực thi truy vấn: 
            var rowAffects = _dbConnection.Execute($"Proc_Update{tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            // Trả về số dòng bị ảnh hưởng:
            return rowAffects;
        }

        public int Delete<T>(object entityObj)
        {
            var tableName = typeof(T).Name;
            // Thực thi truy vấn:
            var rowAffects = _dbConnection.Execute($"Proc_Delete{tableName}ById", commandType: CommandType.StoredProcedure, param: entityObj);
            // Trả lại số dòng ảnh hưởng
            return rowAffects;
        }

        private DynamicParameters MappingDataType<T>(T obj)
        {
            var properties = obj.GetType().GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
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
            return dynamicParameters;
        }
        #endregion
    }
}
