using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user, string roleName)
        {
            var role = await _userRepository.GetRoleByNameAsync(roleName);
            if (role == null) throw new Exception("Role not found");

            await _userRepository.AddUserAsync(user);

            var userRole = new UserRole
            {
                UserID = user.ID,
                RoleID = role.ID
            };

            await _userRepository.AddUserRoleAsync(userRole);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
