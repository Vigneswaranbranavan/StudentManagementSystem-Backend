using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(Guid id);

        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(Guid userId);

        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);

        Task DeleteNotificationAsync(Guid id);
    }
}
