using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class SubjectRepository: ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;
        public SubjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _appDbContext.Subjects
                .Include(s => s.Timetables) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Subjects
                .Include(s => s.Timetables)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task AddAsync(Subject subject)
        {
            await _appDbContext.Subjects.AddAsync(subject);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject subject)
        {
            _appDbContext.Subjects.Update(subject);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var subject = await _appDbContext.Subjects.FindAsync(id);
            if (subject != null)
            {
                _appDbContext.Subjects.Remove(subject);
                await _appDbContext.SaveChangesAsync();
            }
        }

    }
}
