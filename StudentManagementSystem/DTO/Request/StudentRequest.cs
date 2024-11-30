using StudentManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTO.Request
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid ClassID { get; set; }

        public UserRequest UserReq { get; set; }
      
    }
}
