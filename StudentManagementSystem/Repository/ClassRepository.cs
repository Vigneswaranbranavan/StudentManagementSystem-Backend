using Microsoft.EntityFrameworkCore;
using StudentManagementSystem;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Class> AddClass(Class @class)
        {
            await _appDbContext.Classes.AddAsync(@class);
            await _appDbContext.SaveChangesAsync();
            return @class;
        }

        public async Task<List<Class>> GetClasses()
        {
            var classData = await _appDbContext.Classes.ToListAsync();
            return classData;

        }

        public async Task<Class> GetClassById(Guid id)
        {
            var classData = await _appDbContext.Classes.FindAsync(id);
            if (classData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return classData;

        }


        public async Task<Class> UpdateClass(Guid id, ClassRequest classRequest)
        {
            var classData = await _appDbContext.Classes.FindAsync(id);
            if (classData == null)
            {
                throw new Exception("ID is Not Found");
            }

            classData.ClassName = classRequest.ClassName;
            classData.GradeLevel = classRequest.GradeLevel;

            _appDbContext.SaveChanges();
            return classData;
        }

        public async Task<Class> DeleteClass(Guid id)
        {
            var classData = await _appDbContext.Classes.FindAsync(id);
            if (classData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(classData);
            _appDbContext.SaveChanges();
            return classData;
        }

        public async Task<List<Student>> GetStudentsByClassId(Guid classId)
        {
            var classData = await _appDbContext.Students.Where(s => s.ClassID == classId).ToListAsync();
            if (classData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return classData;
        }

        public async Task<List<Timetable>> GetTimetablesByClassId(Guid classId)
        {
            var classData = await _appDbContext.Timetables.Where(t => t.ClassID == classId).ToListAsync();
            if (classData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return classData;
        }



    }
}


