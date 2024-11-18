using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using System.Diagnostics;

namespace StudentManagementSystem.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassResponse> AddClass(ClassRequest classRequest)
        {
            var classe = new Class
            {
                ID = Guid.NewGuid(),
                ClassName = classRequest.ClassName,
                GradeLevel = classRequest.GradeLevel

            };

            var classData = await _classRepository.AddClass(classe);

            var classResponse = new ClassResponse
            {
                ID = classData.ID,
                ClassName = classData.ClassName,
                GradeLevel = classData.GradeLevel
            };

            return classResponse;
        }


        public async Task<List<ClassResponse>> GetClasses()
        {
            var classData = await _classRepository.GetClasses();

            var classList = new List<ClassResponse>();

            foreach (var item in classData)
            {
                var classResponse = new ClassResponse
                {
                    ID = item.ID,
                    ClassName = item.ClassName,
                    GradeLevel = item.GradeLevel
                };

                classList.Add(classResponse);

            }
            return classList;
        }


        public async Task<ClassResponse> GetClassById(Guid id)
        {
            var classData = await _classRepository.GetClassById(id);

            var classResponse = new ClassResponse
            {
                ID = classData.ID,
                ClassName = classData.ClassName,
                GradeLevel = classData.GradeLevel
            };

            return classResponse;
        }

        public async Task<ClassResponse> UpdateClass(Guid id, ClassRequest request)
        {
            var classData = await _classRepository.UpdateClass(id, request);

            var classResponse = new ClassResponse
            {
                ID = classData.ID,
                ClassName = classData.ClassName,
                GradeLevel = classData.GradeLevel
            };

            return classResponse;
        }

        public async Task<ClassResponse> DeleteClass(Guid id)
        {
            var classData = await _classRepository.DeleteClass(id);

            var classResponse = new ClassResponse
            {
                ID = classData.ID,
                ClassName = classData.ClassName,
                GradeLevel = classData.GradeLevel
            };

            return classResponse;
        }

        public async Task<List<StudentResponce>> GetStudentsByClassId(Guid classId)
        {
            var classData = await _classRepository.GetStudentsByClassId(classId);

            var studentsResList = new List<StudentResponce>();

            foreach (var item in classData)
            {
                var student = new StudentResponce
                {
                    ID = item.ID,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    EnrollmentDate = item.EnrollmentDate,
                    ClassID = item.ClassID,
                };

                studentsResList.Add(student);

            }
            return studentsResList;

        }

        public async Task<List<TimeTableResponse>> GetTimetablesByClassId(Guid classId)
        {
            var timetableData = await _classRepository.GetTimetablesByClassId(classId);

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
    }
}
