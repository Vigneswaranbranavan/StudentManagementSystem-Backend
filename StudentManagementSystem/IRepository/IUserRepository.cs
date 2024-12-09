using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        //Task<Role> GetRoleByNameAsync(string roleName);
        //Task AddUserRoleAsync(UserRole userRole);
        //Task<User> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByEmailForgotPassword(string email);
        Task<OTP> SaveOTP(OTP oTP);


    }
}
