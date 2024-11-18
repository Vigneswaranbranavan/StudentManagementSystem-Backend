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

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<IEnumerable<StudentResponce>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            return students.Select(student => new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Email = student.Email,
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
                return null;
            }

            return new StudentResponce
            {
                ID = students.ID,
                Name = students.Name,
                Email = students.Email,
                Phone = students.Phone,
                EnrollmentDate = students.EnrollmentDate,
                ClassID = students.ClassID,
            };
        }

        public async Task<StudentResponce> AddStudentAsync(StudentRequest studentRequest)
        {
            var student = new Student
            {
                ID = Guid.NewGuid(),
                Name = studentRequest.Name,
                Email = studentRequest.Email,
                Phone = studentRequest.Phone,
                EnrollmentDate = studentRequest.EnrollmentDate,
                ClassID = studentRequest.ClassID,
            };
            await _studentRepository.AddStudentAsync(student);

            return new StudentResponce
            {
                ID = student.ID,
                Name = student.Name,
                Email = student.Email,
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
                throw new Exception("Student Not Found");
            }

            studentRequest.Name = student.Name;
            studentRequest.Email = student.Email;
            studentRequest.Phone = student.Phone;
            studentRequest.EnrollmentDate = student.EnrollmentDate;
            studentRequest.ClassID = student.ClassID;

            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
