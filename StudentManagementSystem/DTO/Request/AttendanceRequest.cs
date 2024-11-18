namespace StudentManagementSystem.DTO.Request
{
    public class AttendanceRequest
    {
        public Guid StudentID { get; set; }

        public Guid ClassID { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
