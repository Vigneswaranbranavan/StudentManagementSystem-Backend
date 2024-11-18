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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(x => new UserResponse
            {
                ID = x.ID,
                Email = x.Email,
                Password = x.Password,
            });
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid id)
        {
            var users = await _userRepository.GetUserByIdAsync(id);
            if (users == null)
            {
                throw new Exception("User not found");
            }
            return new UserResponse
            {
                ID = users.ID,
                Email = users.Email,
                Password = users.Password,
            };
        }

        public async Task<UserResponse> AddUserAsync(UserRequest userRequest, string roleName)
        {
            //Retrieve Role by Name:
            var role = await _userRepository.GetRoleByNameAsync(roleName);
            if (role == null) throw new Exception("Role not found");

            //Create User Entity:
            var user = new User
            {
               ID = Guid.NewGuid(),
               Email = userRequest.Email,
               Password = userRequest.Password,
            };

            //Add User to Repository:
            await _userRepository.AddUserAsync(user);

            //Create UserRole Entity:
            var userRole = new UserRole
            {
                UserID = user.ID,
                RoleID = role.ID,
            };

            //Add UserRole to Repository:
            await _userRepository.AddUserRoleAsync(userRole);

            //Return User Response:
            return new UserResponse
            {
                ID = user.ID,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public async Task UpdateUserAsync(Guid id,UserRequest userRequest)
        {
           var users = await _userRepository.GetUserByIdAsync(id);
            if (users == null)
            {
                throw new Exception("User not Found");
            }
            users.Email = userRequest.Email;
            users.Password = userRequest.Password;

            await _userRepository.UpdateUserAsync(users);
        }

        public async Task DeleteUserAsync(Guid id)
        {
           var users = await _userRepository.GetUserByIdAsync(id);
            if(users == null)
            {
                throw new Exception("User not found");
            }
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
