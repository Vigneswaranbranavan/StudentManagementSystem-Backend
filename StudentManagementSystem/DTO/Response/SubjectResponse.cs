using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class SubjectResponse
    {
        public Guid ID { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public string Department { get; set; }
    }
}
