using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface IFeedbackService
    {
        Task<FeedbackResponse> AddFeedback(FeedbackRequest request);
        Task<List<FeedbackResponse>> GetFeedbacks();
        Task<FeedbackResponse> GetFeedbackById(Guid id);
        Task<FeedbackResponse> UpdateFeedback(Guid id, FeedbackRequest request);
        Task<FeedbackResponse> DeleteFeedback(Guid id);
    }
}
