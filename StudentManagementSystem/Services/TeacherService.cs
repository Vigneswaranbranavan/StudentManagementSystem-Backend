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
        private readonly AppDbContext _appDbContext;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public TeacherService(AppDbContext appDbContext, ITeacherRepository teacherRepository, IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _appDbContext = appDbContext;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        //public async Task<TeacherResponse> AddTeacher(TeacherRequest teacherRequest)
        //{
        //    var role = await _teacherRepository.GetRoleByNameAsync("teacher");
        //    if (role == null)
        //    {
        //        throw new InvalidOperationException("Role not Found");
        //    }

        //    var user = new User
        //    {
        //        Email = teacherRequest.Email,
        //        Password = teacherRequest.Password,
        //        UserRole = new UserRole

        //        {
        //            RoleID = role.ID,
        //        }
        //    };
        //    var userEntity = await _userRepository.AddUserAsync(user);

        //    var teacher = new Teacher
        //    {
        //        ID = userEntity.ID,
        //        Name = teacherRequest.Name,
        //        Phone = teacherRequest.Phone,
        //        SubjectID = teacherRequest.SubjectID,
        //    };
        //    await _teacherRepository.AddTeacher(teacher);

        //    var token = _tokenRepository.GenerateToken(user.Email, "teacher");


        //    return new TeacherResponse
        //    {
        //        ID = teacher.ID,
        //        Name = teacher.Name,
        //        Phone = teacher.Phone,
        //        SubjectID = teacher.SubjectID,
        //    };

        //}




        public async Task<TeacherResponse> AddTeacherAsync(TeacherRequest request)
        {
            var role = await _teacherRepository.GetRoleByNameAsync("teacher");

            if (role == null)
                throw new InvalidOperationException("Role not found.");

            // Map the User entity (no password hashing)
            var user = new User
            {
                Email = request.UserReq.Email,
                Password = request.UserReq.Password, // Directly using the provided password
                UserRole = new UserRole
                {
                    RoleID = role.ID
                }
            };

            // Start transaction to insert user and student together
            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Insert the user first
                    _appDbContext.Users.Add(user);
                    await _appDbContext.SaveChangesAsync();

                    // Create the student entity, linking to the user by user ID
                    var teacher = new Teacher
                    {
                        Name = request.Name,
                        Phone = request.Phone,
                        SubjectID = request.SubjectID,
                        UserID = user.ID // Link the student to the user via the UserID
                    };

                    // Insert the student
                    _appDbContext.Teachers.Add(teacher);
                    await _appDbContext.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    // Return the student response
                    return new TeacherResponse
                    {
                        ID = teacher.ID,
                        Name = teacher.Name,
                        Phone = teacher.Phone,
                        SubjectID = teacher.SubjectID
                    };
                }
                catch (Exception ex)
                {
                    // Rollback if an error occurs
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException("Error adding Teacher and user.", ex);
                }
            }
        }


        public async Task<IEnumerable<TeacherResponse>> GetTeachers()
        {
            var teacherData = await _teacherRepository.GetTeachers();

            var teacherList = new List<TeacherResponse>();

            foreach (var item in teacherData)
            {
                var teacherResponse = new TeacherResponse();
                teacherResponse.ID = item.ID;
                teacherResponse.Name = item.Name;
                teacherResponse.Phone = item.Phone;
                teacherResponse.SubjectID = item.SubjectID;
                teacherResponse.Subject = new SubjectResponse
                {
                    ID = item.Subject.ID,
                    SubjectName = item.Subject.SubjectName
                };
                teacherResponse.UserRes = new UserResponse
                {
                    ID = item.User.ID,
                    Email = item.User.Email
                };

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
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;
            teacherResponse.Subject = new SubjectResponse
            {
                ID = teacherData.Subject.ID,
                SubjectName = teacherData.Subject.SubjectName
            };

            return teacherResponse;
        }


        public async Task<TeacherResponse> UpdateTeacher(Guid id, TeacherReqDto request)
        {
            var teacherData = await _teacherRepository.UpdateTeacher(id, request);

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
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
                timetableResponse.TeacherID = item.TeacherID;
                timetableResponse.ClassID = item.ClassID;
                timetableResponse.Date = item.Date;
                timetableResponse.StartTime = item.StartTime;
                timetableResponse.EndTime = item.EndTime;

                timetableResList.Add(timetableResponse);

            }
            return timetableResList;

        }



        public async Task<TeacherResponse> GetTeacherBySubjectId(Guid subjectId)
        {
            var teacherData = await _teacherRepository.GetTeacherBySubjectId(subjectId);

            

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;


            return teacherResponse;
        }



        public async Task<TeacherResponse> DeleteTeacher(Guid id)
        {
            var teacherData = await _teacherRepository.DeleteTeacher(id);

            var teacherResponse = new TeacherResponse();
            teacherResponse.ID = teacherData.ID;
            teacherResponse.Name = teacherData.Name;
            teacherResponse.Phone = teacherData.Phone;
            teacherResponse.SubjectID = teacherData.SubjectID;

            return teacherResponse;
        }
    }
}


