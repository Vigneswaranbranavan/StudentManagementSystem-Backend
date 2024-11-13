namespace StudentManagementSystem.Entities
{
    public class Attendance
    {
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Student Student { get; set; }
        public Guid ClassID { get; set; }
        public Class Class { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
