using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class FeedbackResponse
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
   
        public string FeedbackType { get; set; }
        public string Comments { get; set; }
    }
}
