using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        //{
        //    var users = await _userService.GetAllUsersAsync();
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
        //{
        //    var user = await _userService.GetUserByIdAsync(id);
        //    if (user == null)
        //        return NotFound();
        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddUser(UserRequest userRequest, string roleName)
        //{
        //   var createUser = await _userService.AddUserAsync(userRequest, roleName);
        //    return CreatedAtAction(nameof(GetUserById), new { id = createUser.ID }, createUser);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateUser(Guid id, UserRequest userRequest)
        //{

        //    await _userService.UpdateUserAsync(id,userRequest);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(Guid id)
        //{
        //    await _userService.DeleteUserAsync(id);
        //    return NoContent();
        //}

        [HttpPost("SentOTP")]
        public async Task<IActionResult> SentOTP(string email)
        {
            var data = await _userService.SentOTP(email);
            var json = new { message = "OTP sented da suuu" };
            return Ok(json);
        }
    }
}



