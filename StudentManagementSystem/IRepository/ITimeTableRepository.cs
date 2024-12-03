using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface ITimeTableRepository
    {
        Task<Timetable> AddTImetable(Timetable timetable);
        Task<List<Timetable>> GetTimetable();
        Task<Timetable> GetTimetableById(Guid id);
        Task<Timetable> UpdateTimetable(Guid id, TimeTableRequest timeTableRequest);
        Task<Timetable> DeleteTimetable(Guid id);
        Task<List<Timetable>> GetTimetablesByTeacherId(Guid teacherId);
        Task<List<Timetable>> GetTimetablesByClassId(Guid classId);
        Task<List<Timetable>> GetTimetablesBySubjectId(Guid subjectId);
        Task<List<Timetable>> GetTimetablesByDate(DateTime date);

    }
}
