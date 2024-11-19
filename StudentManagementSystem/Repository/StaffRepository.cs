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


        public async Task<List<Staff>> GetStaff()
        {
            var StaffData = await _appDbContext.Staff.ToListAsync();
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

        public async Task<Staff> UpdateStaff(Guid id, StaffRequest request)
        {
            var StaffData = await _appDbContext.Staff.FindAsync(id);
            if (StaffData == null)
            {
                throw new Exception("ID is Not Found");
            }

            StaffData.Name = request.Name;
            StaffData.Email = request.Email;
            StaffData.Phone = request.Phone;
            StaffData.Department = request.Department;


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
    }
}
