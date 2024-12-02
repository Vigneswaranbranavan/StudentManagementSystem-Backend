using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IAttendanceRepository
    {
        Task<ICollection<Attendance>> AddAttendance(ICollection<Attendance> attendance);
        Task<List<Attendance>> GetAttendance();
        Task<Attendance> GetAttendanceById(Guid id);
        Task<Attendance> UpdateAttendance(Guid id, AttendanceRequest request);
        Task<Attendance> DeleteAttendance(Guid id);
        Task<List<Attendance>> GetAttendanceByStudentId(Guid studentId);
        Task<List<Attendance>> GetAttendanceByClassId(Guid classId);
        Task<List<Attendance>> GetAttendanceByDate(DateTime date);
    }
}
