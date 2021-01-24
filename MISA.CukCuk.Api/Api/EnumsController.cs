using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/enums")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách enum giới tính 
        /// </summary>
        /// <returns>Danh sách giới tính</returns>
        /// CreatedBy: HVNAM (24/1/2021)
        [HttpGet("gender")]
        public IActionResult GetEnumsGender()
        {
            var values = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            var genders = new List<object>();
            foreach (var item in values)
            {
                var enumName = item.ToString();
                var enumText = MISA.ApplicationCore.Properties.Resources.ResourceManager.GetString($"Enum_Gender_{enumName}");
                genders.Add(new
                {
                    GenderName = enumText,
                    Gender = (int)item
                });
            }
            return Ok(genders);
        }

        /// <summary>
        /// Lấy danh sách enum trạng thái công việc
        /// </summary>
        /// <returns>Danh sách trạng thái công việc</returns>
        /// CreatedBy: HVNAM (24/1/2021)
        [HttpGet("workstatus")]
        public IActionResult GetEnumsWorkStatus()
        {
            var values = Enum.GetValues(typeof(WorkStatus)).Cast<WorkStatus>();
            var workStatus = new List<object>();
            foreach (var item in values)
            {
                var enumName = item.ToString();
                var enumText = MISA.ApplicationCore.Properties.Resources.ResourceManager.GetString($"Enum_WorkStatus_{enumName}");
                workStatus.Add(new
                {
                    WorkSatusName = enumText,
                    WorkStatus = (int)item
                });
            }
            return Ok(workStatus);
        }
    }
}
