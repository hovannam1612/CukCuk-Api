using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.Get();
            return Ok(entities);
        }


        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVNAM (1/9/2021)
        [HttpGet("{entityId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            return Ok();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>Trả về bản ghi được thêm mới</returns>
        /// CreatedBy: HVNAM(9/1/201)
        [HttpPost]
        public IActionResult Insert(T entity)
        {
            var rowEffects = _baseService.Insert(entity);
            if (rowEffects > 0)
            {
                return Created("created", entity);
            }
            else
            {
                return NoContent();
            }

        }
        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="employee">Đối tượng bản ghi cần sửa</param>
        /// <returns>Trả về thông tin bản ghi đã được update</returns>
        /// CreatedBy: HVNAM(13/1/2021)
        [HttpPut]
        public IActionResult Update(T entity)
        {
            var rowAffects = _baseService.Update(entity);
            // Trả lại dữ liệu cho Client:
            if (rowAffects > 0)
                return Ok(entity);
            else
                return NoContent();
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên cần xóa</param>
        /// <returns>Trả về thông báo "Delete success" khi xóa thành công</returns>
        /// CreatedBy: HVNam (13/1/2021)
        [HttpDelete("{entityId}")]
        public virtual IActionResult Delete(Guid entityId)
        {
            var rowAffects = _baseService.Delete(entityId);
            if (rowAffects > 0)
                return Ok("Delete success");
            else
                return NoContent();
        }
        #endregion
    }
}
