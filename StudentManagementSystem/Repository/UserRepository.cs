using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var entity = await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _appDbContext.Users.FindAsync(user.ID);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("User not Found");
            }
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _appDbContext.Roles
                .FirstOrDefaultAsync(r => r.RoleName == roleName);
            //.FirstOrDefaultAsync(r => r.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await _appDbContext.UserRoles.AddAsync(userRole);
            await _appDbContext.SaveChangesAsync();
        }

    }
}

