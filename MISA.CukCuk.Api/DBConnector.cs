using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    public class DBConnector
    {
        #region Declare
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
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc"></param>
        /// <returns></returns>
        public IEnumerable<T> Get<T>()
        {
            string tableName = typeof(T).Name;
            var obj = _dbConnection.Query<T>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
            return obj;
        }
        #endregion

    }
}
