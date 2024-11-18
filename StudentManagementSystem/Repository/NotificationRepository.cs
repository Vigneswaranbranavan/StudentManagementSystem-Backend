using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _appDbContext;
        public NotificationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Notification> AddNotification(Notification notification)
        {
            await _appDbContext.Notifications.AddAsync(notification);
            await _appDbContext.SaveChangesAsync();
            return notification;
        }


        public async Task<List<Notification>> Getnotifications()
        {
            var notificationData = await _appDbContext.Notifications.ToListAsync();
            return notificationData;

        }

        public async Task<Notification> GetNotificationById(Guid id)
        {
            var notificationData = await _appDbContext.Notifications.FindAsync(id);
            if (notificationData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return notificationData;

        }

        public async Task<Notification> UpdateNotification(Guid id, NotificationRequest request)
        {
            var notificationData = await _appDbContext.Notifications.FindAsync(id);
            if (notificationData == null)
            {
                throw new Exception("ID is Not Found");
            }

            notificationData.UserID = request.UserID;
            notificationData.NotificationType = request.NotificationType;
            notificationData.Message = request.Message;
            notificationData.Date = request.Date;



            _appDbContext.SaveChanges();
            return notificationData;
        }

        public async Task<Notification> DeleteNotification(Guid id)
        {
            var notificationData = await _appDbContext.Notifications.FindAsync(id);
            if (notificationData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(notificationData);
            _appDbContext.SaveChanges();
            return notificationData;
        }
    }
}
