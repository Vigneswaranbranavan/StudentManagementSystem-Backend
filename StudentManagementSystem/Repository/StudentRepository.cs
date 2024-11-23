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
            return await _appDbContext.Students
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {

            var existingStudents = await _appDbContext.Students.FindAsync(student.ID);
            if (existingStudents != null)
            {
                existingStudents.Name = student.Name;
                existingStudents.Phone = student.Phone;
                existingStudents.EnrollmentDate = student.EnrollmentDate;
                existingStudents.ClassID = student.ClassID;

                await _appDbContext.SaveChangesAsync();

            }

            else
            {
                throw new KeyNotFoundException("Student not found");
            }
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
                .FirstOrDefaultAsync(r => r.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
