namespace StudentManagementSystem.Entities
{
    public class Attendance
    {
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
    }
    public enum AttendanceStatus
    {
        None = 0,      
        Present = 1,
        Absent = 2,
        LateComing = 3
    }
}
