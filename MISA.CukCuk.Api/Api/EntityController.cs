using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntityController<T> : ControllerBase
    {
        #region Declare
        DBConnector _dBConnector;
        //Lấy param có id map với từng đối tượng
        public object storeParam;
        #endregion
        #region Constructor
        public EntityController()
        {
            _dBConnector = new DBConnector();
        }
        #endregion
        #region Method

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy: HVNam (1/9/2020)
        [HttpGet]
        public IActionResult Get()
        {
            var obj = _dBConnector.Get<T>();
            return Ok(obj);
        }


        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVNAM (1/9/2021)
        [HttpGet("{entityId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            var obj = _dBConnector.GetById<T>(storeParam);
            return Ok(obj);
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên</param>
        /// <returns>Trả về nhân viên được thêm mới</returns>
        /// CreatedBy: HVNAM(9/1/201)
        [HttpPost]
        public IActionResult Post(T entity)
        {
            var rowEffects = _dBConnector.Post<T>(entity);
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
        /// Sửa nhân viên
        /// </summary>
        /// <param name="employeeId">id nhân viên cần sửa</param>
        /// <param name="employee">thông tin nhân viên cần sửa</param>
        /// <returns>Trả về thông tin nhân viên đã được update</returns>
        /// CreatedBy: HVNAM(13/1/2021)
        [HttpPut]
        public IActionResult Update(T entity)
        {
            var rowAffects = _dBConnector.Put<T>(entity);
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
            var rowAffects = _dBConnector.Delete<T>(storeParam);
            if (rowAffects > 0)
                return Ok("Delete success");
            else
                return NoContent();
        }
        #endregion

    }
}
