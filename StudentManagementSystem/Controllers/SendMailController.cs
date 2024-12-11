using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController(SendMailService sendMailService) : ControllerBase
    {
        [HttpPost("Send-Mail")]
        public async Task<IActionResult> SendMail(SendMailRequest sendMailRequest)
        {
            var res = await sendMailService.SendMail(sendMailRequest).ConfigureAwait(false);
            return Ok(res);
        }
    }
}
