using StudentManagementSystem.DTO;
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

        //Task<UserResponse> AddUserAsync(UserRequest userRequest, string roleName);
        Task<(string Token, User user)> Authenticate(string email, string password);
        Task<bool> SentOTP(string email);
        Task<bool> CheckOTP(string otp);
        Task<bool> ChangePassword(ChangePasswordDTO dTO);

        //Task<User> GetUserByEmailAsync(string email);


        //User Authenticate(string email, string password);
        //Task<User> GetUserByEmailAsync(string email,string password);
    }
}

