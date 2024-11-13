namespace StudentManagementSystem.Entities
{
    public class Subject
    {
        public Guid ID { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public string Department { get; set; }
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();

    }
}
