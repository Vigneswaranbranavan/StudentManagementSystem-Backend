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

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
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
            
            var role = await _userRepository.GetRoleByNameAsync("student");

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

            studentRequest.Name = student.Name;
            studentRequest.Phone = student.Phone;
            studentRequest.ClassID = student.ClassID;

            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            await _studentRepository.DeleteStudentAsync(id);
        }

        public async Task<UserResponse> AssignRoleToUserAsync(UserRequest userRequest, string roleName)
        {
            var role = await _userRepository.GetRoleByNameAsync(roleName);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            var user = new User
            {
                ID = Guid.NewGuid(),
                Email = userRequest.Email,
                Password = userRequest.Password,
            };

            await _userRepository.AddUserAsync(user);

            var userRole = new UserRole
            {
                UserID = user.ID,
                RoleID = role.ID,
            };

            await _userRepository.AddUserRoleAsync(userRole);

            return new UserResponse
            {
                ID = user.ID,
                Email = user.Email,
            };
        }
    }
}
