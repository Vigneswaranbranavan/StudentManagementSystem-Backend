namespace StudentManagementSystem.Entities
{
    public class OTP
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string Code { get; set; }
    }
}
