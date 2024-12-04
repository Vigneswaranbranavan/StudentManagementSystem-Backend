using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost("Staff")]
        public async Task<IActionResult> AddStaff(StaffRequest request)
        {
            try
            {
                var createStaff = await _staffService.AddStaffAsync(request);
                return CreatedAtAction(nameof(GetStaffById), new { id = createStaff.Id }, createStaff);
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

        [HttpGet("Staff")]
        public async Task<IActionResult> GetStaff()
        {
            try
            {
                var data = await _staffService.GetStaffs();
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


        [HttpGet("StaffById")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            try
            {
                var data = await _staffService.GetStaffById(id);
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

        [HttpPut("Staff")]
        public async Task<IActionResult> UpdateStaff(Guid Id, StaffReqDto request)
        {
            try
            {
                var data = await _staffService.UpdateStaff(Id, request);
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


        [HttpDelete("Staff")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            try
            {
                var data = await _staffService.DeleteStaff(id);
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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<StaffResponse>> GetStaffByUserIdAsync(Guid userId)
        {
            try
            {
                var Staff = await _staffService.GetStaffByUserIdAsync(userId);
                return Ok(Staff);  // The response now includes the Class details
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Staff not found for the provided UserID." });
            }
        }
    }
}
