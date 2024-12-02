using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacherById(Guid id);
        Task<Teacher> UpdateTeacher(Guid id, TeacherReqDto teacherRequest);
        Task<List<Timetable>> GetTimetableByTeacherId(Guid teacherId);
        Task<Teacher> GetTeacherBySubjectId(Guid subjectId);
        Task<Teacher> DeleteTeacher(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<Teacher> GetTeacherByUserIdAsync(Guid userId);
    }
}
