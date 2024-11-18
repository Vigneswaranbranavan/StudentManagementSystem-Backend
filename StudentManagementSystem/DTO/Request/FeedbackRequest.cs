namespace StudentManagementSystem.DTO.Request
{
    public class FeedbackRequest
    {
        public Guid UserID { get; set; }

        public string FeedbackType { get; set; }
        public string Comments { get; set; }

    }
}
