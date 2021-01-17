using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface danh mục khác hàng
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Lấy khách hàng theo id khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Khách hàng đầu tiên tìm thấy</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        Customer GetCustomerById(Guid customerId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được thêm mới)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int InsertCustomer(Customer customer);

        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (Được cập nhật)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng (bị xóa)</returns>
        /// CreatedBy: HVNAM (17/1/2021)
        int DeleteCustomer(Guid customerId);
    }
}
