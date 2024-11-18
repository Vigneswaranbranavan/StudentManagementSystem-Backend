using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IClassRepository
    {
        Task<Class> AddClass(Class @class);
        Task<List<Class>> GetClasses();
        Task<Class> GetClassById(Guid id);
        Task<Class> UpdateClass(Guid id, ClassRequest classRequest);
        Task<Class> DeleteClass(Guid id);
        Task<List<Student>> GetStudentsByClassId(Guid classId);
        Task<List<Timetable>> GetTimetablesByClassId(Guid classId);


    }
}
