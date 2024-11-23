using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(Guid id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);

    }
}
