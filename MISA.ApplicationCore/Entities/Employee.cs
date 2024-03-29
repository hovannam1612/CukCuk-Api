﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{

    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy: HNNAM (9/1/2021)
    public class Employee : BaseEntity
    {
        #region Declare
        #endregion

        #region Contructor
        public Employee()
        {
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
        [Required]
        [Duplicated]
        [DisplayName("Mã nhân viên")]
        [MaxLength(20, "Mã nhân viên không được quá 20 ký tự")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0-Nữ; 1-Nam; 2-Không xác định)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư hoặc căn cước
        /// </summary>
        [Required]
        [Duplicated]
        [DisplayName("Số chứng minh thư hoặc căn cước")]
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
        /// Địa chỉ Email
        /// </summary>
        [Required]
        [Duplicated]
        [Email]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [Duplicated]
        [DisplayName("Số điện thoại")]
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
        /// Trạng thái công việc (0:Đã nghỉ việc ; 1:Đang làm việc; 2: Đang thử việc; 3:Đã nghỉ hưu )
        /// </summary>
        public int WorkStatus { get; set; }

        /// <summary>
        /// Nhóm phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Nhóm chức vụ công việc
        /// </summary>
        public Guid? PositionId { get; set; }
        #endregion

        #region Method
        #endregion
    }
}
