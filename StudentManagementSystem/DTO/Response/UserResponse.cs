using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class UserResponse
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
