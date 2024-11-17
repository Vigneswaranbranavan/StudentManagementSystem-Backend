using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class UserResponse
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
    }
}
