namespace StudentManagementSystem.Entities
{
    public class Teacher
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid SubjectID { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    }
}
