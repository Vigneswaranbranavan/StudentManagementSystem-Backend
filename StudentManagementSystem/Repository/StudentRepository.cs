using Microsoft.EntityFrameworkCore;
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
            return await _appDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _appDbContext.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _appDbContext.Students.Update(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student != null)
            {
                _appDbContext.Students.Remove(student);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
