using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<T> : IBaseService<T> where T:BaseEntity
    {
        #region Declare
        IBaseRepository<T> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Contructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Enums.MISACode.Success };
        }
        #endregion

        #region Method
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data =  _baseRepository.Delete(entityId);
            return _serviceResult;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public virtual ServiceResult Insert(T entity)
        {
            entity.EntityState = Enums.EntityState.Insert;
            var isValidate = Validate(entity);
            if (isValidate)
            {
                _serviceResult.Data = _baseRepository.Insert(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
            }
            return _serviceResult;
        }

        public ServiceResult Update(T entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
            }
            return _serviceResult;
        }

        private bool Validate(T entity)
        {
            var isValid = true;
            var errorMesages = new List<string>();
            //Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                //Kiểm tra các property cần phải validte
                if(property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập
                    if(propertyValue != null)
                    {
                        isValid = false;
                        errorMesages.Add($"Thông tin {displayName} không được phép để trống");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messeger = "Dữ liệu không hợp lệ";
                    }
                }
                if(property.IsDefined(typeof(Duplicated), false))
                {
                    //Check trùng dữ liệu
                    var entityProperty = _baseRepository.GetEntityByProperty(property.Name, property.GetValue(entity));
                    if(entityProperty != null)
                    {
                        isValid = false;
                        errorMesages.Add($"Thông tin {displayName} đã có trên hệ thống");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messeger = "Dữ liệu không hợp lệ";
                    }
                }
            }
            _serviceResult.Data = errorMesages;
            return isValid;
        }
        #endregion
    }
}
