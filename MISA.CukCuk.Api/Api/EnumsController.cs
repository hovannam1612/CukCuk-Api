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
