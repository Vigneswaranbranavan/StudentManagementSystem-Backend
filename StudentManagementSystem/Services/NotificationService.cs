using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Services
{
    public class NotificationService:INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<NotificationResponse> AddNotification(NotificationRequest request)
        {
            var notify = new Notification
            {
                ID = Guid.NewGuid(),
                UserID = request.UserID,
                NotificationType = request.NotificationType,
                Message = request.Message,
                Date = request.Date

            };


            var notifyData = await _notificationRepository.AddNotification(notify);

            var notifyResponse = new NotificationResponse
            {
                ID = notifyData.ID,
                UserID = notifyData.UserID,
                NotificationType = notifyData.NotificationType,
                Message = notifyData.Message,
                Date = notifyData.Date
            };

            return notifyResponse;
        }


        public async Task<List<NotificationResponse>> Getnotifications()
        {
            var notifyData = await _notificationRepository.Getnotifications();

            var notifyDataList = new List<NotificationResponse>();

            foreach (var item in notifyData)
            {
                var notifyResponse = new NotificationResponse
                {
                    ID = item.ID,
                    UserID = item.UserID,
                    NotificationType = item.NotificationType,
                    Message = item.Message,
                    Date = item.Date
                };

                notifyDataList.Add(notifyResponse);

            }
            return notifyDataList;
        }


        public async Task<NotificationResponse> GetNotificationById(Guid id)
        {
            var notifyData = await _notificationRepository.GetNotificationById(id);

            var notifyResponse = new NotificationResponse
            {
                ID = notifyData.ID,
                UserID = notifyData.UserID,
                NotificationType = notifyData.NotificationType,
                Message = notifyData.Message,
                Date = notifyData.Date
            };

            return notifyResponse;
        }


        public async Task<NotificationResponse> UpdateNotification(Guid id, NotificationRequest request)
        {
            var notifyData = await _notificationRepository.UpdateNotification(id, request);

            var notifyResponse = new NotificationResponse
            {
                ID = notifyData.ID,
                UserID = notifyData.UserID,
                NotificationType = notifyData.NotificationType,
                Message = notifyData.Message,
                Date = notifyData.Date
            };

            return notifyResponse;
        }
        public async Task<NotificationResponse> DeleteNotification(Guid id)
        {
            var notifyData = await _notificationRepository.DeleteNotification(id);

            var notifyResponse = new NotificationResponse
            {
                ID = notifyData.ID,
                UserID = notifyData.UserID,
                NotificationType = notifyData.NotificationType,
                Message = notifyData.Message,
                Date = notifyData.Date
            };

            return notifyResponse;
        }

    }
}
