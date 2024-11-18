using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherResponse> AddTeacher(TeacherRequest teacherRequest)
        {
            var teacher = new Teacher
            {
                ID = Guid.NewGuid(),
                Name = teacherRequest.Name,
                Email = teacherRequest.Email,
                Phone = teacherRequest.Phone,
                SubjectID = teacherRequest.SubjectID
            };


            var teacherData = await _teacherRepository.AddTeacher(teacher);

            var teacherResponse = new TeacherResponse
            {
                ID = teacherData.ID,
                Name = teacherData.Name,
                Email = teacherData.Email,
                Phone = teacherData.Phone,
                SubjectID = teacherData.SubjectID
            };

            return teacherResponse;
        }


        public async Task<List<TeacherResponse>> GetTeachers()
        {
            var teacherData = await _teacherRepository.GetTeachers();

            var teacherList = new List<TeacherResponse>();

            foreach (var item in teacherData)
            {
                var teacherResponse = new TeacherResponse();
                teacherResponse.ID = item.ID;
                teacherResponse.Name = item.Name;
                teacherResponse.Email = item.Email;
                teacherResponse.Phone = item.Phone;
                teacherResponse.SubjectID = item.SubjectID;

                teacherList.Add(teacherResponse);

            }
            return teacherList;
        }


        public async Task<TeacherResponse> GetTeacherById(Guid id)
        {
            var teacherData = await _teacherRepository.GetTeacherById(id);

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
            teacherResponse.Email = teacherData.Email;
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;

            return teacherResponse;
        }


        public async Task<TeacherResponse> UpdateTeacher(Guid id, TeacherRequest request)
        {
            var teacherData = await _teacherRepository.UpdateTeacher(id, request);

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
            teacherResponse.Email = teacherData.Email;
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;

            return teacherResponse;
        }

        public async Task<List<TimeTableResponse>> GetTimetableByTeacherId(Guid id)
        {

            var timetableData = await _teacherRepository.GetTimetableByTeacherId(id);

            var timetableResList = new List<TimeTableResponse>();

            foreach (var item in timetableData)
            {
                var timetableResponse = new TimeTableResponse();
                timetableResponse.ID = item.ID;
                timetableResponse.SubjectID = item.SubjectID;
                timetableResponse.TeacherID = item.TeacherID;
                timetableResponse.ClassID = item.ClassID;
                timetableResponse.Date = item.Date;
                timetableResponse.StartTime = item.StartTime;
                timetableResponse.EndTime = item.EndTime;
                timetableResponse.Room = item.Room;

                timetableResList.Add(timetableResponse);

            }
            return timetableResList;

        }



        public async Task<List<TeacherResponse>> GetTeachersBySubjectId(Guid subjectId)
        {
            var teacherData = await _teacherRepository.GetTeachersBySubjectId(subjectId);

            var teacherList = new List<TeacherResponse>();

            foreach (var item in teacherData)
            {
                var teacherResponse = new TeacherResponse();
                teacherResponse.ID = item.ID;
                teacherResponse.Name = item.Name;
                teacherResponse.Email = item.Email;
                teacherResponse.Phone = item.Phone;
                teacherResponse.SubjectID = item.SubjectID;

                teacherList.Add(teacherResponse);

            }
            return teacherList;
        }



        public async Task<TeacherResponse> DeleteTeacher(Guid id)
        {
            var teacherData = await _teacherRepository.DeleteTeacher(id);

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
            teacherResponse.Email = teacherData.Email;
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;

            return teacherResponse;
        }
    }
}


