using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddFeedback(Feedback feedback);
        Task<List<Feedback>> GetFeedback();
        Task<Feedback> GetFeedbackById(Guid id);
        Task<Feedback> UpdateFeedback(Guid id, FeedbackRequest request);
        Task<Feedback> DeleteFeedback(Guid id);
    }
}
