namespace StudentManagementSystem.Entities
{
    public class Class
    {
        public Guid ID { get; set; }
        public string ClassName { get; set; }
        public int GradeLevel { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    }
}
