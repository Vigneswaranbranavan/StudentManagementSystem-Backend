using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTO;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("SentOTP")]
        public async Task<IActionResult> SentOTP(string email)
        {
            var data = await _userService.SentOTP(email);
            var json = new { message = "OTP sented Succesfully"};
            return Ok(json);
        }
        [HttpPost("CheckOTP")]
        public async Task<IActionResult> CheckOTP(string otp)
        {
            var data = await _userService.CheckOTP(otp);
            var json = new { message = "OTP verifyed Succesfully" };
            return Ok(json);
            
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dTO)
        {
            var data = await _userService.ChangePassword(dTO);
            var json = new { message = "PasswordChanged" };
            return Ok(json);
        }
    }
}



