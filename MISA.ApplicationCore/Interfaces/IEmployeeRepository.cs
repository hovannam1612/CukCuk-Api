using MISA.ApplicationCore.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: HVNAM (24/1/2021)
        IEnumerable getMaxEmployeeCode();

        /// <summary>
        /// Lấy danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">Mã, tên hoăc số điện thoại của nhân viên</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã chức vụ</param>
        /// <returns>Danh sách nhân viên theo các tiêu chí</returns>
        /// CreatedBy: HVNAM(24/1/2021)
        IEnumerable getEmployeeFilter(string specs, Guid? departmentId, Guid? positionId);
    }
}
