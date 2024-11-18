using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface ITeacherService
    {
        Task<TeacherResponse> AddTeacher(TeacherRequest teacherRequest);
        Task<List<TeacherResponse>> GetTeachers();
        Task<TeacherResponse> GetTeacherById(Guid id);
        Task<TeacherResponse> UpdateTeacher(Guid id, TeacherRequest request);
        Task<List<TimeTableResponse>> GetTimetableByTeacherId(Guid id);
        Task<List<TeacherResponse>> GetTeachersBySubjectId(Guid subjectId);
        Task<TeacherResponse> DeleteTeacher(Guid id);
    }
}
