using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IUserService userService,ITokenRepository tokenRepository)
        {
            _userService = userService;
            _tokenRepository = tokenRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login( UserRequest userRequest)
        {
            if (userRequest == null || string.IsNullOrEmpty(userRequest.Email) || string.IsNullOrEmpty(userRequest.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            try
            {
                var (token, user) = await _userService.Authenticate(userRequest.Email, userRequest.Password);
                return Ok(new
                {
                    Token = token,
                    User = new
                    {
                        Email = user.Email,
                        Role = user.UserRole?.Role?.RoleName
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
