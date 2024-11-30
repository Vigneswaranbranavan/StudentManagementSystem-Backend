using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;

namespace StudentManagementSystem.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _appDbContext;
        public StaffRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Staff> AddStaff(Staff Staff)
        {
            await _appDbContext.Staff.AddAsync(Staff);
            await _appDbContext.SaveChangesAsync();
            return Staff;
        }


        public async Task<IEnumerable<Staff>> GetStaffs()
        {
            var StaffData = await _appDbContext.Staff.Include(i => i.User).ToListAsync();
            return StaffData;

        }

        public async Task<Staff> GetStaffById(Guid id)
        {
            var StaffData = await _appDbContext.Staff.FindAsync(id);
            if (StaffData == null)
            {
                throw new Exception("ID is Not Found");
            }

            return StaffData;

        }

        public async Task<Staff> UpdateStaff(Guid id, StaffReqDto request)
        {
            var StaffData = await _appDbContext.Staff.FindAsync(id);
            if (StaffData == null)
            {
                throw new Exception("ID is Not Found");
            }

            StaffData.Name = request.Name;
            StaffData.Phone = request.Phone;


            _appDbContext.SaveChanges();
            return StaffData;
        }

        public async Task<Staff> DeleteStaff(Guid id)
        {
            var StaffData = await _appDbContext.Staff.FindAsync(id);
            if (StaffData == null)
            {
                throw new Exception("ID is Not Found");
            }

            _appDbContext.Remove(StaffData);
            _appDbContext.SaveChanges();
            return StaffData;
        }
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _appDbContext.Roles
                .FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());
        }
    }
}
