using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;


namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public StudentService(AppDbContext appDbContext, IStudentRepository studentRepository, IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _appDbContext = appDbContext;
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }


        public async Task<IEnumerable<StudentResponce>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            return students.Select(student => new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                gender = student.gender,
                IndexNumber = student.IndexNumber,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,
                Class = new ClassResponse
                {
                    ID = student.Class.ID,
                    ClassName = student.Class.ClassName
                },
                UserRes = new UserResponse
                {
                    ID = student.User.ID,
                    Email = student.User.Email
                }

            });
        }

        public async Task<StudentResponce> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            return new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                gender = student.gender,
                IndexNumber = student.IndexNumber,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,

            };
        }


        public async Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest)
        {
            var role = await _studentRepository.GetRoleByNameAsync("student");

            if (role == null)
                throw new InvalidOperationException("Role not found.");

            var user = new User
            {
                Email = studentRequest.UserReq.Email,
                Password = studentRequest.UserReq.Password, 
                UserRole = new UserRole
                {
                    RoleID = role.ID
                }
            };

            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _appDbContext.Users.Add(user);
                    await _appDbContext.SaveChangesAsync();

                    var student = new Student
                    {
                        Name = studentRequest.Name,
                        Phone = studentRequest.Phone,
                        gender = studentRequest.gender,
                        IndexNumber = studentRequest.IndexNumber,
                        EnrollmentDate = DateTime.Now,
                        ClassID = studentRequest.ClassID,
                        UserID = user.ID 
                    };

                    _appDbContext.Students.Add(student);
                    await _appDbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new StudentResponce
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Phone = student.Phone,
                        gender = student.gender,
                        IndexNumber = student.IndexNumber,
                        EnrollmentDate = student.EnrollmentDate,
                        ClassID = student.ClassID
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException("Error adding student and user.", ex);
                }
            }
        }



        public async Task<StudentResponce> UpdateStudentAsync(Guid id, StudentReqDto request)
        {
            var student = await _studentRepository.UpdateStudentAsync(id, request);

            return new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                gender = student.gender,
                IndexNumber = student.IndexNumber,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID
            };
        }



        public async Task<IEnumerable<StudentResponce>> GetStudentsByClassIdAsync(Guid classId)
        {
            var students = await _studentRepository.GetStudentsByClassIdAsync(classId);
            return students.Select(student => new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                gender = student.gender,
                IndexNumber = student.IndexNumber,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,
                Class = new ClassResponse
                {
                    ID = student.Class.ID,
                    ClassName = student.Class.ClassName
                },
                UserRes = new UserResponse
                {
                    ID = student.User.ID,
                    Email = student.User.Email
                }

            });
        }


        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            await _studentRepository.DeleteStudentAsync(id);
        }


        public async Task<StudentResponce> GetStudentByUserIdAsync(Guid userId)
        {
            var student = await _studentRepository.GetStudentByUserIdAsync(userId);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found for the provided UserID.");
            }

            return new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                gender = student.gender,
                IndexNumber = student.IndexNumber,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,
                Class = new ClassResponse
                {
                    ID = student.Class.ID,
                    ClassName = student.Class.ClassName 
                },
                UserRes = new UserResponse
                {
                    ID = student.User.ID,
                    Email = student.User.Email
                }
            };

        }
        //public async Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest)
        //{

        //    var role = await _studentRepository.GetRoleByNameAsync("student");

        //    if (role == null)
        //        throw new InvalidOperationException("Role not found.");


        //    // map user entity and relate to the userrole
        //    var user = new User {
        //        Email = studentRequest.UserRTeq.Email,
        //        Password = studentRequest.UserRTeq.Password,
        //        UserRole = new UserRole
        //        {
        //            RoleID = role.ID,
        //        }
        //    };

        //    // add in db
        //    var userEntity = await _userRepository.AddUserAsync(user);

        //    // map student entity
        //    var student = new Student
        //    {
        //        ID = userEntity.ID,
        //        Name = studentRequest.Name,
        //        Phone = studentRequest.Phone,
        //        EnrollmentDate = DateTime.Now,
        //        ClassID = studentRequest.ClassID,
        //    };

        //    // add in db
        //    await _studentRepository.AddStudentAsync(student);

        //    // Generate a JWT token
        //    var token = _tokenRepository.GenerateToken(user.Email,  "student");


        //    return new StudentResponce
        //    {
        //        ID = student.ID,
        //        Name = student.Name,
        //        Phone = student.Phone,
        //        EnrollmentDate = student.EnrollmentDate,
        //        ClassID = student.ClassID,
        //    };


        //}

    }
}
 