using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponce>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentRepository>> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpGet("class/{classId}")]

        public async Task<ActionResult<IEnumerable<StudentResponce>>> GetStudentsByClassId(Guid classId)
        {
            var students = await _studentService.GetStudentsByClassIdAsync(classId);
            return Ok(students);
        }
        //public async Task<IActionResult> GetStudentsByClassId(Guid classId)
        //{
        //    var students = await _studentService.GetStudentsByClassIdAsync(classId);

        //    if (students == null || students.Count == 0)
        //    {
        //        return NotFound(new { message = "No students found for the specified class." });
        //    }

        //    return Ok(students);
        //}

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentRequest studentRequest)
        {
            var createStudent = await _studentService.AddStudentAsync(studentRequest);
            return CreatedAtAction(nameof(GetStudentById), new { id = createStudent.ID }, createStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentReqDto studentRequest)
        {
           var data= await _studentService.UpdateStudentAsync(id, studentRequest);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<StudentResponce>> GetStudentByUserId(Guid userId)
        {
            try
            {
                var student = await _studentService.GetStudentByUserIdAsync(userId);
                return Ok(student);  // The response now includes the Class details
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Student not found for the provided UserID." });
            }
        }

    }
}
