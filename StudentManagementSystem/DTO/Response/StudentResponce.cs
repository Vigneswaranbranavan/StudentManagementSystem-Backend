using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class StudentResponce 
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassID { get; set; }
    }
}
