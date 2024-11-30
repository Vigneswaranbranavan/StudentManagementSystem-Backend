using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Repository;


namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public StudentService(AppDbContext appDbContext, IStudentRepository studentRepository, IUserRepository userRepository,ITokenRepository tokenRepository)
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
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,
                
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



        public async Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest)
        {
            var role = await _studentRepository.GetRoleByNameAsync("student");

            if (role == null)
                throw new InvalidOperationException("Role not found.");

            // Map the User entity (no password hashing)
            var user = new User
            {
                Email = studentRequest.UserReq.Email,
                Password = studentRequest.UserReq.Password, // Directly using the provided password
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
                    var student = new Student
                    {
                        Name = studentRequest.Name,
                        Phone = studentRequest.Phone,
                        EnrollmentDate = DateTime.Now,
                        ClassID = studentRequest.ClassID,
                        UserID = user.ID // Link the student to the user via the UserID
                    };

                    // Insert the student
                    _appDbContext.Students.Add(student);
                    await _appDbContext.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    // Return the student response
                    return new StudentResponce
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Phone = student.Phone,
                        EnrollmentDate = student.EnrollmentDate,
                        ClassID = student.ClassID
                    };
                }
                catch (Exception ex)
                {
                    // Rollback if an error occurs
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException("Error adding student and user.", ex);
                }
            }
        }



        public async Task<StudentResponce> UpdateStudentAsync(Guid id, StudentReqDto request)
        {
            var studentData = await _studentRepository.UpdateStudentAsync(id, request);

            var studentResponse = new StudentResponce();
            studentResponse.ID = studentData.ID;
            studentResponse.Name = studentData.Name;
            studentResponse.Phone = studentData.Phone;
            studentResponse.ClassID = studentData.ClassID;

            return studentResponse;
        }



        public async Task<List<Student>> GetStudentsByClassIdAsync(Guid classId)
        {
            return await _studentRepository.GetStudentsByClassIdAsync(classId);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            await _studentRepository.DeleteStudentAsync(id);
        }


    }
}
