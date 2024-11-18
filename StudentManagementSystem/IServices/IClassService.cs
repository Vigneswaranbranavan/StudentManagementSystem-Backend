using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface IClassService
    {
        Task<ClassResponse> AddClass(ClassRequest classRequest);
        Task<List<ClassResponse>> GetClasses();
        Task<ClassResponse> GetClassById(Guid id);
        Task<ClassResponse> UpdateClass(Guid id, ClassRequest request);
        Task<ClassResponse> DeleteClass(Guid id);
        Task<List<StudentResponce>> GetStudentsByClassId(Guid classId);
        Task<List<TimeTableResponse>> GetTimetablesByClassId(Guid classId);
    }
}
