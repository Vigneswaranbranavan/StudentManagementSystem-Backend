using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _appDbContext;
        public AttendanceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Attendance> AddAttendance(Attendance attendance)
        {
            await _appDbContext.Attendances.AddAsync(attendance);
            await _appDbContext.SaveChangesAsync();
            return attendance;
        }


        public async Task<List<Attendance>> GetAttendance()
        {
            var attendanceData = await _appDbContext.Attendances.ToListAsync();
            return attendanceData;

        }

        public async Task<Attendance> GetAttendanceById(Guid id)
        {
            var attendanceData = await _appDbContext.Attendances.FindAsync(id);
            if (attendanceData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return attendanceData;

        }

        public async Task<Attendance> UpdateAttendance(Guid id, AttendanceRequest request)
        {
            var attendanceData = await _appDbContext.Attendances.FindAsync(id);
            if (attendanceData == null)
            {
                throw new Exception("ID is Not Found");
            }

            attendanceData.StudentID = request.StudentID;
            attendanceData.Date = request.Date;
            attendanceData.Status = request.Status;


            _appDbContext.SaveChanges();
            return attendanceData;
        }

        public async Task<Attendance> DeleteAttendance(Guid id)
        {
            var attendanceData = await _appDbContext.Attendances.FindAsync(id);
            if (attendanceData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(attendanceData);
            _appDbContext.SaveChanges();
            return attendanceData;
        }


        public async Task<List<Attendance>> GetAttendanceByStudentId(Guid studentId)
        {
            var attendanceData = await _appDbContext.Attendances.Where(a => a.StudentID == studentId).ToListAsync();
            if (attendanceData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return attendanceData;
        }

        public async Task<List<Attendance>> GetAttendanceByClassId(Guid classId)
        {
            var attendanceData = await _appDbContext.Attendances.Include(i=>i.Student).Where(a => a.Student.ClassID == classId).ToListAsync();
            if (attendanceData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return attendanceData;
        }

        // Retrieve all attendance records for a specific date
        public async Task<List<Attendance>> GetAttendanceByDate(DateTime date)
        {
            var attendanceData = await _appDbContext.Attendances.Where(a => a.Date.Date == date.Date).ToListAsync();
            if (attendanceData == null)
            {
                throw new Exception("Date is Not Found");
            }
            return attendanceData;
        }
    }
}
