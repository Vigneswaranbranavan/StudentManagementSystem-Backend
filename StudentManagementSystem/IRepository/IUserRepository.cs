using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task AddUserRoleAsync(UserRole userRole);
    }
}
