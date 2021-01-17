using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Contructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Method
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            return _baseRepository.Insert(entity);
        }

        public int Update(T entityId)
        {
            return _baseRepository.Update(entityId);
        }
        #endregion
    }
}
