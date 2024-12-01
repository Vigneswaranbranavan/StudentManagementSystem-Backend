using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class TimeTableResponse
    {
        public Guid ID { get; set; }
       
        public Guid TeacherID { get; set; }
       
        public Guid ClassID { get; set; }
      
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ClassResponse Class { get; set; }
        public TeacherResponse TeacherSubject { get; set; }
    }
}
