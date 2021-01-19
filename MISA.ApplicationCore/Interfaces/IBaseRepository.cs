using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface dùng chung cho Repository
    /// </summary>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>danh sách dữ liệu</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        IEnumerable<T> Get();

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="entityId">id bản ghi cần lấy</param>
        /// <returns>Bản ghi đầu tiên tìm thấy</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        T GetById(Guid entityId, PropertyInfo propertyInfo);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng bản ghi</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được thêm mới)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int Insert(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entityId">Đối tượng bản ghi</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được cập nhật)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int Update(T entityId);

        /// <summary>
        /// Xóa bản ghi theo id
        /// <param name="entityId">id bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (bị xóa)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int Delete(Guid entityId, PropertyInfo propertyInfo);

        /// <summary>
        /// Tìm kiếm dữ liệu theo các tiêu chí
        /// </summary>
        /// <param name="entity">Đối tượng cần tìm</param>
        /// <param name="propertyName">Tên tiêu chí</param>
        /// <returns>Số lượng bản ghi tìm thấy</returns>
        /// CreatedBy: HNNAM (18/1/2021)
        T GetEntityByProperty(T entity, PropertyInfo propertyInfo);
    }
}
