using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Request
{
    public class SubjectRequest
    {
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public string Department { get; set; }
    }
}
