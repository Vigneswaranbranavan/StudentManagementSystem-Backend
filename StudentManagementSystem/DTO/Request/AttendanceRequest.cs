using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Request
{
    public class AttendanceRequest
    {
        public Guid StudentID { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
