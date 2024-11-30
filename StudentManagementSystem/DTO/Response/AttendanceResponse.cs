using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class AttendanceResponse
    {
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        
        
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
