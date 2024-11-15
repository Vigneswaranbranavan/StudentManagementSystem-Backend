using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(Guid id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject(Subject subject)
        {
            await _subjectService.AddSubjectAsync(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.ID }, subject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(Guid id, Subject subject)
        {
            if (id != subject.ID)
                return BadRequest("Subject ID did't match.");

            await _subjectService.UpdateSubjectAsync(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(Guid id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return NoContent();
        }
    }
}
