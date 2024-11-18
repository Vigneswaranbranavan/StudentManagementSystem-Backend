using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly AppDbContext _appDbContext;

        public NotificationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _appDbContext.Notifications.ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(Guid id)
        {
            return await _appDbContext.Notifications.FirstOrDefaultAsync(n => n.ID == id);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Notifications
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _appDbContext.Notifications.AddAsync(notification);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _appDbContext.Notifications.Update(notification);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(Guid id)
        {
            var notification = await _appDbContext.Notifications
                .FirstOrDefaultAsync(n => n.ID == id);
            if (notification != null)
            {
                _appDbContext.Notifications.Remove(notification);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
