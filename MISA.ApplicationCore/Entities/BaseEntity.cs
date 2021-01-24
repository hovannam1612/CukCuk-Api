using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Attribute bắt buộc nhập
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    /// <summary>
    /// Attribute Không được trùng
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplicated : Attribute
    {

    }

    /// <summary>
    /// Attribute khóa chính
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    /// <summary>
    /// Attribute Hiện thị tên Property
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        /// <summary>
        /// Tên hiện thị của từng property
        /// </summary>
        public string Name { get; set; }
        public DisplayName(string name = null)
        {
            this.Name = name;
        }
    }
    /// <summary>
    /// Attribute check Email hợp lệ
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {
        
    }

    /// <summary>
    /// Attribute độ dài max của ký tự
    /// </summary>
    /// CreatedBy: HVNAM (21/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        /// <summary>
        /// Số lượng ký tự
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string ErrorMsg { get; set; }
        public MaxLength(int length, string errorMsg)
        {
            this.Length = length;
            this.ErrorMsg = errorMsg;
        }
    }

    public class BaseEntity
    {
        /// <summary>
        /// Trạng thái của từng nghiệp vụ (Thêm: 1; Sửa: 2; Xóa: 3)
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.Insert;

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
