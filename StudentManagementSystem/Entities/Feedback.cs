namespace StudentManagementSystem.Entities
{
    public class Feedback
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string FeedbackType { get; set; }
        public string Comments { get; set; }
    }
}
