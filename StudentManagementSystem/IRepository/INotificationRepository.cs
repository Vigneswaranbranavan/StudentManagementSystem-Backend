using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface INotificationRepository
    {
        Task<Notification> AddNotification(Notification notification);
        Task<List<Notification>> Getnotifications();
        Task<Notification> GetNotificationById(Guid id);
        Task<Notification> UpdateNotification(Guid id, NotificationRequest request);
        Task<Notification> DeleteNotification(Guid id);
        Task<List<Notification>> GetNotificationByUserId(Guid UserId);
    }
}
