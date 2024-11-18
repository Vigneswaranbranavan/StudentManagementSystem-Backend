using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Response
{
    public class NotificationResponse
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
