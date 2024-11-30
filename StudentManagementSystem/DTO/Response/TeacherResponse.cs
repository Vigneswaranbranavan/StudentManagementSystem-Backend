using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class TeacherResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid SubjectID { get; set; }
        public SubjectResponse Subject { get; set; }
        public UserResponse UserRes { get; set; }

    }
}
