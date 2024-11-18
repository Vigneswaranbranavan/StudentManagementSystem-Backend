namespace StudentManagementSystem.DTO.Request
{
    public class TimeTableRequest
    {
        public Guid SubjectID { get; set; }

        public Guid TeacherID { get; set; }

        public Guid ClassID { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
    }
}
