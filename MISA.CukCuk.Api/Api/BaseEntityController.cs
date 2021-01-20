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
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy: HVNNAM (17/1/2021)
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
        public virtual IActionResult GetById([FromRoute] Guid entityId)
        {
           /* var entityIdAttr = $"{typeof(T).Name}Id";
            var property = entity.GetType().GetProperty(entityIdAttr);*/
            var obj = _baseService.GetById(entityId);
            return Ok(obj); 
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
            var serviceResult = _baseService.Insert(entity);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
                return BadRequest(serviceResult);
            return Ok(serviceResult);
        }
        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="employee">Đối tượng bản ghi cần sửa</param>
        /// <returns>Trả về thông tin bản ghi đã được update</returns>
        /// CreatedBy: HVNAM(13/1/2021)
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id,[FromBody] T entity)
        {
            var entityId = $"{typeof(T).Name}Id";
            entity.GetType().GetProperty(entityId).SetValue(entity, id);
            var serviceResult = _baseService.Update(entity);
            // Trả lại dữ liệu cho Client:
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
                return BadRequest(serviceResult);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên cần xóa</param>
        /// <returns>Trả về thông báo "Delete success" khi xóa thành công</returns>
        /// CreatedBy: HVNam (13/1/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete([FromRoute]Guid entityId)
        {
            var serviceResult = _baseService.Delete(entityId);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
                return BadRequest(serviceResult);
            return Ok(serviceResult);
        }
        #endregion
    }
}
