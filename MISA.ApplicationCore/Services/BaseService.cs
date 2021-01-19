using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        #region Declare
        IBaseRepository<T> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Contructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = MISACode.Success };
        }
        #endregion

        #region Method
        public ServiceResult Delete(Guid entityId, PropertyInfo propertyInfo)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId, propertyInfo);
            _serviceResult.Messeger = "Xóa thành công";
            _serviceResult.MISACode = MISACode.IsValid;
            return _serviceResult;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid entity, PropertyInfo propertyInfo)
        {
            return _baseRepository.GetById(entity, propertyInfo);
        }

        public ServiceResult Insert(T entity)
        {
            entity.EntityState = Enums.EntityState.Insert;
            var isValidate = Validate(entity);
            if (isValidate)
            {
                _serviceResult.Data = _baseRepository.Insert(entity);
                _serviceResult.Messeger = "Thêm thành công";
                _serviceResult.MISACode = MISACode.IsValid;
            }
            return _serviceResult;
        }

        public ServiceResult Update(T entity)
        {
            entity.EntityState = EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.Messeger = "Cập nhật thành công";
                _serviceResult.MISACode = MISACode.IsValid;
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
                var displayName = string.Empty;
                var displayAttribites = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayAttribites.Length > 0)
                {
                    displayName = (displayAttribites[0] as DisplayName).Name;
                }
                //Kiểm tra các property cần phải validte
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập
                    if (propertyValue == null)
                    {
                        isValid = false;
                        errorMesages.Add($"Thông tin {displayName} không được phép để trống");
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messeger = "Dữ liệu không hợp lệ";
                    }
                }
                if (property.IsDefined(typeof(Duplicated), false))
                {
                    //Check trùng dữ liệu
                    var entityProperty = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityProperty != null)
                    {
                        isValid = false;
                        errorMesages.Add($"Thông tin {displayName} đã có trên hệ thống");
                        _serviceResult.MISACode = MISACode.NotValid;
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
