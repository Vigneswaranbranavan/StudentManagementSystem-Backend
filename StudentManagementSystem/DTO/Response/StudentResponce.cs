using StudentManagementSystem.Entities;
using static StudentManagementSystem.Entities.Student;

namespace StudentManagementSystem.DTO.Response
{
    public class StudentResponce
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string IndexNumber { get; set; }
        public Gender gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassID { get; set; }
        public ClassResponse Class { get; set; }

        public UserResponse UserRes { get; set; }
    }
}
