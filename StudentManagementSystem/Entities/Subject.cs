namespace StudentManagementSystem.Entities
{
    public class Subject
    {
        public Guid ID { get; set; }
        public string SubjectName { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();

    }
}
