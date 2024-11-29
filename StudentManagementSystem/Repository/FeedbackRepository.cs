using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Feedback> AddFeedback(Feedback feedback)
        {
            await _appDbContext.Feedbacks.AddAsync(feedback);
            await _appDbContext.SaveChangesAsync();
            return feedback;
        }


        public async Task<List<Feedback>> GetFeedback()
        {
            var FeedbackData = await _appDbContext.Feedbacks.ToListAsync();
            return FeedbackData;

        }

        public async Task<Feedback> GetFeedbackById(Guid id)
        {
            var FeedbackData = await _appDbContext.Feedbacks.FindAsync(id);
            if (FeedbackData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return FeedbackData;

        }

        public async Task<Feedback> UpdateFeedback(Guid id, FeedbackRequest request)
        {
            var feedbackData = await _appDbContext.Feedbacks.FindAsync(id);
            if (feedbackData == null)
            {
                throw new Exception("ID is Not Found");
            }

            feedbackData.UserID = request.UserID;
            feedbackData.FeedbackType = request.FeedbackType;
            feedbackData.Comments = request.Comments;

            _appDbContext.SaveChanges();
            return feedbackData;
        }

        public async Task<Feedback> DeleteFeedback(Guid id)
        {
            var feedbackData = await _appDbContext.Feedbacks.FindAsync(id);
            if (feedbackData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(feedbackData);
            _appDbContext.SaveChanges();
            return feedbackData;
        }


        public async Task<List<Feedback>> GetFeedbackByUserId(Guid UserId)
        {
            var feedbackData = await _appDbContext.Feedbacks.Where(a => a.UserID == UserId).ToListAsync();
            if (feedbackData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return feedbackData;
        }

    }
}
