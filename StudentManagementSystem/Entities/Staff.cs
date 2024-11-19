namespace StudentManagementSystem.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
