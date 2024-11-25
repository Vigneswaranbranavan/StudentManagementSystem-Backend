using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
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

        public async Task<IEnumerable<SubjectResponse>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return subjects.Select(x => new SubjectResponse
            {
                ID = x.ID,
                SubjectName = x.SubjectName,
            });
        }

        public async Task<SubjectResponse> GetSubjectByIdAsync(Guid id)
        {
            var subjects =  await _subjectRepository.GetByIdAsync(id);
            if (subjects == null)
            {
                throw new Exception("Subject not Found");
            }
            return new SubjectResponse
            {
                ID = subjects.ID,
                SubjectName = subjects.SubjectName,
            };
        }

        public async Task<SubjectResponse> AddSubjectAsync(SubjectRequest subjectRequest)
        {
            var subject = new Subject
            {
                ID = Guid.NewGuid(),
                SubjectName = subjectRequest.SubjectName,

            };

            await _subjectRepository.AddAsync(subject);

            return new SubjectResponse
            {
                ID = subject.ID,
                SubjectName = subject.SubjectName,
            };
        }

        public async Task UpdateSubjectAsync(Guid id,SubjectRequest subjectRequest)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                throw new Exception("Subject not Found");
            }
            subject.SubjectName = subjectRequest.SubjectName;

            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(Guid id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                throw new Exception("Subject not Found");
            }

            await _subjectRepository.DeleteAsync(id);
        }
    }
}
