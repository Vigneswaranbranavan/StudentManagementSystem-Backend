using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using System.Xml.Linq;

namespace StudentManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackResponse> AddFeedback(FeedbackRequest request)
        {
            var feedback = new Feedback
            {
                ID = Guid.NewGuid(),
                UserID = request.UserID,
                FeedbackType = request.FeedbackType,
                Comments = request.Comments,


            };


            var feedbackData = await _feedbackRepository.AddFeedback(feedback);

            var feedbackResponse = new FeedbackResponse
            {
                ID = feedbackData.ID,
                UserID = feedbackData.UserID,
                FeedbackType = feedbackData.FeedbackType,
                Comments = feedbackData.Comments
                
            };

            return feedbackResponse;
        }


        public async Task<List<FeedbackResponse>> GetFeedbacks()
        {
            var feedbackData = await _feedbackRepository.GetFeedback();

            var feedbackDataList = new List<FeedbackResponse>();

            foreach (var item in feedbackData)
            {
                var feedbackRes = new FeedbackResponse
                {
                    ID = item.ID,
                    UserID = item.UserID,
                    FeedbackType = item.FeedbackType,
                    Comments = item.Comments
                };

                feedbackDataList.Add(feedbackRes);
            }
            return feedbackDataList;
        }


        public async Task<FeedbackResponse> GetFeedbackById(Guid id)
        {
            var feedbackData = await _feedbackRepository.GetFeedbackById(id);

            var feedbackResponse = new FeedbackResponse
            {
                ID = feedbackData.ID,
                UserID = feedbackData.UserID,
                FeedbackType = feedbackData.FeedbackType,
                Comments = feedbackData.Comments

            };
            return feedbackResponse;
        }


        public async Task<FeedbackResponse> UpdateFeedback(Guid id, FeedbackRequest request)
        {
            var feedbackData = await _feedbackRepository.UpdateFeedback(id, request);

            var feedbackResponse = new FeedbackResponse
            {
                ID = feedbackData.ID,
                UserID = feedbackData.UserID,
                FeedbackType = feedbackData.FeedbackType,
                Comments = feedbackData.Comments

            };

            return feedbackResponse;
        }
        public async Task<FeedbackResponse> DeleteFeedback(Guid id)
        {
            var feedbackData = await _feedbackRepository.DeleteFeedback(id);

            var feedbackResponse = new FeedbackResponse
            {
                ID = feedbackData.ID,
                UserID = feedbackData.UserID,
                FeedbackType = feedbackData.FeedbackType,
                Comments = feedbackData.Comments

            };

            return feedbackResponse;
        }

    }
}
