using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu mong muốn trả về
        /// </summary>
        public object Data { get; set; }
     
        /// <summary>
        /// Câu thông báo trả về
        /// </summary>
        public string Messeger { get; set; }

        /// <summary>
        /// Mã quy định trả về
        /// </summary>
        public MISACode MISACode{ get; set; }
    }
}
