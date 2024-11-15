using StudentManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTO.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public Role Role { get; set; }
    }
}
