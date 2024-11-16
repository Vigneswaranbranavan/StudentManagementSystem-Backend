using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;
        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            await _appDbContext.Teachers.AddAsync(teacher);
            await _appDbContext.SaveChangesAsync();
            return teacher;
        }


        public async Task<List<Teacher>> GetTeachers()
        {
            var teacherData = await _appDbContext.Teachers.ToListAsync();
            return teacherData;

        }

        public async Task<Teacher> GetTeacherById(Guid id)
        {
            var teacherData = await _appDbContext.Teachers.FindAsync(id);
            if (teacherData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return teacherData;

        }

        public async Task<Teacher> UpdateTeacher(Guid id, TeacherRequest teacherRequest)
        {
            var teacherData = await _appDbContext.Teachers.FindAsync(id);
            if (teacherData == null)
            {
                throw new Exception("ID is Not Found");
            }

            teacherData.Name = teacherRequest.Name;
            teacherData.Email = teacherRequest.Email;
            teacherData.Phone = teacherRequest.Phone;
            teacherData.SubjectID = teacherRequest.SubjectID;

            _appDbContext.SaveChanges();
            return teacherData;
        }



        public async Task<List<Timetable>> GetTimetableByTeacherId(Guid teacherId)
        {
            var timetable = await _appDbContext.Timetables.Where(t => t.TeacherID == teacherId).Include(t => t.Subject).Include(t => t.Class).ToListAsync();
            return timetable;
        }


        public async Task<List<Teacher>> GetTeachersBySubjectId(Guid subjectId)
        {
            var teachers = await _appDbContext.Teachers.Where(t => t.SubjectID == subjectId).ToListAsync();
            return teachers;
        }

        public async Task<Teacher> DeleteTeacher(Guid id)
        {
            var teacherData = await _appDbContext.Teachers.FindAsync(id);
            if (teacherData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(teacherData);
            _appDbContext.SaveChanges();
            return teacherData;
        }


    }
}
