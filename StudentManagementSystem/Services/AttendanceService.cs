using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<AttendanceResponse> AddAttendance(AttendanceRequest request)
        {
            var attendance = new Attendance
            {
                ID = Guid.NewGuid(),
                StudentID = request.StudentID,
                Date = request.Date,
                Status = request.Status
            };


            var attendanceData = await _attendanceRepository.AddAttendance(attendance);

            var attendanceResponse = new AttendanceResponse
            {
                ID = attendanceData.ID,
                StudentID = attendanceData.StudentID,
                Date = attendanceData.Date,
                Status = attendanceData.Status
            };

            return attendanceResponse;
        }


        public async Task<List<AttendanceResponse>> GetAttendance()
        {
            var attendanceData = await _attendanceRepository.GetAttendance();

            Console.WriteLine($"Attendance records fetched: {attendanceData.Count} records.");

            var attendanceList = new List<AttendanceResponse>();

            foreach (var item in attendanceData)
            {
                var attendanceResponse = new AttendanceResponse
                {
                    ID = item.ID,
                    StudentID = item.StudentID,
                    Date = item.Date,
                    Status = item.Status
                };

                attendanceList.Add(attendanceResponse);
            }
            return attendanceList;
        }



        public async Task<AttendanceResponse> GetAttendanceById(Guid id)
        {
            var attendanceData = await _attendanceRepository.GetAttendanceById(id);

            var attendanceResponse = new AttendanceResponse
            {
                ID = attendanceData.ID,
                StudentID = attendanceData.StudentID,
                Date = attendanceData.Date,
                Status = attendanceData.Status
            };

            return attendanceResponse;
        }


        public async Task<AttendanceResponse> UpdateAttendance(Guid id, AttendanceRequest request)
        {
            var attendanceData = await _attendanceRepository.UpdateAttendance(id, request);

            var attendanceResponse = new AttendanceResponse
            {
                ID = attendanceData.ID,
                StudentID = attendanceData.StudentID,
                Date = attendanceData.Date,
                Status = attendanceData.Status
            };

            return attendanceResponse;
        }


        public async Task<AttendanceResponse> DeleteAttendance(Guid id)
        {
            var attendanceData = await _attendanceRepository.DeleteAttendance(id);

            var attendanceResponse = new AttendanceResponse
            {
                ID = attendanceData.ID,
                StudentID = attendanceData.StudentID,
                Date = attendanceData.Date,
                Status = attendanceData.Status
            };

            return attendanceResponse;
        }

        public async Task<List<AttendanceResponse>> GetTimetablesByStudentId(Guid studentId)
        {

            var attendanceData = await _attendanceRepository.GetAttendanceByStudentId(studentId);

            var attendanceList = new List<AttendanceResponse>();

            foreach (var item in attendanceData)
            {
                var attendanceResponse = new AttendanceResponse
                {
                    ID = item.ID,
                    StudentID = item.StudentID,
                    Date = item.Date,
                    Status = item.Status
                };

                attendanceList.Add(attendanceResponse);

            }
            return attendanceList;

        }

        public async Task<List<AttendanceResponse>> GetAttendanceByClassId(Guid classId)
        {

            var attendanceData = await _attendanceRepository.GetAttendanceByClassId(classId);

            var attendanceList = new List<AttendanceResponse>();

            foreach (var item in attendanceData)
            {
                var attendanceResponse = new AttendanceResponse
                {
                    ID = item.ID,
                    StudentID = item.StudentID,
                    Date = item.Date,
                    Status = item.Status
                };

                attendanceList.Add(attendanceResponse);

            }
            return attendanceList;

        }

        public async Task<List<AttendanceResponse>> GetAttendanceByDate(DateTime date)
        {

            var attendanceData = await _attendanceRepository.GetAttendanceByDate(date);

            var attendanceList = new List<AttendanceResponse>();

            foreach (var item in attendanceData)
            {
                var attendanceResponse = new AttendanceResponse
                {
                    ID = item.ID,
                    StudentID = item.StudentID,
                    Date = item.Date,
                    Status = item.Status
                };

                attendanceList.Add(attendanceResponse);

            }
            return attendanceList;

        }
    }
}
