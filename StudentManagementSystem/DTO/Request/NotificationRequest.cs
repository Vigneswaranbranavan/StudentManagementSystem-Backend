using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Request
{
    public class NotificationRequest
    {
        public Guid UserID { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

    }
}
