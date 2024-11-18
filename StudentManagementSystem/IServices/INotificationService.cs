using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IServices
{
    public interface INotificationService
    {
        Task<NotificationResponse> AddNotification(NotificationRequest request);
        Task<List<NotificationResponse>> Getnotifications();
        Task<NotificationResponse> GetNotificationById(Guid id);
        Task<NotificationResponse> UpdateNotification(Guid id, NotificationRequest request);
        Task<NotificationResponse> DeleteNotification(Guid id);

    }
}
