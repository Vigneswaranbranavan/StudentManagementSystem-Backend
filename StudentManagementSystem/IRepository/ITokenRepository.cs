using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface ITokenRepository
    {
        string GenerateToken(string email, string role);
        //Task<Role> GetRoleAsync(string roleName);
        //Task<User> AddUserAsync(User user);
        //Task GetUserByEmailAsync(string email);
    }
}
