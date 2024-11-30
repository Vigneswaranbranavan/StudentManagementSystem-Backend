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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("Teacher")]
        public async Task<IActionResult> AddTeacher(TeacherRequest teacherRequest)
        {
            try
            {
                var createTeacher = await _teacherService.AddTeacherAsync(teacherRequest);
                return CreatedAtAction(nameof(GetTeacherById), new { id = createTeacher.ID }, createTeacher);
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

        [HttpGet("Teacher")]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var data = await _teacherService.GetTeachers();
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


        [HttpGet("TeacherById")]
        public async Task<IActionResult> GetTeacherById(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTeacherById(id);
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

        [HttpPut("Teacher")]
        public async Task<IActionResult> UpdateTeacher(Guid Id, TeacherReqDto request)
        {
            try
            {
                var data = await _teacherService.UpdateTeacher(Id, request);
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



        [HttpGet("TimetableByTeacherId")]
        public async Task<IActionResult> GetTimetableByTeacherId(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTimetableByTeacherId(id);
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

        [HttpGet("GetTeacherBySubjectId")]
        public async Task<IActionResult> GetTeacherBySubjectId(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTeacherBySubjectId(id);
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

        [HttpDelete("Teacher")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            try
            {
                var data = await _teacherService.DeleteTeacher(id);
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
