using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;

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
                    TeacherID = item.TeacherID,
                    ClassID = item.ClassID,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Class = new ClassResponse
                    {
                        ID =item.Class.ID,
                        ClassName = item.Class.ClassName
                       
                    },
                    TeacherSubject = new TeacherResponse
                    {
                        ID=item.Teacher.Subject.ID,
                        Name= item.Teacher.Subject.SubjectName
                    }

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


        public async Task<List<TimeTableResponse>> GetTimetablesByDate(DateTime date)
        {
            if (date == default)
                throw new ArgumentException("Invalid date specified.");

            var timetableData = await _timetableRepository.GetTimetablesByDate(date);

            if (!timetableData.Any())
                throw new KeyNotFoundException("No timetables found for the specified date.");

            return timetableData.Select(item => new TimeTableResponse
            {
                ID = item.ID,
                TeacherID = item.TeacherID,
                ClassID = item.ClassID,
                Date = item.Date,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Class = new ClassResponse
                {
                    ID = item.Class.ID,
                    ClassName = item.Class.ClassName
                },
                TeacherSubject = new TeacherResponse
                {
                    ID = item.Teacher.Subject.ID,
                    Name = item.Teacher.Subject.SubjectName
                }
            }).ToList();
        }


    }
}
