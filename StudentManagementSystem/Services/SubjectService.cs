using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Services
{
    public class SubjectService: ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(Guid id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(Guid id)
        {
            await _subjectRepository.DeleteAsync(id);
        }
    }
}
