using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class TimeTableResponse
    {
        public Guid ID { get; set; }
        public Guid SubjectID { get; set; }
       
        public Guid TeacherID { get; set; }
       
        public Guid ClassID { get; set; }
      
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
    }
}
