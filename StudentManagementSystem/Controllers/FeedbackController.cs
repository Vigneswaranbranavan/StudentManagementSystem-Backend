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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost("Feedback")]
        public async Task<IActionResult> AddFeedback(FeedbackRequest request)
        {
            try
            {
                var ReturnData = await _feedbackService.AddFeedback(request);
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

        [HttpGet("Feedback")]
        public async Task<IActionResult> GetFeedbacks()
        {
            try
            {
                var data = await _feedbackService.GetFeedbacks();
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


        [HttpGet("FeedbackById")]
        public async Task<IActionResult> GetFeedbackById(Guid id)
        {
            try
            {
                var data = await _feedbackService.GetFeedbackById(id);
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

        [HttpPut("Feedback")]
        public async Task<IActionResult> UpdateFeedback(Guid Id, FeedbackRequest request)
        {
            try
            {
                var data = await _feedbackService.UpdateFeedback(Id, request);
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
        [HttpDelete("Feedback")]
        public async Task<IActionResult> DeleteFeedback([FromQuery] Guid UserId)
        {
            try
            {
                // Ensure that UserId is being properly passed and parsed
                if (UserId == Guid.Empty)
                {
                    return BadRequest("Invalid or missing feedback ID.");
                }

                var data = await _feedbackService.DeleteFeedback(UserId);
                if (data == null)
                {
                    return NotFound("Feedback not found.");
                }

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






        [HttpGet("Get Feedback By UserId")]
        public async Task<IActionResult> GetFeedbackByUserId(Guid UserId)
        {
            try
            {
                var data = await _feedbackService.GetFeedbackByUserId(UserId);
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
