using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class ClassResponse
    {
        public Guid ID { get; set; }
        public string ClassName { get; set; }
        public int GradeLevel { get; set; }

    }
}
