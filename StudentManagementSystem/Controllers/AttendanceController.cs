using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("Attendance")]
        public async Task<IActionResult> AddAttendance(AttendanceRequest request)
        {
            try
            {
                var ReturnData = await _attendanceService.AddAttendance(request);
                return Ok(ReturnData);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Attendance")]
        public async Task<IActionResult> GetAttendance()
        {
            try
            {
                var data = await _attendanceService.GetAttendance();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("AttendanceById")]
        public async Task<IActionResult> GetAttendanceById(Guid id)
        {
            try
            {
                var data = await _attendanceService.GetAttendanceById(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Attendance")]
        public async Task<IActionResult> UpdateAttendance(Guid Id, AttendanceRequest request)
        {
            try
            {
                var data = await _attendanceService.UpdateAttendance(Id, request);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Attendance")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            try
            {
                var data = await _attendanceService.DeleteAttendance(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TimetablesByStudentId")]
        public async Task<IActionResult> GetTimetablesByStudentId(Guid id)
        {
            try
            {
                var data = await _attendanceService.GetTimetablesByStudentId(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("AttendanceByClassId")]
        public async Task<IActionResult> GetAttendanceByClassId(Guid id)
        {
            try
            {
                var data = await _attendanceService.GetAttendanceByClassId(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("AttendanceByDate")]
        public async Task<IActionResult> GetAttendanceByDate(DateTime date)
        {
            try
            {
                var data = await _attendanceService.GetAttendanceByDate(date);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
