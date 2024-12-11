using StudentManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;
using static StudentManagementSystem.Entities.Student;

namespace StudentManagementSystem.DTO.Request
{
    public class StudentRequest
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string IndexNumber { get; set; }
        public Gender gender { get; set; }
        public Guid ClassID { get; set; }

        public UserRequest UserReq { get; set; }
      
    }
}
