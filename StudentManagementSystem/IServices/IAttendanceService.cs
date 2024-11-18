using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface IAttendanceService
    {
        Task<AttendanceResponse> AddAttendance(AttendanceRequest request);
        Task<List<AttendanceResponse>> GetAttendance();
        Task<AttendanceResponse> GetAttendanceById(Guid id);
        Task<AttendanceResponse> UpdateAttendance(Guid id, AttendanceRequest request);
        Task<AttendanceResponse> DeleteAttendance(Guid id);
        Task<List<AttendanceResponse>> GetTimetablesByStudentId(Guid studentId);
        Task<List<AttendanceResponse>> GetAttendanceByClassId(Guid classId);
        Task<List<AttendanceResponse>> GetAttendanceByDate(DateTime date);
    }
}
