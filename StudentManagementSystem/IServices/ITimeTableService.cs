using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface ITimeTableService
    {
        Task<TimeTableResponse> AddTImetable(TimeTableRequest timeTableRequest);
        Task<List<TimeTableResponse>> GetTimetable();
        Task<TimeTableResponse> GetTimetableById(Guid id);
        Task<TimeTableResponse> UpdateTimetable(Guid id, TimeTableRequest request);
        Task<TimeTableResponse> DeleteTimetable(Guid id);
        Task<List<TimeTableResponse>> GetTimetablesByTeacherId(Guid teacherId);
        Task<List<TimeTableResponse>> GetTimetablesByClassId(Guid classId);
        Task<List<TimeTableResponse>> GetTimetablesBySubjectId(Guid subjectId);
    }
}
