using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructor
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(T).Name;
        }
        #endregion

        #region Method
        public int Delete(Guid entityId)
        {
            int rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var query = $"DELETE FROM {_tableName} WHERE {_tableName}Id = '{entityId.ToString()}'";
                    rowAffects = _dbConnection.Execute(query, commandType: CommandType.Text);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }
            return rowAffects;
        }

        public IEnumerable<T> Get()
        {
            var entities = _dbConnection.Query<T>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public T GetById(Guid entityId)
        {
            var query = $"SELECT * FROM {_tableName} WHERE {_tableName}Id = '{entityId.ToString()}'";
            var obj = _dbConnection.Query<T>(query, commandType: CommandType.Text).FirstOrDefault();
            return obj;
        }

        public int Insert(T entity)
        {
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var dynamicParameters = MappingDataType(entity);
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }
            return rowAffects;
        }

        public int Update(T entityId)
        {
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var dynamicParameters = MappingDataType(entityId);
                    rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }
            return rowAffects;
        }

        /// <summary>
        /// Mapping dự liệu với DB
        /// </summary>
        /// <param name="obj">Đối tượng cần mapping dữ liệu</param>
        /// <returns>Parammerts đã mapping</returns>
        /// CreatedBy: HVNAM (20/1/2021)
        private DynamicParameters MappingDataType(T obj)
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

        public T GetEntityByProperty(T entity, PropertyInfo propertyInfo)
        {
            var propertyName = propertyInfo.Name;
            var propertyValue = propertyInfo.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.Insert)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            else if (entity.EntityState == EntityState.Update)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            else
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            var enityReturn = _dbConnection.Query<T>(query, commandType: CommandType.Text).FirstOrDefault();
            return enityReturn;
        }

        /// <summary>
        /// Tụ động Đóng kết nối 
        /// </summary>
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        #endregion
    }
}
