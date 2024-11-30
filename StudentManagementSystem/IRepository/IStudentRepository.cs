using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(Guid id);   
        Task<List<Student>> GetStudentsByClassIdAsync(Guid classId);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Guid id, StudentReqDto request);
        Task DeleteStudentAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);

    }
}
