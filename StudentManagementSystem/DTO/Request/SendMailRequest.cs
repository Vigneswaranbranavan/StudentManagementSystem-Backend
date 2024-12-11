using StudentManagementSystem.Entities.E_mail;

namespace StudentManagementSystem.DTO.Request
{
    public class SendMailRequest
    {
        public string? Name { get; set; }
        public string? OTP { get; set; }
        public string? Email { get; set; }
        public EmailType EmailType { get; set; }
    }
}
