using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using System.Net.NetworkInformation;

namespace StudentManagementSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public UserService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }


        public async Task<(string Token, User user)> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            var role = user.UserRole?.Role?.RoleName ?? throw new Exception("User role not found");

            var token = _tokenRepository.GenerateToken(user);  

            return (token, user);
        }


    }
}
