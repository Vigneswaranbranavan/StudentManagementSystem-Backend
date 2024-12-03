using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _appDbContext.Students.Include(i=>i.Class).Include(i => i.User).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _appDbContext.Students
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<Student>> GetStudentsByClassIdAsync(Guid classId)
        {
            return await _appDbContext.Students
                .Where(s => s.ClassID == classId)
                .Include(i => i.Class).Include(i => i.User).ToListAsync();
        }


        public async Task<Student> AddStudentAsync(Student student)

        {
            await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }


        public async Task<Student> UpdateStudentAsync(Guid id, StudentReqDto request)
        {
            var studentData = await _appDbContext.Students.FindAsync(id);
            if (studentData == null)
            {
                throw new Exception("ID is Not Found");
            }

            studentData.Name = request.Name;
            studentData.Phone = request.Phone;
            studentData.ClassID = request.ClassID;

            _appDbContext.SaveChanges();
            return studentData;
        }


        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student != null)
            {
                _appDbContext.Students.Remove(student);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("student not found");
            }
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _appDbContext.Roles
                .FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());
        }

        public async Task<Student> GetStudentByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Students
                .Include(s => s.Class)   // Include the Class entity
                .Include(s => s.User)    // Include the User entity
                .FirstOrDefaultAsync(s => s.UserID == userId);  // Query by UserID
        }

    }
}
