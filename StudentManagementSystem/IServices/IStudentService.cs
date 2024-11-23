using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponce>> GetAllStudentsAsync();
        Task<StudentResponce> GetStudentByIdAsync(Guid id);
        Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest);
        Task UpdateStudentAsync(Guid id, StudentRequest studentRequest);
        Task DeleteStudentAsync(Guid id);
        Task<UserResponse> AssignRoleToUserAsync(UserRequest userRequest, string roleName);

    }
}
