namespace StudentManagementSystem.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }

    }
}
