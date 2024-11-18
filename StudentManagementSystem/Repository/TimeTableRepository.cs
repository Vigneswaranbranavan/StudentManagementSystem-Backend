using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Repository
{
    public class TimeTableRepository : ITimeTableRepository
    {

        private readonly AppDbContext _appDbContext;
        public TimeTableRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Timetable> AddTImetable(Timetable timetable)
        {
            await _appDbContext.Timetables.AddAsync(timetable);
            await _appDbContext.SaveChangesAsync();
            return timetable;
        }


        public async Task<List<Timetable>> GetTimetable()
        {
            var TimetableData = await _appDbContext.Timetables.ToListAsync();
            return TimetableData;

        }

        public async Task<Timetable> GetTimetableById(Guid id)
        {
            var TimetableData = await _appDbContext.Timetables.FindAsync(id);
            if (TimetableData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return TimetableData;

        }




        public async Task<Timetable> UpdateTimetable(Guid id, TimeTableRequest timeTableRequest)
        {
            var timetableData = await _appDbContext.Timetables.FindAsync(id);
            if (timetableData == null)
            {
                throw new Exception("ID is Not Found");
            }


            timetableData.SubjectID = timeTableRequest.SubjectID;
            timetableData.TeacherID = timeTableRequest.TeacherID;
            timetableData.ClassID = timeTableRequest.ClassID;
            timetableData.Date = timeTableRequest.Date;
            timetableData.StartTime = timeTableRequest.StartTime;
            timetableData.EndTime = timeTableRequest.EndTime;
            timetableData.Room = timeTableRequest.Room;

            _appDbContext.SaveChanges();
            return timetableData;
        }


        public async Task<Timetable> DeleteTimetable(Guid id)
        {
            var timetableData = await _appDbContext.Timetables.FindAsync(id);
            if (timetableData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(timetableData);
            _appDbContext.SaveChanges();
            return timetableData;
        }


        public async Task<List<Timetable>> GetTimetablesByTeacherId(Guid teacherId)
        {
            var timetableData = await _appDbContext.Timetables.Where(t => t.TeacherID == teacherId).ToListAsync();
            if (timetableData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return timetableData;
        }

        public async Task<List<Timetable>> GetTimetablesByClassId(Guid classId)
        {
            var timetableData = await _appDbContext.Timetables.Where(tt => tt.ClassID == classId).ToListAsync();
            if (timetableData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return timetableData;
        }


        public async Task<List<Timetable>> GetTimetablesBySubjectId(Guid subjectId)
        {
            var timetableData = await _appDbContext.Timetables.Where(tt => tt.SubjectID == subjectId).ToListAsync();
            if (timetableData == null)
            {
                throw new Exception("ID is Not Found");
            }
            return timetableData;
        }
    }
}
