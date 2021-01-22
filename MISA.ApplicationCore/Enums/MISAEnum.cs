using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Enums
{
    /// <summary>
    /// MISACode để xác định trạng thái của việc validate
    /// </summary>
    /// CreatedBy:HVNAM (22/1/2021)
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu chưa hợp lệ
        /// </summary>
        NotValid = 900,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Xảy ra Exception
        /// </summary>
        Exception = 500
    }

    /// <summary>
    /// Trạng thái của các nghiệp vụ
    /// </summary>
    /// CreatedBy:HVNAM (22/1/2021)
    public enum EntityState
    {
        /// <summary>
        /// Thêm
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Sửa
        /// </summary>
        Update = 2,
        
        /// <summary>
        /// Xóa
        /// </summary>
        Delete = 3
    }

    /// <summary>
    /// Thông tin giới tính
    /// </summary>
    /// CreatedBy:HVNAM (22/1/2021)
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Female,

        /// <summary>
        /// Nam
        /// </summary>
        Male,

        /// <summary>
        /// Chưa xác định
        /// </summary>
        Other,
    }

    /// <summary>
    /// Enum tình trạng công việc
    /// </summary>
    /// CreatedBy:HVNAM (22/1/2021)
    public enum WorkStatus
    {
        /// <summary>
        /// Đã nghỉ việc
        /// </summary>
        Resign,

        /// <summary>
        /// Đang làm việc
        /// </summary>
        Working,

        /// <summary>
        /// Đang thử việc
        /// </summary>
        TrainWork,

        /// <summary>
        /// Đã nghỉ hưu
        /// </summary>
        Retired
    }
}
