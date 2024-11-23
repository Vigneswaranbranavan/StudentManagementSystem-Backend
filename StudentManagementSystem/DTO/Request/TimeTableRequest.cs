namespace StudentManagementSystem.DTO.Request
{
    public class TimeTableRequest
    {
        public Guid SubjectID { get; set; }

        public Guid TeacherID { get; set; }

        public Guid ClassID { get; set; }

        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
