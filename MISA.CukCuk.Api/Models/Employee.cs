using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Models
{

    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy: HNNAM (9/1/2021)
    public class Employee
    {
        #region Declare
        #endregion

        #region Contructor
        public Employee() { 
        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0-Nữ; 1-Nam; 2-Khác)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư / căn cước
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public Double? Salary { get; set; }

        /// <summary>
        /// Ngày vào công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Trạng thái công việc
        /// </summary>
        public int WorkStatus { get; set; }

        /// <summary>
        /// Nhóm phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Nhóm chức vụ công việc
        /// </summary>
        public Guid? PositionId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #endregion
        
        #region Method
        #endregion
    }
}
