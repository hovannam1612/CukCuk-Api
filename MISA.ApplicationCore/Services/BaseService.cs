using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

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
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            _serviceResult.Messeger = Properties.Resources.Msg_Deleted;
            _serviceResult.MISACode = MISACode.IsValid;
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

        public ServiceResult Insert(T entity)
        {
            entity.EntityState = Enums.EntityState.Insert;
            var isValidate = Validate(entity);
            if (isValidate)
            {
                _serviceResult.Data = _baseRepository.Insert(entity);
                _serviceResult.Messeger = Properties.Resources.Msg_Inserted;
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
                _serviceResult.Messeger = Properties.Resources.Msg_Updated;
                _serviceResult.MISACode = MISACode.IsValid;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Hàm kiểm tra dữ liệu hợp lệ
        /// </summary>
        /// <param name="entity">Đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - nếu dữ liệu hợp lệ; false - dữ liệu không hợp lệ</returns>
        /// CreatedBy: HVNAM (20/1/2021)
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
                if (displayAttribites.Length > 0)
                {
                    displayName = (displayAttribites[0] as DisplayName).Name;
                }
                //Kiểm tra các property cần phải validte
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập
                    if (propertyValue == null || propertyValue.ToString() == "")
                    {
                        isValid = false;
                        errorMesages.Add(string.Format(Properties.Resources.Msg_Required, displayName));
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(Duplicated), false))
                {
                    //Check trùng dữ liệu
                    var entityProperty = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityProperty != null)
                    {
                        isValid = false;
                        errorMesages.Add(string.Format(Properties.Resources.Msg_Duplicated, displayName));
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    var maxLengthAttributes = property.GetCustomAttributes(typeof(MaxLength), true);
                    var length = (maxLengthAttributes[0] as MaxLength).Length;
                    var msg = (maxLengthAttributes[0] as MaxLength).ErrorMsg;
                    if (propertyValue.ToString().Trim().Length > length)
                    {
                        isValid = false;
                        errorMesages.Add(msg);
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(Email), false))
                {
                    var value = propertyValue.ToString();
                    //Regex format email
                    string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                    var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    var email = regex.IsMatch(value);
                    if (email == false)
                    {
                        isValid = false;
                        errorMesages.Add(Properties.Resources.Msg_Email);
                        _serviceResult.MISACode = MISACode.NotValid;
                        _serviceResult.Messeger = Properties.Resources.Msg_IsNotValid;
                    }
                }
            }
            _serviceResult.Data = errorMesages;
            if (isValid)
                ValidateCustom(entity);
            return isValid;
        }

        /// <summary>
        /// Hàm kiểm tra dữ liệu tùy chỉnh
        /// </summary>
        /// <param name="entity">Đối tượng khách hàng cần kiểm tra dữ liệu</param>
        /// <returns>true - nếu dữ liệu hợp lệ; false - dữ liệu không hợp lệ</returns>
        /// CreatedBy: HVNAM (20/1/2021)
        protected virtual bool ValidateCustom(T entity)
        {
            return true;
        }

        #endregion
    }
}
