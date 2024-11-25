using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.DTO.Request;


namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository,ITokenRepository tokenRepository)
        {
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
                

            });
        }

        public async Task<StudentResponce> GetStudentByIdAsync(Guid id)
        {
            var students = await _studentRepository.GetStudentByIdAsync(id);
            if (students == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            return new StudentResponce
            {
                ID = students.ID,
                Name = students.Name,
                Phone = students.Phone,
                EnrollmentDate = students.EnrollmentDate,
                ClassID = students.ClassID,
            };
        }

        public async Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest)
        {
            
            var role = await _studentRepository.GetRoleByNameAsync("student");

            if (role == null)
                throw new InvalidOperationException("Role not found.");


            // map user entity and relate to the userrole
            var user = new User {
                Email = studentRequest.Email,
                Password = studentRequest.Password,
                UserRole = new UserRole
                {
                    RoleID = role.ID,
                }
            };

            // add in db
            var userEntity = await _userRepository.AddUserAsync(user);

            // map student entity
            var student = new Student
            {
                ID = userEntity.ID,
                Name = studentRequest.Name,
                Phone = studentRequest.Phone,
                EnrollmentDate = DateTime.Now,
                ClassID = studentRequest.ClassID,
            };

            // add in db
            await _studentRepository.AddStudentAsync(student);

            // Generate a JWT token
            var token = _tokenRepository.GenerateToken(user.Email,  "student");


            return new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Phone = student.Phone,
                EnrollmentDate = student.EnrollmentDate,
                ClassID = student.ClassID,
            };

            
        }

        public async Task UpdateStudentAsync(Guid id, StudentRequest studentRequest)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            student.Name = studentRequest.Name;
            student.Phone = studentRequest.Phone;
            student.ClassID = studentRequest.ClassID;

            await _studentRepository.UpdateStudentAsync(student);
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
