using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                                 .Include(u => u.UserRole) 
                                 .ThenInclude(z => z.Role) 
                                 .SingleOrDefaultAsync(u => u.Email == email);
        }


    }
}

