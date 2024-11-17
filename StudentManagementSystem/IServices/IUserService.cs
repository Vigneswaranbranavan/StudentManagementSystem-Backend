using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(Guid id);
        Task<UserResponse> AddUserAsync(UserRequest userRequest, string roleName);
        Task UpdateUserAsync(Guid id, UserRequest userRequest);
        Task DeleteUserAsync(Guid id);
    }
}

