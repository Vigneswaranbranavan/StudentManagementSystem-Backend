using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Request
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassID { get; set; }

    }
}
