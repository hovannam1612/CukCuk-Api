using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Chức vụ
    /// </summary>
    /// CreatedBy: HVNAM (9/1/2021)
    public class Position : BaseEntity
    {
        #region Declare
        #endregion

        #region Contructor
        public Position()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        #endregion
        
        #region Method
        #endregion

    }
}
