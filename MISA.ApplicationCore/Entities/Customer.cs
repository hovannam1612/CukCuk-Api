using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy: HVNAM (13/1/2021)
    public class Customer:BaseEntity
    {
        #region Declare
        #endregion
        #region Constructor
        public Customer()
        {

        }
        #endregion
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Id khách hàng")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Duplicated]
        [Required]
        [DisplayName("Mã khách hàng")]
        [MaxLength(20, "Mã khách hàng không vượt quá 20 ký tự")]
        public string CustomerCode{ get; set; }

        /// <summary>
        /// Họ và tên khách hàng
        /// </summary>
        [Required]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Số tiền nợ
        /// </summary>
        public Double? DebitAmount { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        [Required]
        [Duplicated]
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
        /// Địa chỉ
        /// </summary>
        public string Address{ get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string CompanyTaxCode { get; set; }
        #endregion

        #region Method
        #endregion

    }
}
