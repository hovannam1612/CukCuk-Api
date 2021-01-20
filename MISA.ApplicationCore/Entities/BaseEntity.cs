using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplicated : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

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
