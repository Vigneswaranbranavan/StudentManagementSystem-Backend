using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Services
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ITimeTableRepository _timetableRepository;

        public TimeTableService(ITimeTableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }

        public async Task<TimeTableResponse> AddTImetable(TimeTableRequest timeTableRequest)
        {
            var timetable = new Timetable
            {
                ID = Guid.NewGuid(),
                SubjectID = timeTableRequest.SubjectID,
                TeacherID = timeTableRequest.TeacherID,
                ClassID = timeTableRequest.ClassID,
                Date = timeTableRequest.Date,
                StartTime = timeTableRequest.StartTime,
                EndTime = timeTableRequest.EndTime
            };


            var timetableData = await _timetableRepository.AddTImetable(timetable);

            var timetableResponse = new TimeTableResponse
            {
                ID = timetableData.ID,
                SubjectID = timetableData.SubjectID,
                TeacherID = timetableData.TeacherID,
                ClassID = timetableData.ClassID,
                Date = timetableData.Date,
                StartTime = timetableData.StartTime,
                EndTime = timetableData.EndTime

            };

            return timetableResponse;
        }



        public async Task<List<TimeTableResponse>> GetTimetable()
        {
            var timetableData = await _timetableRepository.GetTimetable();

            var timetableList = new List<TimeTableResponse>();

            foreach (var item in timetableData)
            {
                var timetableResponse = new TimeTableResponse
                {
                    ID = item.ID,
                    SubjectID = item.SubjectID,
                    TeacherID = item.TeacherID,
                    ClassID = item.ClassID,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,

                };

                timetableList.Add(timetableResponse);

            }
            return timetableList;
        }


        public async Task<TimeTableResponse> GetTimetableById(Guid id)
        {
            var timetableData = await _timetableRepository.GetTimetableById(id);

            var timetableResponse = new TimeTableResponse
            {
                ID = timetableData.ID,
                SubjectID = timetableData.SubjectID,
                TeacherID = timetableData.TeacherID,
                ClassID = timetableData.ClassID,
                Date = timetableData.Date,
                StartTime = timetableData.StartTime,
                EndTime = timetableData.EndTime,

            };

            return timetableResponse;
        }


        public async Task<TimeTableResponse> UpdateTimetable(Guid id, TimeTableRequest request)
        {
            var timetableData = await _timetableRepository.UpdateTimetable(id, request);

            var timetableResponse = new TimeTableResponse
            {
                ID = timetableData.ID,
                SubjectID = timetableData.SubjectID,
                TeacherID = timetableData.TeacherID,
                ClassID = timetableData.ClassID,
                Date = timetableData.Date,
                StartTime = timetableData.StartTime,
                EndTime = timetableData.EndTime,

            };

            return timetableResponse;
        }

        public async Task<TimeTableResponse> DeleteTimetable(Guid id)
        {
            var timetableData = await _timetableRepository.DeleteTimetable(id);


            var timetableResponse = new TimeTableResponse
            {
                ID = timetableData.ID,
                SubjectID = timetableData.SubjectID,
                TeacherID = timetableData.TeacherID,
                ClassID = timetableData.ClassID,
                Date = timetableData.Date,
                StartTime = timetableData.StartTime,
                EndTime = timetableData.EndTime,

            };

            return timetableResponse;
        }


        public async Task<List<TimeTableResponse>> GetTimetablesByTeacherId(Guid teacherId)
        {

            var timetableData = await _timetableRepository.GetTimetablesByTeacherId(teacherId);

            var timetableList = new List<TimeTableResponse>();

            foreach (var item in timetableData)
            {
                var timetableResponse = new TimeTableResponse
                {
                    ID = item.ID,
                    SubjectID = item.SubjectID,
                    TeacherID = item.TeacherID,
                    ClassID = item.ClassID,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,

                };

                timetableList.Add(timetableResponse);

            }
            return timetableList;
          
        }



        public async Task<List<TimeTableResponse>> GetTimetablesByClassId(Guid classId)
        {

            var timetableData = await _timetableRepository.GetTimetablesByClassId(classId);

            var timetableList = new List<TimeTableResponse>();

            foreach (var item in timetableData)
            {
                var timetableResponse = new TimeTableResponse
                {
                    ID = item.ID,
                    SubjectID = item.SubjectID,
                    TeacherID = item.TeacherID,
                    ClassID = item.ClassID,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,

                };

                timetableList.Add(timetableResponse);

            }
            return timetableList;
            
        }



        public async Task<List<TimeTableResponse>> GetTimetablesBySubjectId(Guid subjectId)
        {

            var timetableData = await _timetableRepository.GetTimetablesBySubjectId(subjectId);

            var timetableList = new List<TimeTableResponse>();

            foreach (var item in timetableData)
            {
                var timetableResponse = new TimeTableResponse
                {
                    ID = item.ID,
                    SubjectID = item.SubjectID,
                    TeacherID = item.TeacherID,
                    ClassID = item.ClassID,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,

                };

                timetableList.Add(timetableResponse);

            }
            return timetableList;

        }
    }
}
