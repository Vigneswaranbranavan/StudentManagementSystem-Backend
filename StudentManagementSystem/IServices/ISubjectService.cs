using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IServices
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectResponse>> GetAllSubjectsAsync();
        Task<SubjectResponse> GetSubjectByIdAsync(Guid id);
        Task UpdateSubjectAsync(Guid id, SubjectRequest subjectRequest);
        Task<SubjectResponse> AddSubjectAsync(SubjectRequest subjectRequest);
        Task DeleteSubjectAsync(Guid id);
    }
        
}
