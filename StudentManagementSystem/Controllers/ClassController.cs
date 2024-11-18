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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("Class")]
        public async Task<IActionResult> AddClass(ClassRequest classRequest)
        {
            try
            {
                var ReturnData = await _classService.AddClass(classRequest);
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


        [HttpGet("Class")]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var data = await _classService.GetClasses();
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


        [HttpGet("ClassById")]
        public async Task<IActionResult> GetClassById(Guid id)
        {
            try
            {
                var data = await _classService.GetClassById(id);
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

        [HttpPut("Class")]
        public async Task<IActionResult> UpdateClass(Guid Id, ClassRequest request)
        {
            try
            {
                var data = await _classService.UpdateClass(Id, request);
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

        [HttpDelete("Class")]
        public async Task<IActionResult> DeleteClass(Guid id)
        {
            try
            {
                var data = await _classService.DeleteClass(id);
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

        [HttpGet("StudentsByClassId")]
        public async Task<IActionResult> GetStudentsByClassId(Guid id)
        {
            try
            {
                var data = await _classService.GetStudentsByClassId(id);
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

        [HttpGet("TimetableByClassId")]
        public async Task<IActionResult> GetTimetablesByClassId(Guid id)
        {
            try
            {
                var data = await _classService.GetTimetablesByClassId(id);
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
