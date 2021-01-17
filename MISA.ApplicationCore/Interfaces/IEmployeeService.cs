using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Lấy nhân viên theo id nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>nhân viên đầu tiên tìm thấy</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        Employee GetEmployeeById(Guid employeeId);

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được thêm mới)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int InsertEmployee(Employee employee);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được cập nhật)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int UpdateEmployee(Employee employee);

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (bị xóa)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int DeleteEmployee(Guid employeeId);
    }
}
