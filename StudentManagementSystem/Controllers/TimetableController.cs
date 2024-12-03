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
    public class TimetableController : ControllerBase
    {
        private readonly ITimeTableService _timetableService;
        public TimetableController(ITimeTableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpPost("TimeTable")]
        public async Task<IActionResult> AddTImetable(TimeTableRequest timeTableRequest)
        {


            try
            {
                var ReturnData = await _timetableService.AddTImetable(timeTableRequest);
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



        [HttpGet("TimeTable")]
        public async Task<IActionResult> GetTimetable()
        {
            try
            {
                var data = await _timetableService.GetTimetable();
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



        [HttpGet("TimeTableById")]
        public async Task<IActionResult> GetTimetableById(Guid id)
        {
            try
            {
                var data = await _timetableService.GetTimetableById(id);
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

        [HttpPut("TimeTable")]
        public async Task<IActionResult> UpdateTimetable(Guid Id, TimeTableRequest request)
        {
            try
            {
                var data = await _timetableService.UpdateTimetable(Id, request);
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

        [HttpDelete("TimeTable")]
        public async Task<IActionResult> DeleteTimetable(Guid id)
        {
            try
            {
                var data = await _timetableService.DeleteTimetable(id);
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


        [HttpGet("ByTeacherId")]
        public async Task<IActionResult> GetTimetablesByTeacherId(Guid id)
        {
            try
            {
                var data = await _timetableService.GetTimetablesByTeacherId(id);
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


        [HttpGet("ByClassId")]
        public async Task<IActionResult> GetTimetablesByClassId(Guid id)
        {
            try
            {
                var data = await _timetableService.GetTimetablesByClassId(id);
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




        [HttpGet("BySubjectId")]
        public async Task<IActionResult> GetTimetablesBySubjectId(Guid id)
        {
            try
            {
                var data = await _timetableService.GetTimetablesBySubjectId(id);
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


        [HttpGet("ByDate")]
        public async Task<IActionResult> GetTimetablesByDate(DateTime date)
        {
            try
            {
                var data = await _timetableService.GetTimetablesByDate(date);
                return Ok(data);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { Message = $"Database error: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"An error occurred: {ex.Message}" });
            }
        }



    }
}
