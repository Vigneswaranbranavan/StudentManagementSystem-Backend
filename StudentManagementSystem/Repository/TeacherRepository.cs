using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using System.Xml;

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


        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var teacherData = await _appDbContext.Teachers.Include(i => i.Subject).Include(i => i.User).ToListAsync();
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

        public async Task<Teacher> UpdateTeacher(Guid id, TeacherReqDto teacherRequest)
        {
            var teacherData = await _appDbContext.Teachers.FindAsync(id);
            if (teacherData == null)
            {
                throw new Exception("ID is Not Found");
            }

            teacherData.Name = teacherRequest.Name;
            teacherData.Phone = teacherRequest.Phone;
            teacherData.SubjectID = teacherRequest.SubjectID;

            _appDbContext.SaveChanges();
            return teacherData;
        }



        public async Task<List<Timetable>> GetTimetableByTeacherId(Guid teacherId)
        {
            var timetable = await _appDbContext.Timetables.Include(t => t.Teacher).ThenInclude(i=>i.Subject).Include(t => t.Class).Where(t => t.TeacherID == teacherId).ToListAsync();
            if (timetable == null)
            {
                throw new Exception("ID is Not Found");
            }
            return timetable;
        }


        public async Task<Teacher> GetTeacherBySubjectId(Guid subjectId)
        {
            var teacher = await _appDbContext.Teachers.Include(t => t.Subject).FirstOrDefaultAsync(t => t.SubjectID == subjectId);
            if (teacher == null)
            {
                throw new Exception("ID is Not Found");
            }
            return teacher;
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

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _appDbContext.Roles
                .FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());
        }
    }
}
