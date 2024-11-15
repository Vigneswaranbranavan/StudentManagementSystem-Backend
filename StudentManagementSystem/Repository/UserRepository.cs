using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await appDbContext.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                appDbContext.Users.Remove(user);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await appDbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await appDbContext.UserRoles.AddAsync(userRole);
            await appDbContext.SaveChangesAsync();
        }

    }
}

