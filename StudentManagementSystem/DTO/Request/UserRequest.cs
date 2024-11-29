using StudentManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTO.Request
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        
    }
}
